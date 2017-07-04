namespace About
{
    using MainMoudle;
    using System;

    public sealed class GZipBuf
    {
        private byte[] byte_0 = new byte[0x8000];
        private int int_0;
        private int int_1;

        public void method_0(int int_2)
        {
            if (this.int_1++ == 0x8000)
            {
                throw new InvalidOperationException("Window full");
            }
            this.byte_0[this.int_0++] = (byte) int_2;
            this.int_0 &= 0x7fff;
        }

        private void method_1(int int_2, int int_3, int int_4)
        {
            while (int_3-- > 0)
            {
                this.byte_0[this.int_0++] = this.byte_0[int_2++];
                this.int_0 &= 0x7fff;
                int_2 &= 0x7fff;
            }
        }

        public void method_2(int int_2, int int_3)
        {
            this.int_1 += int_2;
            if (this.int_1 > 0x8000)
            {
                throw new InvalidOperationException("Window full");
            }
            int num = (this.int_0 - int_3) & 0x7fff;
            int num2 = 0x8000 - int_2;
            if ((num > num2) || (this.int_0 >= num2))
            {
                this.method_1(num, int_2, int_3);
            }
            else if (int_2 > int_3)
            {
                while (int_2-- > 0)
                {
                    this.byte_0[this.int_0++] = this.byte_0[num++];
                }
            }
            else
            {
                Array.Copy(this.byte_0, num, this.byte_0, this.int_0, int_2);
                this.int_0 += int_2;
            }
        }

        public int method_3(GBufBitBase gclass4_0, int int_2)
        {
            int num;
            int_2 = Math.Min(Math.Min(int_2, 0x8000 - this.int_1), gclass4_0.GetDataLen());
            int num2 = 0x8000 - this.int_0;
            if (int_2 > num2)
            {
                num = gclass4_0.SetData(this.byte_0, this.int_0, num2);
                if (num == num2)
                {
                    num += gclass4_0.SetData(this.byte_0, 0, int_2 - num2);
                }
            }
            else
            {
                num = gclass4_0.SetData(this.byte_0, this.int_0, int_2);
            }
            this.int_0 = (this.int_0 + num) & 0x7fff;
            this.int_1 += num;
            return num;
        }

        public int method_4()
        {
            return (0x8000 - this.int_1);
        }

        public int method_5()
        {
            return this.int_1;
        }

        public int method_6(byte[] byte_1, int int_2, int int_3)
        {
            int num = this.int_0;
            if (int_3 > this.int_1)
            {
                int_3 = this.int_1;
            }
            else
            {
                num = ((this.int_0 - this.int_1) + int_3) & 0x7fff;
            }
            int num2 = int_3;
            int length = int_3 - num;
            if (length > 0)
            {
                Array.Copy(this.byte_0, 0x8000 - length, byte_1, int_2, length);
                int_2 += length;
                int_3 = num;
            }
            Array.Copy(this.byte_0, num - int_3, byte_1, int_2, int_3);
            this.int_1 -= num2;
            if (this.int_1 < 0)
            {
                throw new InvalidOperationException();
            }
            return num2;
        }
    }
}

