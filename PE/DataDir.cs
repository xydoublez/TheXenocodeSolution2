namespace PE
{
    using MainMoudle;
    using System;
    using System.IO;

    internal sealed class DataDir : GBufBase
    {
        private string Name;
        private uint Offset;
        private uint Value;

        public DataDir(BinaryReader binaryReader_0, string string_1)
        {
            base.method_1(binaryReader_0.BaseStream.Position);
            base.method_2(8);
            this.Name = string_1;
            this.Offset = binaryReader_0.ReadUInt32();
            this.Value = binaryReader_0.ReadUInt32();
        }

        public uint method_3()
        {
            return this.Offset;
        }

        public uint method_4()
        {
            return this.Value;
        }

        public string method_5()
        {
            return this.Name;
        }

        public override string ToString()
        {
            string[] strArray = new string[] { base.ToString(), " ", this.method_5(), " points to {", this.method_3().ToString("X8"), " - ", (this.method_3() + this.method_4()).ToString("X8"), "}" };
            return string.Concat(strArray);
        }
    }
}

