namespace About
{
    using ICSharpCode.SharpZipLib;
    using PESECTION;
    using MainMoudle;
    using System;

    public sealed class GZipLib
    {
        public static GZipLib gclass3_0;
        public static GZipLib gclass3_1;
        private short[] short_0;

        static GZipLib()
        {
            try
            {
                byte[] buffer = new byte[0x120];
                int num = 0;
                while (num < 0x90)
                {
                    buffer[num++] = 8;
                }
                while (num < 0x100)
                {
                    buffer[num++] = 9;
                }
                while (num < 280)
                {
                    buffer[num++] = 7;
                }
                while (num < 0x120)
                {
                    buffer[num++] = 8;
                }
                gclass3_0 = new GZipLib(buffer);
                buffer = new byte[0x20];
                num = 0;
                while (num < 0x20)
                {
                    buffer[num++] = 5;
                }
                gclass3_1 = new GZipLib(buffer);
            }
            catch (Exception)
            {
                throw new SharpZipBaseException("InflaterHuffmanTree: static tree length illegal");
            }
        }

        public GZipLib(byte[] byte_0)
        {
            this.method_0(byte_0);
        }

        private void method_0(byte[] byte_0)
        {
            int[] numArray = new int[0x10];
            int[] numArray2 = new int[0x10];
            for (int i = 0; i < byte_0.Length; i++)
            {
                int index = byte_0[i];
                if (index > 0)
                {
                    numArray[index]++;
                }
            }
            int num3 = 0;
            int num4 = 0x200;
            for (int j = 1; j <= 15; j++)
            {
                numArray2[j] = num3;
                num3 += numArray[j] << (0x10 - j);
                if (j >= 10)
                {
                    int num6 = numArray2[j] & 0x1ff80;
                    int num7 = num3 & 0x1ff80;
                    num4 += (num7 - num6) >> (0x10 - j);
                }
            }
            this.short_0 = new short[num4];
            int num8 = 0x200;
            for (int k = 15; k >= 10; k--)
            {
                int num10 = num3 & 0x1ff80;
                num3 -= numArray[k] << (0x10 - k);
                int num11 = num3 & 0x1ff80;
                for (int n = num11; n < num10; n += 0x80)
                {
                    this.short_0[GXtbl.smethod_0(n)] = (short) ((-num8 << 4) | k);
                    num8 += ((int) 1) << (k - 9);
                }
            }
            for (int m = 0; m < byte_0.Length; m++)
            {
                int num14 = byte_0[m];
                if (num14 != 0)
                {
                    num3 = numArray2[num14];
                    int num15 = GXtbl.smethod_0(num3);
                    if (num14 <= 9)
                    {
                        do
                        {
                            this.short_0[num15] = (short) ((m << 4) | num14);
                            num15 += ((int) 1) << num14;
                        }
                        while (num15 < 0x200);
                    }
                    else
                    {
                        int num16 = this.short_0[num15 & 0x1ff];
                        int num17 = ((int) 1) << (num16 & 15);
                        num16 = -(num16 >> 4);
                        do
                        {
                            this.short_0[num16 | (num15 >> 9)] = (short) ((m << 4) | num14);
                            num15 += ((int) 1) << num14;
                        }
                        while (num15 < num17);
                    }
                    numArray2[num14] = num3 + (((int) 1) << (0x10 - num14));
                }
            }
        }

        public int method_1(GBufBitBase gclass4_0)
        {
            int num2;
            int index = gclass4_0.initAlign(9);
            if (index >= 0)
            {
                num2 = this.short_0[index];
                if (num2 >= 0)
                {
                    gclass4_0.SetAlign(num2 & 15);
                    return (num2 >> 4);
                }
                int num3 = -(num2 >> 4);
                int num4 = num2 & 15;
                index = gclass4_0.initAlign(num4);
                if (index >= 0)
                {
                    num2 = this.short_0[num3 | (index >> 9)];
                    gclass4_0.SetAlign(num2 & 15);
                    return (num2 >> 4);
                }
                int num5 = gclass4_0.GetAlign();
                index = gclass4_0.initAlign(num5);
                num2 = this.short_0[num3 | (index >> 9)];
                if ((num2 & 15) <= num5)
                {
                    gclass4_0.SetAlign(num2 & 15);
                    return (num2 >> 4);
                }
                return -1;
            }
            int num6 = gclass4_0.GetAlign();
            index = gclass4_0.initAlign(num6);
            num2 = this.short_0[index];
            if ((num2 >= 0) && ((num2 & 15) <= num6))
            {
                gclass4_0.SetAlign(num2 & 15);
                return (num2 >> 4);
            }
            return -1;
        }
    }
}

