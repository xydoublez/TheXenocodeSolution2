namespace Zip
{
    using ICSharpCode.SharpZipLib;
    using System;
    using System.IO;
    using System.Security.Cryptography;

    public sealed class GTransform
    {
        private byte[] byte_0;
        private byte[] byte_1;
        private ICryptoTransform icryptoTransform_0;
        private int int_0;
        private int int_1;
        private int int_2;
        private Stream stream_0;

        public GTransform(Stream stream_1, int int_3)
        {
            icryptoTransform_0 = null;
            this.stream_0 = stream_1;
            if (int_3 < 0x400)
            {
                int_3 = 0x400;
            }
            this.byte_0 = new byte[int_3];
            this.byte_1 = this.byte_0;
        }

        public int method_0()
        {
            return this.int_0;
        }

        public void method_1(GZipBase gclass1_0)
        {
            if (this.int_2 > 0)
            {
                gclass1_0.method_5(this.byte_1, this.int_1 - this.int_2, this.int_2);
                this.int_2 = 0;
            }
        }

        public void method_2()
        {
            int num2;
            this.int_0 = 0;
            for (int i = this.byte_0.Length; i > 0; i -= num2)
            {
                num2 = this.stream_0.Read(this.byte_0, this.int_0, i);
                if (num2 <= 0)
                {
                    if (this.int_0 == 0)
                    {
                        throw new SharpZipBaseException("Unexpected EOF");
                    }
                    break;
                }
                this.int_0 += num2;
            }
            if (this.icryptoTransform_0 != null)
            {
                this.int_1 = this.icryptoTransform_0.TransformBlock(this.byte_0, 0, this.int_0, this.byte_1, 0);
            }
            else
            {
                this.int_1 = this.int_0;
            }
            this.int_2 = this.int_1;
        }
    }
}

