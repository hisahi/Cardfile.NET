using System;
using System.IO;
using System.Text;

namespace CardfileDotNet.IO
{
    internal class SeekableBinaryReader : BinaryReader
    {
        public SeekableBinaryReader(Stream stream) : base(stream)
        {
        }

        public SeekableBinaryReader(Stream stream, Encoding encoding, bool keepOpen) : base(stream, encoding, keepOpen)
        {
        }

        // assumption: BinaryReader *does* not buffer data between Read() calls.
        // this is not necessarily true (but better alternatives do not exist):
        //      "Using the underlying stream while reading or while using the
        //       BinaryReader can cause data loss and corruption. For example,
        //       the same bytes might be read more than once, bytes might be
        //       skipped, or character reading might become unpredictable."


        /// <summary>
        /// Skips the specified number of bytes from the strema.
        /// </summary>
        /// <param name="bytes">The number of bytes to skip.</param>
        /// <returns></returns>
        public void Skip(int bytes)
        {
            if (this.BaseStream.CanSeek)
                this.BaseStream.Seek(bytes, SeekOrigin.Current);
            else
                for (int i = 0; i < bytes; ++i)
                    this.ReadByte();
        }

        /// <summary>
        /// Sets the position within the current stream.
        /// </summary>
        /// <param name="position">A byte offset relative to the <paramref name="origin" /> parameter.</param>
        /// <param name="origin">A value of type <see cref="SeekOrigin"/> indicating the reference point used to obtain the new position.</param>
        /// <returns></returns>
        public long Seek(long position, SeekOrigin origin)
        {
            return this.BaseStream.Seek(position, origin);
        }

        /// <summary>
        /// Gets or sets the position within the current stream.
        /// </summary>
        public long Position
        {
            get => this.BaseStream.Position;
            set => this.BaseStream.Position = value;
        }
    }
}