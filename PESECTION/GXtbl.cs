namespace PESECTION
{
    using System;

    public sealed class GXtbl
    {
        private static readonly byte[] byte_0 = new byte[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 };
        private static byte[] byte_1 = new byte[0x11e];
        private static byte[] byte_2;
        private static readonly int[] int_0 = new int[] { 
            0x10, 0x11, 0x12, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 
            14, 1, 15
         };
        private static short[] short_0 = new short[0x11e];
        private static short[] short_1;

        static GXtbl()
        {
            int index = 0;
            while (index < 0x90)
            {
                short_0[index] = smethod_0((0x30 + index) << 8);
                byte_1[index++] = 8;
            }
            while (index < 0x100)
            {
                short_0[index] = smethod_0((0x100 + index) << 7);
                byte_1[index++] = 9;
            }
            while (index < 280)
            {
                short_0[index] = smethod_0((-256 + index) << 9);
                byte_1[index++] = 7;
            }
            while (index < 0x11e)
            {
                short_0[index] = smethod_0((-88 + index) << 8);
                byte_1[index++] = 8;
            }
            short_1 = new short[30];
            byte_2 = new byte[30];
            for (index = 0; index < 30; index++)
            {
                short_1[index] = smethod_0(index << 11);
                byte_2[index] = 5;
            }
        }

        public static short smethod_0(int int_1)
        {
            return (short) ((((byte_0[int_1 & 15] << 12) | (byte_0[(int_1 >> 4) & 15] << 8)) | (byte_0[(int_1 >> 8) & 15] << 4)) | byte_0[int_1 >> 12]);
        }
    }
}

