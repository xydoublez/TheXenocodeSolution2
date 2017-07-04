namespace PESECTION
{
    using System;
    using System.Runtime.InteropServices;

    internal sealed class PeStruct
    {
        internal static long long_0; // data size: 8 bytes
        internal static Struct0 struct0_0; // data size: 16 bytes
        internal static Struct1 struct1_0; // data size: 76 bytes
        internal static Struct1 struct1_1; // data size: 76 bytes
        internal static Struct2 struct2_0; // data size: 12 bytes
        internal static Struct2 struct2_1; // data size: 12 bytes
        internal static Struct3 struct3_0; // data size: 120 bytes
        internal static Struct3 struct3_1; // data size: 120 bytes
        internal static Struct4 struct4_0; // data size: 116 bytes
        internal static Struct4 struct4_1; // data size: 116 bytes

        [StructLayout(LayoutKind.Explicit, Size=0x10, Pack=1)]
        public struct Struct0
        {
        }

        [StructLayout(LayoutKind.Explicit, Size=0x4c, Pack=1)]
        public struct Struct1
        {
        }

        [StructLayout(LayoutKind.Explicit, Size=12, Pack=1)]
        public struct Struct2
        {
        }

        [StructLayout(LayoutKind.Explicit, Size=120, Pack=1)]
        public struct Struct3
        {
        }

        [StructLayout(LayoutKind.Explicit, Size=0x74, Pack=1)]
        public struct Struct4
        {
        }
    }
}

