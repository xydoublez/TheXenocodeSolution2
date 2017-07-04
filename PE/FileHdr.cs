namespace PE
{
    using MainMoudle;
    using System;
    using System.IO;

    internal sealed class FileHdr : GBufBase
    {
        private uint TimeDateStamp;
        private uint PtrToSym;
        private uint NUmOfSym;
        private ushort Machine;
        private ushort NumOfSection;
        private ushort SizeOfOptHdr;
        private ushort Characteristic;

        public FileHdr(BinaryReader binaryReader_0)
        {
            base.method_1(binaryReader_0.BaseStream.Position);
            base.method_2(20);
            this.Machine = binaryReader_0.ReadUInt16();
            this.NumOfSection = binaryReader_0.ReadUInt16();
            this.TimeDateStamp = binaryReader_0.ReadUInt32();
            this.PtrToSym = binaryReader_0.ReadUInt32();
            this.NUmOfSym = binaryReader_0.ReadUInt32();
            this.SizeOfOptHdr = binaryReader_0.ReadUInt16();
            this.Characteristic = binaryReader_0.ReadUInt16();
        }

        public ushort method_3()
        {
            return this.NumOfSection;
        }

        public ushort method_4()
        {
            return this.SizeOfOptHdr;
        }
    }
}

