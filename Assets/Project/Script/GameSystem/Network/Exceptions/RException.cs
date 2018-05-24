using System;

namespace Egan.Exceptions
{
    /// <summary>
    /// 自定义异常
    /// </summary>
    public class RException : ApplicationException
    {
        public RException() { }

        public RException(string message) : base(message) { }

        public RException(string message, Exception inner) : base(message, inner) { }
    }
}
