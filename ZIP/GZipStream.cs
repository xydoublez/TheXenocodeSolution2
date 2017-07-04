namespace Zip
{
    using ICSharpCode.SharpZipLib;
    using ICSharpCode.SharpZipLib.Zip;
    using System;
    using System.IO;

    public sealed class GZipStream : Stream
    {
        private bool bool_0;
        private bool bool_1;
        private GTransform gclass0_0;
        private/*protected*/ GZipBase gclass1_0;
        private Stream stream_0;

        public GZipStream(Stream stream_1) : this(stream_1, new GZipBase(), 0x1000)
        {
        }

        public GZipStream(Stream stream_1, GZipBase gclass1_1, int int_0)
        {
            this.bool_1 = true;
            if (stream_1 == null)
            {
                throw new ArgumentNullException("baseInputStream");
            }
            if (gclass1_1 == null)
            {
                throw new ArgumentNullException("inflater");
            }
            if (int_0 <= 0)
            {
                throw new ArgumentOutOfRangeException("bufferSize");
            }
            this.stream_0 = stream_1;
            this.gclass1_0 = gclass1_1;
            this.gclass0_0 = new GTransform(stream_1, int_0);
        }

        public override IAsyncResult BeginWrite(byte[] byte_0, int int_0, int int_1, AsyncCallback asyncCallback_0, object object_0)
        {
            throw new NotSupportedException("InflaterInputStream BeginWrite not supported");
        }

        public override void Close()
        {
            if (!this.bool_0)
            {
                this.bool_0 = true;
                if (this.bool_1)
                {
                    this.stream_0.Close();
                }
            }
        }

        public override void Flush()
        {
            this.stream_0.Flush();
        }

        private void method_0()
        {
            this.gclass0_0.method_2();
            this.gclass0_0.method_1(this.gclass1_0);
        }

        public override int Read(byte[] byte_0, int int_0, int int_1)
        {
            int num2;
            if (this.gclass1_0.method_8())
            {
                throw new SharpZipBaseException("Need a dictionary");
            }
            int num = int_1;
        Label_0041:
            num2 = this.gclass1_0.method_6(byte_0, int_0, num);
            int_0 += num2;
            num -= num2;
            if ((num != 0) && !this.gclass1_0.method_9())
            {
                if (this.gclass1_0.method_7())
                {
                    this.method_0();
                }
                else if (num2 == 0)
                {
                    throw new ZipException("Dont know what to do");
                }
                goto Label_0041;
            }
            return (int_1 - num);
        }

        public override long Seek(long long_0, SeekOrigin seekOrigin_0)
        {
            throw new NotSupportedException("Seek not supported");
        }

        public override void SetLength(long long_0)
        {
            throw new NotSupportedException("InflaterInputStream SetLength not supported");
        }

        public int vmethod_0()
        {
            if (!this.gclass1_0.method_9())
            {
                return 1;
            }
            return 0;
        }

        public override void Write(byte[] byte_0, int int_0, int int_1)
        {
            throw new NotSupportedException("InflaterInputStream Write not supported");
        }

        public override void WriteByte(byte byte_0)
        {
            throw new NotSupportedException("InflaterInputStream WriteByte not supported");
        }

        public override bool CanRead
        {
            get
            {
                return this.stream_0.CanRead;
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
                return false;
            }
        }

        public override long Length
        {
            get
            {
                return (long) this.gclass0_0.method_0();
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
                throw new NotSupportedException("InflaterInputStream Position not supported");
            }
        }
    }
}

