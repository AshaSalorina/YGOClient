using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egan.Constants
{
    /// <summary>
    /// YGOP协议的其他常量
    /// </summary>
    public class ProtocolConstant
    {
        /// <summary>
        /// 当前版本
        /// </summary>
        static readonly double version = 1.0;
        /// <summary>
        /// 魔数
        /// </summary>
        static readonly int MAGIC =  0x48;
        /// <summary>
        /// 最大内容长度
        /// </summary>
        static readonly int MAX_LEN = 1024;
    }
}
