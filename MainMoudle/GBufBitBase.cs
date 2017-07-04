namespace MainMoudle
{
    using System;

    public sealed class GBufBitBase
    {
        private byte[] buf;
        private int index;
        private int num;
        private int bitalign;
        private uint datalen;

        public int initAlign(int int_3)
        {
            if (this.bitalign < int_3)
            {
                if (this.index == this.num)
                {
                    return -1;
                }
                this.datalen |= (uint) (((this.buf[this.index++] & 0xff) | ((this.buf[this.index++] & 0xff) << 8)) << this.bitalign);
                this.bitalign += 0x10;
            }
            return (((int) this.datalen) & ((((int) 1) << int_3) - 1));
        }

        public void SetAlign(int int_3)
        {
            this.datalen = this.datalen >> int_3;
            this.bitalign -= int_3;
        }

        public int GetAlign()
        {
            return this.bitalign;
        }

        public int GetDataLen()
        {
            return ((this.num - this.index) + (this.bitalign >> 3));
        }

        public void init()
        {
            this.datalen = this.datalen >> (this.bitalign & 7);
            this.bitalign &= -8;
        }

        public bool isover()
        {
            return (this.index == this.num);
        }

        public int SetData(byte[] byte_1, int int_3, int int_4)
        {
            if (int_4 < 0)
            {
                throw new ArgumentOutOfRangeException("length");
            }
            if ((this.bitalign & 7) != 0)
            {
                throw new InvalidOperationException("Bit buffer is not byte aligned!");
            }
            int num = 0;
            while (this.bitalign > 0)
            {
                if (int_4 <= 0)
                {
                    break;
                }
                byte_1[int_3++] = (byte) this.datalen;
                this.datalen = this.datalen >> 8;
                this.bitalign -= 8;
                int_4--;
                num++;
            }
            if (int_4 == 0)
            {
                return num;
            }
            int num2 = this.num - this.index;
            if (int_4 > num2)
            {
                int_4 = num2;
            }
            Array.Copy(this.buf, this.index, byte_1, int_3, int_4);
            this.index += int_4;
            if (((this.index - this.num) & 1) != 0)
            {
                this.datalen = (uint) (this.buf[this.index++] & 0xff);
                this.bitalign = 8;
            }
            return (num + int_4);
        }

        public void UpdateData(byte[] byte_1, int int_3, int int_4)
        {
            if (byte_1 == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if (int_3 < 0)
            {
                throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
            }
            if (int_4 < 0)
            {
                throw new ArgumentOutOfRangeException("count", "Cannot be negative");
            }
            if (this.index < this.num)
            {
                throw new InvalidOperationException("Old input was not completely processed");
            }
            int num = int_3 + int_4;
            if ((int_3 > num) || (num > byte_1.Length))
            {
                throw new ArgumentOutOfRangeException("count");
            }
            if ((int_4 & 1) != 0)
            {
                this.datalen |= (uint) ((byte_1[int_3++] & 0xff) << this.bitalign);
                this.bitalign += 8;
            }
            this.buf = byte_1;
            this.index = int_3;
            this.num = num;
        }
    }
}

