namespace MainMoudle
{
    using ICSharpCode.SharpZipLib;
    using About;
    using System;

    internal sealed class Process
    {
        private byte[] byte_0;
        private byte[] byte_1;
        private byte byte_2;
        private GZipLib gclass3_0;
        private static readonly int[] int_0 = new int[] { 3, 3, 11 };
        private static readonly int[] int_1 = new int[] { 2, 3, 7 };
        private static readonly int[] int_2 = new int[] { 
            0x10, 0x11, 0x12, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 
            14, 1, 15
         };
        private int int_3;
        private int int_4;
        private int int_5;
        private int int_6;
        private int int_7;
        private int int_8;
        private int int_9;

        public bool method_0(GBufBitBase gclass4_0)
        {
            int num2;
            int num3;
        Label_0000:
            switch (this.int_3)
            {
                case 0:
                    this.int_4 = gclass4_0.initAlign(5);
                    if (this.int_4 < 0)
                    {
                        return false;
                    }
                    this.int_4 += 0x101;
                    gclass4_0.SetAlign(5);
                    this.int_3 = 1;
                    goto Label_01FD;

                case 1:
                    goto Label_01FD;

                case 2:
                    goto Label_01AF;

                case 3:
                    goto Label_0176;

                case 4:
                    goto Label_00F4;

                case 5:
                    goto Label_002C;

                default:
                    goto Label_0000;
            }
        Label_002C:
            num3 = int_1[this.int_8];
            int num4 = gclass4_0.initAlign(num3);
            if (num4 < 0)
            {
                return false;
            }
            gclass4_0.SetAlign(num3);
            num4 += int_0[this.int_8];
            if ((this.int_9 + num4) <= this.int_7)
            {
                while (num4-- > 0)
                {
                    this.byte_1[this.int_9++] = this.byte_2;
                }
                if (this.int_9 == this.int_7)
                {
                    return true;
                }
                this.int_3 = 4;
                goto Label_0000;
            }
            throw new SharpZipBaseException();
        Label_00F4:
            while (((num2 = this.gclass3_0.method_1(gclass4_0)) & -16) == 0)
            {
                this.byte_1[this.int_9++] = this.byte_2 = (byte) num2;
                if (this.int_9 == this.int_7)
                {
                    return true;
                }
            }
            if (num2 < 0)
            {
                return false;
            }
            if (num2 >= 0x11)
            {
                this.byte_2 = 0;
            }
            else if (this.int_9 == 0)
            {
                throw new SharpZipBaseException();
            }
            this.int_8 = num2 - 0x10;
            this.int_3 = 5;
            goto Label_002C;
        Label_0176:
            while (this.int_9 < this.int_6)
            {
                int num = gclass4_0.initAlign(3);
                if (num < 0)
                {
                    return false;
                }
                gclass4_0.SetAlign(3);
                this.byte_0[int_2[this.int_9]] = (byte) num;
                this.int_9++;
            }
            this.gclass3_0 = new GZipLib(this.byte_0);
            this.byte_0 = null;
            this.int_9 = 0;
            this.int_3 = 4;
            goto Label_00F4;
        Label_01AF:
            this.int_6 = gclass4_0.initAlign(4);
            if (this.int_6 < 0)
            {
                return false;
            }
            this.int_6 += 4;
            gclass4_0.SetAlign(4);
            this.byte_0 = new byte[0x13];
            this.int_9 = 0;
            this.int_3 = 3;
            goto Label_0176;
        Label_01FD:
            this.int_5 = gclass4_0.initAlign(5);
            if (this.int_5 < 0)
            {
                return false;
            }
            this.int_5++;
            gclass4_0.SetAlign(5);
            this.int_7 = this.int_4 + this.int_5;
            this.byte_1 = new byte[this.int_7];
            this.int_3 = 2;
            goto Label_01AF;
        }

        public GZipLib method_1()
        {
            byte[] destinationArray = new byte[this.int_4];
            Array.Copy(this.byte_1, 0, destinationArray, 0, this.int_4);
            return new GZipLib(destinationArray);
        }

        public GZipLib method_2()
        {
            byte[] destinationArray = new byte[this.int_5];
            Array.Copy(this.byte_1, this.int_4, destinationArray, 0, this.int_5);
            return new GZipLib(destinationArray);
        }
    }
}

