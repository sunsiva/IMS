using System;

namespace IMS.DataModel.Common
{
    public struct ModelMessage
    {
        public ModelMessage(string message):this(message, null)
        { }

        public ModelMessage(string message, Exception ex):this()
        {
            this.Message = message;
            this.Exception = ex;
        }

        public string Message
        {
            get;
            set;
        }

        
        public Exception Exception
        {
            get;
            set;             
        }


    }
}
