using System;
using System.Runtime.Serialization;

namespace QIQO.Data
{
    [Serializable]
    public class MapException : Exception
    {
        public MapException()
        : base()
        { }

        public MapException(string message)
            : base(message)
        { }

        public MapException(string format, params object[] args)
            : base(string.Format(format, args))
        { }

        public MapException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public MapException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        { }

        protected MapException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}