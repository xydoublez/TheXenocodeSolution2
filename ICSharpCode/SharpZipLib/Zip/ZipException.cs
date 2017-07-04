namespace ICSharpCode.SharpZipLib.Zip
{
    using ICSharpCode.SharpZipLib;
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public sealed class ZipException : SharpZipBaseException
    {
        public ZipException(string string_0) : base(string_0)
        {
        }

        private ZipException(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
            : base(serializationInfo_0, streamingContext_0)
        {
        }
    }
}

