namespace ICSharpCode.SharpZipLib
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class SharpZipBaseException : ApplicationException
    {
        public SharpZipBaseException()
        {
        }

        public SharpZipBaseException(string string_0) : base(string_0)
        {
        }

        protected SharpZipBaseException(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0) : base(serializationInfo_0, streamingContext_0)
        {
        }
    }
}

