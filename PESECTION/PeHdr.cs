namespace PESECTION
{
    using MainMoudle;
    using PE;
    using System;
    using System.IO;

    internal sealed class PeHdr : GBufBase
    {
        private Section[] section;
        private OptionalHdr class5_0;
        private FileHdr class7_0;
        private DosHdr class8_0;
        private long long_2;

        public PeHdr(BinaryReader binaryReader_0)
        {
            base.method_1(0);
            this.class8_0 = new DosHdr(binaryReader_0);
            binaryReader_0.BaseStream.Position = this.class8_0.method_3();
            if (binaryReader_0.ReadUInt32() != 0x4550)
            {
                throw new Exception("File is not a portable executable.");
            }
            this.class7_0 = new FileHdr(binaryReader_0);
            this.long_2 = binaryReader_0.BaseStream.Position + this.class7_0.method_4();
            this.class5_0 = new OptionalHdr(binaryReader_0);
            binaryReader_0.BaseStream.Position = this.long_2;
            this.section = new Section[this.class7_0.method_3()];
            for (int i = 0; i < this.section.Length; i++)
            {
                this.section[i] = new Section(binaryReader_0);
            }
            base.method_2(binaryReader_0.BaseStream.Position);
        }

        public Section[] method_3()
        {
            return this.section;
        }
    }
}

