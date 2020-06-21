using CardfileDotNet.Data;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace CardfileDotNet.IO
{
    internal class CrdxEncoder
    {
        public const long NO_FILE = -1L;
        static Encoding encoding = new UTF8Encoding(false);

        public CrdxEncoder()
        {
        }

        internal void Write(Cardfile file, string filePath, bool compress = false)
        {
            using (BinaryWriter writer = new BinaryWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None)))
            {
                // magic number
                writer.Write(encoding.GetBytes("CFDN"));
                writer.Write((uint)1);

                if (compress)
                {
                    writer.Write((uint)1); // compressed with gz
                    writer.Flush();
                    long sizePos = writer.BaseStream.Position;
                    writer.Write((ulong)0); // coming back here to write later
                    writer.Flush();
                    writer.BaseStream.Flush();
                    long basePos = writer.BaseStream.Position;

                    using (MemoryStream tmp = new MemoryStream())
                    using (BinaryWriter dataWriter = new BinaryWriter(tmp))
                    using (GZipStream compressionStream = new GZipStream(writer.BaseStream, CompressionMode.Compress, true))
                    {
                        tmp.Seek(basePos, SeekOrigin.Begin);
                        WriteData(file, dataWriter);
                        dataWriter.Flush();
                        tmp.Flush();
                        tmp.Seek(basePos, SeekOrigin.Begin);
                        tmp.CopyTo(compressionStream);
                    }

                    writer.Flush();
                    long compressedStreamSize = writer.BaseStream.Position - sizePos;

                    writer.BaseStream.Seek(sizePos, SeekOrigin.Begin);
                    writer.Write((ulong)compressedStreamSize); // write position
                }
                else
                {
                    writer.Write((uint)0); // not compressed
                    writer.Write((ulong)0); // total file size; 0 for uncompressed
                    WriteData(file, writer);
                }
            }
        }

        private void WriteData(Cardfile file, BinaryWriter writer)
        {
            writer.Write((uint)file.Cards.Count);
            writer.Write((uint)file.FrontIndex);
            writer.Write((uint)0);
            writer.Write((uint)0);
            writer.Write((uint)0);
            writer.Write((uint)0);
            writer.Write((uint)0);

            List<Offset> offsets = new List<Offset>();

            foreach (Card card in file.Cards)
            {
                writer.Flush();
                Offset offset = new Offset(writer.BaseStream.Position, 0, -1);
                offsets.Add(offset);

                byte[] indexu8 = encoding.GetBytes(card.Index);
                writer.Flush();
                writer.Write(offset.text);
                writer.Write(offset.file);
                writer.Write((uint)0);
                writer.Write((uint)0);
                writer.Write((uint)0);
                writer.Write((uint)indexu8.Length);
                writer.Write(indexu8);
            }

            // text data
            int i = 0;
            foreach (Card card in file.Cards)
            {
                writer.Flush();
                offsets[i] = new Offset(offsets[i].ptr, (uint)writer.BaseStream.Position, 0);

                byte[] text = encoding.GetBytes(card.Contents);
                writer.Write((ulong)text.Length);
                writer.Write(text);
                ++i;
            }

            // attached file
            i = 0;
            foreach (Card card in file.Cards)
            {
                writer.Flush();
                if (card.Attachment != null)
                {
                    offsets[i] = new Offset(offsets[i].ptr, offsets[i].text, (uint)writer.BaseStream.Position);
                    byte[] text = encoding.GetBytes(card.Attachment.Name);
                    writer.Write((uint)text.Length);
                    writer.Write(text);
                    text = encoding.GetBytes(card.Attachment.Mime);
                    writer.Write((uint)text.Length);
                    writer.Write(text);
                    writer.Write((ulong)card.Attachment.Data.Length);
                    writer.Write(card.Attachment.Data);
                }
                else
                {
                    offsets[i] = new Offset(offsets[i].ptr, offsets[i].text, NO_FILE);
                }
                ++i;
            }

            foreach (Offset offset in offsets)
            {
                writer.Flush();
                writer.BaseStream.Seek(offset.ptr, SeekOrigin.Begin);
                writer.Write(offset.text);
                writer.Write(offset.file);
            }
        }

        struct Offset
        {
            internal long ptr;
            internal long text;
            internal long file;

            public Offset(long ptr, long text, long file)
            {
                this.ptr = ptr;
                this.text = text;
                this.file = file;
            }
        }
    }
}