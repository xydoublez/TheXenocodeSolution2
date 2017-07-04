namespace Zip
{
    using ICSharpCode.SharpZipLib;
    using About;
    using MainMoudle;
    using System;

    public sealed class GZipBase
    {
        private bool bool_0;
        private bool bool_1;
        private Process class2_0;
        private GZipTrans gclass2_0;
        private GZipLib gclass3_0;
        private GZipLib gclass3_1;
        private GBufBitBase gclass4_0;
        private GZipBuf gclass6_0;
        private static readonly int[] int_0 = new int[] { 
            3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 15, 0x11, 0x13, 0x17, 0x1b, 0x1f, 
            0x23, 0x2b, 0x33, 0x3b, 0x43, 0x53, 0x63, 0x73, 0x83, 0xa3, 0xc3, 0xe3, 0x102
         };
        private static readonly int[] int_1 = new int[] { 
            0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 
            3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 0
         };
        private int int_10;
        private int int_11;
        private static readonly int[] int_2 = new int[] { 
            1, 2, 3, 4, 5, 7, 9, 13, 0x11, 0x19, 0x21, 0x31, 0x41, 0x61, 0x81, 0xc1, 
            0x101, 0x181, 0x201, 0x301, 0x401, 0x601, 0x801, 0xc01, 0x1001, 0x1801, 0x2001, 0x3001, 0x4001, 0x6001
         };
        private static readonly int[] int_3 = new int[] { 
            0, 0, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 
            7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13
         };
        private int int_4;
        private int int_5;
        private int int_6;
        private int int_7;
        private int int_8;
        private int int_9;

        public GZipBase() : this(false)
        {
        }

        public GZipBase(bool bool_2)
        {
            this.bool_1 = bool_2;
            this.gclass2_0 = new GZipTrans();
            this.gclass4_0 = new GBufBitBase();
            this.gclass6_0 = new GZipBuf();
            this.int_4 = bool_2 ? 2 : 0;
        }

        private bool method_0()
        {
            int num = this.gclass4_0.initAlign(0x10);
            if (num < 0)
            {
                return false;
            }
            this.gclass4_0.SetAlign(0x10);
            num = ((num << 8) | (num >> 8)) & 0xffff;
            if ((num % 0x1f) != 0)
            {
                throw new SharpZipBaseException("Header checksum illegal");
            }
            if ((num & 0xf00) != 0x800)
            {
                throw new SharpZipBaseException("Compression Method unknown");
            }
            if ((num & 0x20) == 0)
            {
                this.int_4 = 2;
            }
            else
            {
                this.int_4 = 1;
                this.int_6 = 0x20;
            }
            return true;
        }

        private bool method_1()
        {
            while (this.int_6 > 0)
            {
                int num = this.gclass4_0.initAlign(8);
                if (num < 0)
                {
                    return false;
                }
                this.gclass4_0.SetAlign(8);
                this.int_5 = (this.int_5 << 8) | num;
                this.int_6 -= 8;
            }
            return false;
        }

        private bool method_2()
        {
            int num = this.gclass6_0.method_4();
            while (num >= 0x102)
            {
                int num2;
                switch (this.int_4)
                {
                    case 7:
                        goto Label_0052;

                    case 8:
                        goto Label_00AC;

                    case 9:
                        goto Label_00FC;

                    case 10:
                        goto Label_013D;

                    default:
                        throw new SharpZipBaseException("Inflater unknown mode");
                }
            Label_0037:
                this.gclass6_0.method_0(num2);
                if (--num < 0x102)
                {
                    return true;
                }
            Label_0052:
                if (((num2 = this.gclass3_0.method_1(this.gclass4_0)) & -256) == 0)
                {
                    goto Label_0037;
                }
                if (num2 < 0x101)
                {
                    if (num2 < 0)
                    {
                        return false;
                    }
                    this.gclass3_1 = null;
                    this.gclass3_0 = null;
                    this.int_4 = 2;
                    return true;
                }
                try
                {
                    this.int_7 = int_0[num2 - 0x101];
                    this.int_6 = int_1[num2 - 0x101];
                }
                catch (Exception)
                {
                    throw new SharpZipBaseException("Illegal rep length code");
                }
            Label_00AC:
                if (this.int_6 > 0)
                {
                    this.int_4 = 8;
                    int num3 = this.gclass4_0.initAlign(this.int_6);
                    if (num3 < 0)
                    {
                        return false;
                    }
                    this.gclass4_0.SetAlign(this.int_6);
                    this.int_7 += num3;
                }
                this.int_4 = 9;
            Label_00FC:
                num2 = this.gclass3_1.method_1(this.gclass4_0);
                if (num2 < 0)
                {
                    return false;
                }
                try
                {
                    this.int_8 = int_2[num2];
                    this.int_6 = int_3[num2];
                }
                catch (Exception)
                {
                    throw new SharpZipBaseException("Illegal rep dist code");
                }
            Label_013D:
                if (this.int_6 > 0)
                {
                    this.int_4 = 10;
                    int num4 = this.gclass4_0.initAlign(this.int_6);
                    if (num4 < 0)
                    {
                        return false;
                    }
                    this.gclass4_0.SetAlign(this.int_6);
                    this.int_8 += num4;
                }
                this.gclass6_0.method_2(this.int_7, this.int_8);
                num -= this.int_7;
                this.int_4 = 7;
            }
            return true;
        }

        private bool method_3()
        {
            while (this.int_6 > 0)
            {
                int num = this.gclass4_0.initAlign(8);
                if (num < 0)
                {
                    return false;
                }
                this.gclass4_0.SetAlign(8);
                this.int_5 = (this.int_5 << 8) | num;
                this.int_6 -= 8;
            }
            if (((int) this.gclass2_0.vmethod_0()) != this.int_5)
            {
                throw new SharpZipBaseException(string.Concat(new object[] { "Adler chksum doesn't match: ", (int) this.gclass2_0.vmethod_0(), " vs. ", this.int_5 }));
            }
            this.int_4 = 12;
            return false;
        }

        private bool method_4()
        {
            int num2;
            int num3;
            switch (this.int_4)
            {
                case 0:
                    return this.method_0();

                case 1:
                    return this.method_1();

                case 2:
                    if (!this.bool_0)
                    {
                        int num = this.gclass4_0.initAlign(3);
                        if (num < 0)
                        {
                            return false;
                        }
                        this.gclass4_0.SetAlign(3);
                        if ((num & 1) != 0)
                        {
                            this.bool_0 = true;
                        }
                        switch ((num >> 1))
                        {
                            case 0:
                                this.gclass4_0.init();
                                this.int_4 = 3;
                                break;

                            case 1:
                                this.gclass3_0 = GZipLib.gclass3_0;
                                this.gclass3_1 = GZipLib.gclass3_1;
                                this.int_4 = 7;
                                break;

                            case 2:
                                this.class2_0 = new Process();
                                this.int_4 = 6;
                                break;
                        }
                        throw new SharpZipBaseException("Unknown block type " + num);
                    }
                    if (!this.bool_1)
                    {
                        this.gclass4_0.init();
                        this.int_6 = 0x20;
                        this.int_4 = 11;
                        return true;
                    }
                    this.int_4 = 12;
                    return false;

                case 3:
                    this.int_9 = this.gclass4_0.initAlign(0x10);
                    if (this.int_9 >= 0)
                    {
                        this.gclass4_0.SetAlign(0x10);
                        this.int_4 = 4;
                        goto Label_0162;
                    }
                    return false;

                case 4:
                    goto Label_0162;

                case 5:
                    goto Label_01A4;

                case 6:
                    if (this.class2_0.method_0(this.gclass4_0))
                    {
                        this.gclass3_0 = this.class2_0.method_1();
                        this.gclass3_1 = this.class2_0.method_2();
                        this.int_4 = 7;
                        goto Label_0228;
                    }
                    return false;

                case 7:
                case 8:
                case 9:
                case 10:
                    goto Label_0228;

                case 11:
                    return this.method_3();

                case 12:
                    return false;

                default:
                    throw new SharpZipBaseException("Inflater.Decode unknown mode");
            }
            //return true;
        Label_0162:
            num2 = this.gclass4_0.initAlign(0x10);
            if (num2 < 0)
            {
                return false;
            }
            this.gclass4_0.SetAlign(0x10);
            if (num2 != (this.int_9 ^ 0xffff))
            {
                throw new SharpZipBaseException("broken uncompressed block");
            }
            this.int_4 = 5;
        Label_01A4:
            num3 = this.gclass6_0.method_3(this.gclass4_0, this.int_9);
            this.int_9 -= num3;
            if (this.int_9 == 0)
            {
                this.int_4 = 2;
                return true;
            }
            return !this.gclass4_0.isover();
        Label_0228:
            return this.method_2();
        }

        public void method_5(byte[] byte_0, int int_12, int int_13)
        {
            this.gclass4_0.UpdateData(byte_0, int_12, int_13);
            this.int_11 += int_13;
        }

        public int method_6(byte[] byte_0, int int_12, int int_13)
        {
            if (byte_0 == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if (int_13 < 0)
            {
                throw new ArgumentOutOfRangeException("count", "count cannot be negative");
            }
            if (int_12 < 0)
            {
                throw new ArgumentOutOfRangeException("offset", "offset cannot be negative");
            }
            if ((int_12 + int_13) > byte_0.Length)
            {
                throw new ArgumentException("count exceeds buffer bounds");
            }
            if (int_13 == 0)
            {
                if (!this.method_9())
                {
                    this.method_4();
                }
                return 0;
            }
            int num = 0;
            goto Label_00C5;
        Label_0061:
            if (!this.method_4() && ((this.gclass6_0.method_5() <= 0) || (this.int_4 == 11)))
            {
                return num;
            }
        Label_00C5:
            if (this.int_4 == 11)
            {
                goto Label_0061;
            }
            int num2 = this.gclass6_0.method_6(byte_0, int_12, int_13);
            if (num2 <= 0)
            {
                goto Label_0061;
            }
            this.gclass2_0.vmethod_2(byte_0, int_12, num2);
            int_12 += num2;
            num += num2;
            this.int_10 += num2;
            int_13 -= num2;
            if (int_13 != 0)
            {
                goto Label_0061;
            }
            return num;
        }

        public bool method_7()
        {
            return this.gclass4_0.isover();
        }

        public bool method_8()
        {
            return ((this.int_4 == 1) && (this.int_6 == 0));
        }

        public bool method_9()
        {
            return ((this.int_4 == 12) && (this.gclass6_0.method_5() == 0));
        }
    }
}

