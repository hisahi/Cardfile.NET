using CardfileDotNet.Data;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace CardfileDotNet.IO
{
    internal class CrdxDecoder
    {
        static Encoding encoding = new UTF8Encoding(false);

        public CrdxDecoder()
        {
        }

        internal void Read(Cardfile file, string filePath, out bool compressed)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (SeekableBinaryReader reader = new SeekableBinaryReader(fileStream, encoding, true))
            {
                // magic number
                string magicNum = encoding.GetString(reader.ReadBytes(4));

                if (magicNum != "CFDN")
                    throw new ArgumentException("Not a valid .CRDX file!");

                uint version = reader.ReadUInt32();
                if (version == 0 || version > 1)
                    throw new ArgumentException("Incompatible .CRDX file version!");

                uint compression = reader.ReadUInt32();
                reader.ReadUInt64(); // file size

                if (compression == 0)
                {
                    // uncompressed
                    ReadData(file, reader);
                    compressed = false;
                }
                else if (compression == 1)
                {
                    // compressed GZIP
                    long oldPos = fileStream.Position;
                    using (GZipStream compressionStream = new GZipStream(fileStream, CompressionMode.Decompress))
                    using (MemoryStream tmp = new MemoryStream())
                    {
                        tmp.Seek(oldPos, SeekOrigin.Begin);
                        compressionStream.CopyTo(tmp);
                        tmp.Flush();
                        tmp.Seek(oldPos, SeekOrigin.Begin);
                        using (SeekableBinaryReader memReader = new SeekableBinaryReader(tmp))
                        {
                            ReadData(file, memReader);
                        }
                    }
                    compressed = true;
                }
                else
                    throw new ArgumentException("Incompatible .CRDX file compression!");
            }
        }

        private void ReadData(Cardfile file, SeekableBinaryReader reader)
        {
            uint cardCount = reader.ReadUInt32();
            uint cardIndex = reader.ReadUInt32();
            reader.Skip(20);

            if (cardIndex > cardCount)
                throw new ArgumentException("Not a valid .CRDX file!");
            else if (cardIndex == cardCount)
                file.FrontIndex = -1;

            for (int i = 0; i < cardCount; ++i)
            {
                long textOffset = reader.ReadInt64();
                long fileOffset = reader.ReadInt64();
                reader.Skip(12);
                uint indexLength = reader.ReadUInt32();

                string index = encoding.GetString(reader.ReadBytes((int)indexLength));
                long oldPosition = reader.Position;
                Card newCard = new Card(index);

                reader.Seek(textOffset, SeekOrigin.Begin);
                ulong textLength = reader.ReadUInt64();
                byte[] buffer = reader.ReadBytes((int)textLength);
                newCard.Contents = encoding.GetString(buffer);

                if (fileOffset >= 0)
                {
                    reader.Seek(fileOffset, SeekOrigin.Begin);
                    uint nameLength = reader.ReadUInt32();
                    byte[] nameData = reader.ReadBytes((int)nameLength);
                    uint mimeLength = reader.ReadUInt32();
                    byte[] mimeData = reader.ReadBytes((int)mimeLength);
                    ulong attachmentLength = reader.ReadUInt64();
                    byte[] attachmentData = reader.ReadBytes((int)textLength);
                    AttachmentFile attachment = new AttachmentFile(encoding.GetString(nameData), encoding.GetString(mimeData), attachmentData);
                    newCard.Attachment = attachment;
                }

                file.AddCard(newCard);
                reader.Seek(oldPosition, SeekOrigin.Begin);
            }
            file.FrontIndex = (int)cardIndex;
        }
    }
}