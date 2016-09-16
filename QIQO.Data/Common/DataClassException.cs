using System;
using System.Runtime.Serialization;

namespace QIQO.Data
{
    [Serializable]
    public class DataClassException : Exception
    {
        public DataClassException()
        : base()
        { }

        public DataClassException(string message)
            : base(message)
        { }

        public DataClassException(string format, params object[] args)
            : base(string.Format(format, args))
        { }

        public DataClassException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public DataClassException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        { }

        protected DataClassException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
