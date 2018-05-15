using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
