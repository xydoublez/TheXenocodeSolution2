namespace PESECTION
{
    using MainMoudle;
    using System;
    using System.IO;

    internal sealed class Section : GBufBase
    {
        private string string_0;
        private uint uint_0;
        private uint uint_1;
        private uint uint_2;
        private uint uint_3;
        private uint uint_4;
        private uint uint_5;
        private uint uint_6;
        private ushort ushort_0;
        private ushort ushort_1;

        public Section(BinaryReader binaryReader_0)
        {
            base.method_1(binaryReader_0.BaseStream.Position);
            base.method_2(40);
            for (int i = 0; i < 8; i++)
            {
                byte num2 = binaryReader_0.ReadByte();
                if (num2 != 0)
                {
                    this.string_0 = this.string_0 + ((char) num2);
                }
            }
            this.uint_0 = binaryReader_0.ReadUInt32();
            this.uint_1 = binaryReader_0.ReadUInt32();
            this.uint_2 = binaryReader_0.ReadUInt32();
            this.uint_3 = binaryReader_0.ReadUInt32();
            this.uint_4 = binaryReader_0.ReadUInt32();
            this.uint_5 = binaryReader_0.ReadUInt32();
            this.ushort_0 = binaryReader_0.ReadUInt16();
            this.ushort_1 = binaryReader_0.ReadUInt16();
            this.uint_6 = binaryReader_0.ReadUInt32();
        }

        public string method_3()
        {
            return this.string_0;
        }

        public uint method_4()
        {
            return this.uint_1;
        }

        public uint method_5()
        {
            return this.uint_2;
        }

        public uint method_6()
        {
            return this.uint_3;
        }

        public override string ToString()
        {
            string[] strArray = new string[] { base.ToString(), " ", this.method_3(), " raw data at offsets {", this.method_6().ToString("X8"), " - ", (this.method_6() + this.method_5()).ToString("X8"), "}" };
            return string.Concat(strArray);
        }
    }
}

