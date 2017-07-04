namespace About
{
    using System;
    using System.Runtime.InteropServices;

    internal static class StrongName
    {
        public static readonly byte[] byte_0 = new byte[] { 0x3e, 3, 15, 0x21, 0xba, 0xd9, 0xeb, 6 };

        public static byte[] smethod_0(string string_0)
        {
            byte[] buffer2;
            IntPtr zero = IntPtr.Zero;
            IntPtr pcbStrongNameToken = IntPtr.Zero;
            try
            {
                int num=0;
                int num2;
                StrongNameTokenFromAssemblyEx(string_0, out pcbStrongNameToken, out num2, ref zero, ref num);
                byte[] destination = new byte[num2];
                Marshal.Copy(pcbStrongNameToken, destination, 0, num2);
                buffer2 = destination;
            }
            catch
            {
                buffer2 = null;
            }
            finally
            {
                if (zero != IntPtr.Zero)
                {
                    StrongNameFreeBuffer(zero);
                }
                if (pcbStrongNameToken != IntPtr.Zero)
                {
                    StrongNameFreeBuffer(pcbStrongNameToken);
                }
            }
            return buffer2;
        }

        [DllImport("mscoree.dll", CharSet=CharSet.Auto)]
        private static extern void StrongNameFreeBuffer(IntPtr intptr_0);
        [DllImport("mscoree.dll", CharSet=CharSet.Auto)]
        private static extern bool StrongNameTokenFromAssemblyEx([MarshalAs(UnmanagedType.LPWStr)] string wszFilePath, [MarshalAs(UnmanagedType.U4)] out IntPtr pcbStrongNameToken, [MarshalAs(UnmanagedType.U4)] out int pcbPublicKeyBlob, ref IntPtr intptr_0, ref int int_0);
    }
}

