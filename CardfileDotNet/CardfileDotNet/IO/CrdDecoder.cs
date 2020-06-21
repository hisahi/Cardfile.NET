using CardfileDotNet.Data;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;

namespace CardfileDotNet.IO
{
    internal class CrdDecoder
    {
        // TODO: configurable
        static Encoding encoding8bit = Encoding.GetEncoding(1252);
        static Encoding encoding16bit = Encoding.Unicode;

        public CrdDecoder()
        {
        }

        internal void Read(Cardfile file, string filePath)
        {
            using (BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                // magic number
                string magicNum = encoding8bit.GetString(reader.ReadBytes(3));

                if (magicNum == "MGC")          // Windows 1.0 - 3.1 original; no OLE or UTF-16 support
                    ReadMGC(file, reader);
                else if (magicNum == "RRG")     // Windows 3.1; OLE support, not UTF-16
                    ReadRRG(file, reader);
                else if (magicNum == "DKO")     // Windows NT; OLE support, UTF-16
                    ReadDKO(file, reader);
                else
                    throw new ArgumentException("Not a valid .CRD file!");

                file.FrontIndex = 0;
            }
        }

        private static string CutAtNullTerminator(string s)
        {
            if (s.IndexOf('\0') >= 0)
                return s.Substring(0, s.IndexOf('\0'));
            return s;
        }

        private static string ReadNullTerminated8String(byte[] b)
        {
            return CutAtNullTerminator(encoding8bit.GetString(b));
        }

        private static string ReadNullTerminated16String(byte[] b)
        {
            return CutAtNullTerminator(encoding16bit.GetString(b));
        }

        private void ReadMGC(Cardfile file, BinaryReader reader)
        {
            ushort cardCount = reader.ReadUInt16();
            long oldPosition;

            for (int i = 0; i < cardCount; ++i)
            {
                reader.BaseStream.Seek(6, SeekOrigin.Current);

                // read card info
                uint pos = reader.ReadUInt32();
                byte flags = reader.ReadByte();
                byte[] titleRaw = reader.ReadBytes(41);
                string index = ReadNullTerminated8String(titleRaw);

                oldPosition = reader.BaseStream.Position;

                // read card
                reader.BaseStream.Seek(pos, SeekOrigin.Begin);
                ushort bitmapLength = reader.ReadUInt16();
                AttachmentFile attachment = null;
                if (bitmapLength != 0)
                {
                    // has graphic
                    ushort width = reader.ReadUInt16();
                    ushort height = reader.ReadUInt16();
                    ushort x = reader.ReadUInt16();
                    ushort y = reader.ReadUInt16();
                    byte[] bitmap = reader.ReadBytes(bitmapLength);

                    Rectangle dstRect = new Rectangle(0, 0, 320, 160);
                    Rectangle srcRect = new Rectangle(x, y, width, height);
                    if (!dstRect.Contains(srcRect))
                        dstRect = new Rectangle(0, 0, Math.Max(x + width, dstRect.Width), Math.Max(y + height, dstRect.Height));
                    Bitmap result = new Bitmap(dstRect.Width, dstRect.Height, PixelFormat.Format24bppRgb);
                    Bitmap target = new Bitmap(dstRect.Width, dstRect.Height, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
                    target.Palette.Entries[0] = Color.FromArgb(0, 0, 0);
                    target.Palette.Entries[1] = Color.FromArgb(255, 255, 255);

                    BitmapData targetData = target.LockBits(dstRect, ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
                    for (int column = 0; column < dstRect.Height; ++column)
                        FillMemory(targetData.Scan0 + targetData.Stride * column, (byte)255, targetData.Stride);
                    target.UnlockBits(targetData);

                    targetData = target.LockBits(srcRect, ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
                    int srcStride = (width + 7) / 8;
                    if ((srcStride & 1) == 1)
                        srcStride += 1;
                    for (int column = 0; column < height; ++column)
                        Marshal.Copy(bitmap, srcStride * column, targetData.Scan0 + targetData.Stride * column, srcStride);
                    target.UnlockBits(targetData);
                    using (Graphics g = Graphics.FromImage(result))
                        g.DrawImage(target, 0, 0);

                    using (MemoryStream mem = new MemoryStream())
                    {
                        result.Save(mem, ImageFormat.Bmp);
                        mem.Flush();
                        attachment = new AttachmentFile("IMAGE.BMP", "image/bmp", mem.ToArray());
                    }
                }
                ushort textlen = reader.ReadUInt16();

                byte[] textRaw = reader.ReadBytes(textlen);
                string text = ReadNullTerminated8String(textRaw);

                reader.BaseStream.Seek(oldPosition, SeekOrigin.Begin);

                Card card = new Card(index, text);
                if (attachment != null)
                    card.Attachment = attachment;
                file.AddCard(card);
            }
        }

        private void FillMemory(IntPtr dest, byte value, int count)
        {
            byte[] result = new byte[count];
            for (int i = 0; i < count; ++i)
                result[i] = value;
            Marshal.Copy(result, 0, dest, count);
        }

        private void SkipPresentationObj(BinaryReader reader)
        {
            // read chunk version
            ushort version = reader.ReadUInt16();
            reader.ReadUInt16();
            // version can be whatever according to MS-OLEDS; thus skip
            uint formatId = reader.ReadUInt32();
            // class string
            uint chkStringLen = reader.ReadUInt32();
            string chkString = ReadNullTerminated8String(reader.ReadBytes((int)chkStringLen));
            if (chkString == "DIB" || chkString == "BITMAP" || chkString == "METAFILEPICT")
            {
                // bitmap
                uint width = reader.ReadUInt32();
                uint height = reader.ReadUInt32();
                // size and data
                reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Current);
            }
            else
            {
                // clipboard
                uint format = reader.ReadUInt32();
                if (format == 0) // skip custom format name
                    reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Current);
                // size and data
                reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Current);
            }
        }

        private OleObject ReadOLE(BinaryReader reader)
        {
            OleObject res = new OleObject();
            // read chunk version
            ushort version = reader.ReadUInt16();
            reader.ReadUInt16();
            // version can be whatever according to MS-OLEDS; thus skip
            uint formatId = reader.ReadUInt32();
            if (formatId < 1 || formatId > 3)
                formatId = 0;
            res.Format = (OleType)formatId;
            // class string
            uint stringLength = reader.ReadUInt32();
            byte[] stringData = reader.ReadBytes((int)stringLength);
            res.ClassString = CutAtNullTerminator(Encoding.ASCII.GetString(stringData));
            if (formatId == 3)
            {
                // static
                uint width = reader.ReadUInt32();
                uint height = reader.ReadUInt32();
                // size and data
                uint staticDataLength = reader.ReadUInt32();
                res.StaticData = reader.ReadBytes((int)staticDataLength);
            }
            else
            {
                // topic string
                reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Current);
                // item string
                reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Current);
                if (formatId == 2)
                {
                    // embedded. native data & size
                    uint staticDataLength = reader.ReadUInt32();
                    res.StaticData = reader.ReadBytes((int)staticDataLength);
                }
                else
                {
                    // linked. network name
                    uint networkNameLength = reader.ReadUInt32();
                    byte[] networkNameData = reader.ReadBytes((int)networkNameLength);
                    res.NetworkName = CutAtNullTerminator(Encoding.ASCII.GetString(networkNameData));
                    reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Current);
                    // network type
                    res.NetworkType = reader.ReadUInt32();
                    // link options
                    res.LinkOption = reader.ReadUInt32();
                    SkipPresentationObj(reader);
                }
            }
            return res;
        }

        private bool TryParseOleAttachment(OleObject obj, ref AttachmentFile attachment)
        {
            if (obj.ClassString == "SoundRec")
            {
                attachment = new AttachmentFile("SOUND.WAV", "audio/wav", obj.StaticData);
                return true;
            }
            if (obj.ClassString == "PBrush")
            {
                attachment = new AttachmentFile("IMAGE.BMP", "image/bmp", obj.StaticData);
                return true;
            }
            if (obj.ClassString == "Package")
            {
                attachment = new AttachmentFile("PACKAGE.OLE", "application/octet-stream", obj.StaticData);
                return true;
            }
            return false;
        }

        private void ReadRRG(Cardfile file, BinaryReader reader)
        {
            uint nextObjectID = reader.ReadUInt32();
            ushort cardCount = reader.ReadUInt16();
            long oldPosition;

            for (int i = 0; i < cardCount; ++i)
            {
                reader.BaseStream.Seek(6, SeekOrigin.Current);

                // read card info
                uint pos = reader.ReadUInt32();
                byte flags = reader.ReadByte();
                byte[] titleRaw = reader.ReadBytes(41);
                string index = ReadNullTerminated8String(titleRaw);

                oldPosition = reader.BaseStream.Position;

                // read card
                reader.BaseStream.Seek(pos, SeekOrigin.Begin);
                ushort objectFlags = reader.ReadUInt16();
                AttachmentFile attachment = null;

                if (objectFlags != 0)
                {
                    // contains OLE object
                    uint objectId = reader.ReadUInt32();
                    long beforeObj = reader.BaseStream.Position;
                    OleObject obj = ReadOLE(reader);
                    long oleObjLen = reader.BaseStream.Position - beforeObj;
                    reader.BaseStream.Seek(beforeObj, SeekOrigin.Begin);
                    byte[] oleData = reader.ReadBytes((int)oleObjLen);
                    obj.Data = oleData;

                    bool customAttachment = false;
                    if (obj.Format == OleType.Static || obj.Format == OleType.Embedded)
                        customAttachment = TryParseOleAttachment(obj, ref attachment);
                    if (!customAttachment)
                        attachment = new AttachmentFile("OBJECT.OLE", "application/octet-stream", obj.Data);

                    // then skip other attributes
                    /*ushort charWidth =*/ reader.ReadUInt16();
                    /*ushort charHeight =*/ reader.ReadUInt16();
                    /*ushort rectLeft =*/ reader.ReadUInt16();
                    /*ushort rectTop =*/ reader.ReadUInt16();
                    /*ushort rectRight =*/ reader.ReadUInt16();
                    /*ushort rectBottom =*/ reader.ReadUInt16();
                    /*ushort objectType =*/ reader.ReadUInt16();
                }

                ushort textlen = reader.ReadUInt16();

                byte[] textRaw = reader.ReadBytes(textlen);
                string text = ReadNullTerminated8String(textRaw);

                reader.BaseStream.Seek(oldPosition, SeekOrigin.Begin);

                Card card = new Card(index, text);
                if (attachment != null)
                    card.Attachment = attachment;
                file.AddCard(card);
            }
        }

        private void ReadDKO(Cardfile file, BinaryReader reader)
        {
            uint nextObjectID = reader.ReadUInt32();
            ushort cardCount = reader.ReadUInt16();
            long oldPosition;

            for (int i = 0; i < cardCount; ++i)
            {
                reader.BaseStream.Seek(6, SeekOrigin.Current);

                // read card info
                uint pos = reader.ReadUInt32();
                byte flags = reader.ReadByte();
                byte[] titleRaw = reader.ReadBytes(82);
                string index = ReadNullTerminated16String(titleRaw);

                oldPosition = reader.BaseStream.Position;

                // read card
                reader.BaseStream.Seek(pos, SeekOrigin.Begin);
                ushort objectFlags = reader.ReadUInt16();
                AttachmentFile attachment = null;

                if (objectFlags != 0)
                {
                    // contains OLE object
                    uint objectId = reader.ReadUInt32();
                    // get length of OLE object by skipping over it
                    long beforeObj = reader.BaseStream.Position;
                    OleObject obj = ReadOLE(reader);
                    long oleObjLen = reader.BaseStream.Position - beforeObj;
                    reader.BaseStream.Seek(beforeObj, SeekOrigin.Begin);
                    obj.Data = reader.ReadBytes((int)oleObjLen);

                    bool customAttachment = false;
                    if (obj.Format == OleType.Static || obj.Format == OleType.Embedded)
                        customAttachment = TryParseOleAttachment(obj, ref attachment);
                    if (!customAttachment)
                        attachment = new AttachmentFile("OBJECT.OLE", "application/octet-stream", obj.Data);

                    // then skip other attributes
                    /*ushort charWidth =*/ reader.ReadUInt16();
                    /*ushort charHeight =*/ reader.ReadUInt16();
                    /*ushort rectLeft =*/ reader.ReadUInt16();
                    /*ushort rectTop =*/ reader.ReadUInt16();
                    /*ushort rectRight =*/ reader.ReadUInt16();
                    /*ushort rectBottom =*/ reader.ReadUInt16();
                    /*ushort objectType =*/ reader.ReadUInt16();
                }

                ushort textlen = reader.ReadUInt16();

                byte[] textRaw = reader.ReadBytes(textlen * 2 + 3);
                string text = ReadNullTerminated16String(textRaw);

                reader.BaseStream.Seek(oldPosition, SeekOrigin.Begin);

                Card card = new Card(index, text);
                if (attachment != null)
                    card.Attachment = attachment;
                file.AddCard(card);
            }
        }
    }
}