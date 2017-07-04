namespace Zip
{
    using System;

    public sealed class GZipTrans
    {
        private uint uint_0;

        public GZipTrans()
        {
            this.vmethod_1();
        }

        public long vmethod_0()
        {
            return (long) this.uint_0;
        }

        public void vmethod_1()
        {
            this.uint_0 = 1;
        }

        public void vmethod_2(byte[] byte_0, int int_0, int int_1)
        {
            if (byte_0 == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if (int_0 < 0)
            {
                throw new ArgumentOutOfRangeException("offset", "cannot be negative");
            }
            if (int_1 < 0)
            {
                throw new ArgumentOutOfRangeException("count", "cannot be negative");
            }
            if (int_0 >= byte_0.Length)
            {
                throw new ArgumentOutOfRangeException("offset", "not a valid index into buffer");
            }
            if ((int_0 + int_1) > byte_0.Length)
            {
                throw new ArgumentOutOfRangeException("count", "exceeds buffer size");
            }
            uint num = this.uint_0 & 0xffff;
            uint num2 = this.uint_0 >> 0x10;
            while (int_1 > 0)
            {
                int num3 = 0xed8;
                if (num3 > int_1)
                {
                    num3 = int_1;
                }
                int_1 -= num3;
                while (--num3 >= 0)
                {
                    num += (uint) (byte_0[int_0++] & 0xff);
                    num2 += num;
                }
                num = num % 0xfff1;
                num2 = num2 % 0xfff1;
            }
            this.uint_0 = (num2 << 0x10) | num;
        }
    }
}

