namespace MainFrm
{
    using System;
    using System.IO;

    internal sealed class FileStream : Stream
    {
        private int int_0;
        private Stream stream_0;

        public FileStream(Stream stream_1, int int_1)
        {
            this.int_0 = int_1;
            this.stream_0 = stream_1;
        }

        public override void Flush()
        {
            this.stream_0.Flush();
        }

        private byte method_0()
        {
            this.int_0 = (this.int_0 * 0x343fd) + 0x269ec3;
            return (byte) ((this.int_0 >> 0x10) & 0xff);
        }

        public override int Read(byte[] byte_0, int int_1, int int_2)
        {
            try
            {
                this.stream_0.Read(byte_0, int_1, int_2);
                for (int i = 0; i < int_2; i++)
                {
                    byte_0[int_1 + i] = (byte) (byte_0[int_1 + i] ^ this.method_0());
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public override long Seek(long long_0, SeekOrigin seekOrigin_0)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void SetLength(long long_0)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void Write(byte[] byte_0, int int_1, int int_2)
        {
            try
            {
                for (int i = 0; i < int_2; i++)
                {
                    byte_0[int_1 + i] = (byte) (byte_0[int_1 + i] ^ this.method_0());
                }
                this.stream_0.Write(byte_0, int_1, int_2);
            }
            catch
            {
            }
        }

        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }

        public override long Length
        {
            get
            {
                return this.stream_0.Length;
            }
        }

        public override long Position
        {
            get
            {
                return this.stream_0.Position;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }
    }
}

