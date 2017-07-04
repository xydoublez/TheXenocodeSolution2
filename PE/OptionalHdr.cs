namespace PE
{
    using MainMoudle;
    using System;
    using System.IO;

    internal sealed class OptionalHdr : GBufBase
    {
        private byte byte_0;
        private byte byte_1;
        private DataDir[] class6_0;
        private uint uint_0;
        private uint uint_1;
        private uint uint_10;
        private uint uint_11;
        private uint uint_12;
        private uint uint_13;
        private uint uint_14;
        private uint uint_15;
        private uint uint_16;
        private uint uint_17;
        private uint uint_18;
        private uint uint_19;
        private uint uint_2;
        private uint uint_3;
        private uint uint_4;
        private uint uint_5;
        private uint uint_6;
        private uint uint_7;
        private uint uint_8;
        private uint uint_9;
        private ushort ushort_0;
        private ushort ushort_1;
        private ushort ushort_2;
        private ushort ushort_3;
        private ushort ushort_4;
        private ushort ushort_5;
        private ushort ushort_6;
        private ushort ushort_7;

        public OptionalHdr(BinaryReader binaryReader_0)
        {
            base.method_1(binaryReader_0.BaseStream.Position);
            this.uint_0 = binaryReader_0.ReadUInt16();
            this.byte_0 = binaryReader_0.ReadByte();
            this.byte_1 = binaryReader_0.ReadByte();
            this.uint_1 = binaryReader_0.ReadUInt32();
            this.uint_2 = binaryReader_0.ReadUInt32();
            this.uint_3 = binaryReader_0.ReadUInt32();
            this.uint_4 = binaryReader_0.ReadUInt32();
            this.uint_5 = binaryReader_0.ReadUInt32();
            this.uint_6 = binaryReader_0.ReadUInt32();
            this.uint_7 = binaryReader_0.ReadUInt32();
            this.uint_8 = binaryReader_0.ReadUInt32();
            this.uint_9 = binaryReader_0.ReadUInt32();
            this.ushort_0 = binaryReader_0.ReadUInt16();
            this.ushort_1 = binaryReader_0.ReadUInt16();
            this.ushort_2 = binaryReader_0.ReadUInt16();
            this.ushort_3 = binaryReader_0.ReadUInt16();
            this.ushort_4 = binaryReader_0.ReadUInt16();
            this.ushort_5 = binaryReader_0.ReadUInt16();
            this.uint_10 = binaryReader_0.ReadUInt32();
            this.uint_11 = binaryReader_0.ReadUInt32();
            this.uint_12 = binaryReader_0.ReadUInt32();
            this.uint_13 = binaryReader_0.ReadUInt32();
            this.ushort_6 = binaryReader_0.ReadUInt16();
            this.ushort_7 = binaryReader_0.ReadUInt16();
            this.uint_14 = binaryReader_0.ReadUInt32();
            this.uint_15 = binaryReader_0.ReadUInt32();
            this.uint_16 = binaryReader_0.ReadUInt32();
            this.uint_17 = binaryReader_0.ReadUInt32();
            this.uint_18 = binaryReader_0.ReadUInt32();
            this.uint_19 = binaryReader_0.ReadUInt32();
            if (this.method_3() < 0x10)
            {
                throw new Exception("PEHeader:  Invalid number of data directories in file header.");
            }
            this.class6_0 = new DataDir[this.method_3()];
            string[] strArray = new string[] { "Export Table", "Import Table", "Resource Table", "Exception Table", "Certificate Table", "Base Relocation Table", "Debug", "Copyright", "Global Ptr", "TLS Table", "Load Config Table", "Bound Import", "IAT", "Delay Import Descriptor", "CLI Header", "Reserved" };
            for (int i = 0; i < this.method_3(); i++)
            {
                this.class6_0[i] = new DataDir(binaryReader_0, (i < 0x10) ? strArray[i] : "Unknown");
            }
            base.method_2(binaryReader_0.BaseStream.Position - base.method_0());
        }

        public uint method_3()
        {
            return this.uint_19;
        }
    }
}

