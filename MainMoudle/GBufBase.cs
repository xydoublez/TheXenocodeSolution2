namespace MainMoudle
{
    using System;

    public abstract class GBufBase
    {
        private long long_0;
        private long long_1;

        protected GBufBase()
        {
        }

        public long method_0()
        {
            return this.long_0;
        }

        public void method_1(long long_2)
        {
            this.long_0 = long_2;
        }

        public void method_2(long long_2)
        {
            this.long_1 = long_2;
        }

        public override string ToString()
        {
            string[] strArray = new string[] { base.GetType().Name, "  {", this.long_0.ToString("X8"), " - ", (this.long_1 + this.long_0).ToString("X8"), "}" };
            return string.Concat(strArray);
        }
    }
}

