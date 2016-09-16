using System;
using System.Runtime.Serialization;

namespace QIQO.Common.Core
{
    [Serializable]
    public class NotFoundException : Exception
    {

        public NotFoundException()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception exception)
            : base(message, exception)
        {
        }

        public NotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}


//public class NotFoundException
//{
//    string _message;
//    Exception _exception;

//    public string Message
//    {
//        get { return _message; }
//    }

//    public NotFoundException()
//    {
//    }

//    public NotFoundException(string message)
//    //: base(message)
//    {
//        _message = message;
//    }

//    public NotFoundException(string message, Exception exception)
//    //: base(message, exception)
//    {
//        _message = message;
//        _exception = exception;
//    }

//    //public NotFoundException(SerializationInfo info, StreamingContext context)
//    //    //: base(info, context)
//    //{

//    //}
//}
