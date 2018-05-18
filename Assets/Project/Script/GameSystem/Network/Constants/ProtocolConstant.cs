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
        public static readonly float version = 1.0F;
        /// <summary>
        /// 魔数字典
        /// 根据版本号查看魔数
        /// </summary>
        public static readonly int MAGIC = 0x3cb;
        /// <summary>
        /// 最大内容长度
        /// </summary>
        public static readonly int MAX_LEN = 1024;
    }
}
