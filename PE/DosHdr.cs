namespace PE
{
    using MainMoudle;
    using System;
    using System.IO;

    internal sealed class DosHdr : GBufBase
    {
        private uint e_lfanew;

        public DosHdr(BinaryReader binaryReader_0)
        {
            if (binaryReader_0.ReadUInt16() != 0x5a4d)
            {
                throw new Exception("DOSStub: Invalid DOS header.");
            }
            if (binaryReader_0.BaseStream.Position == 2)
            {
                binaryReader_0.BaseStream.Position = 60;
                this.e_lfanew = binaryReader_0.ReadUInt32();
            }
            else
            {
                Stream baseStream = binaryReader_0.BaseStream;
                baseStream.Position += 0x3a;
                this.e_lfanew = binaryReader_0.ReadUInt32() + (((uint) binaryReader_0.BaseStream.Position) - 0x40);
            }
            base.method_1(0);
            base.method_2(0x40);
        }

        public uint method_3()
        {
            return this.e_lfanew;
        }
    }
}

