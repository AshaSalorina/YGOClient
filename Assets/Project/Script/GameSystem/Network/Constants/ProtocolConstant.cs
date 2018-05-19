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
        /// 协议开始标志
        /// </summary>
        public static readonly int START_MARK = 0x97;

        /// <summary>
        /// 当前版本
        /// </summary>
        public static readonly float VERSION = 1.0F;
        /// <summary>
        /// 魔数
        /// </summary>
        public static readonly int MAGIC = 0x3cb;
        /// <summary>
        /// 数据包头的固定长度
        /// </summary>
        public static readonly int HEAD_LEN = 16;
        /// <summary>
        /// 最大内容长度
        /// </summary>
        public static readonly int MAX_LEN = 1024;
        /// <summary>
        /// 协议的段数
        /// </summary>
        public static readonly int PART_COUNT = 6;


        /// <summary>
        /// 开始标志所占长度
        /// </summary>
        public static readonly int START_LEN = 4;
        /// <summary>
        /// 版本所占字节数
        /// </summary>
        public static readonly int VERSION_LEN = 4;
        /// <summary>
        /// 消息类型所占字节数
        /// </summary>
        public static readonly int TYPE_LEN = 4;
        /// <summary>
        /// 魔数所占字节数
        /// </summary>
        public static readonly int MAGIC_LEN = 4;
        /// <summary>
        /// 消息体长度所占字节数
        /// </summary>
        public static readonly int LEN_LEN = 4;
        /// <summary>
        /// 开始标志的顺序
        /// </summary>
        public static readonly int START_ORDER = 0;
        /// <summary>
        /// 版本的顺序
        /// </summary>
        public static readonly int VERSION_ORDER = START_LEN + 1;
        /// <summary>
        /// 类型的顺序
        /// </summary>
        public static readonly int TYPE_ORDER = VERSION_ORDER + 1;
        /// <summary>
        /// 魔数的顺序
        /// </summary>
        public static readonly int MAGIC_ORDER = TYPE_ORDER + 1;
        /// <summary>
        /// 消息体长度的顺序
        /// </summary>
        public static readonly int LEN_ORDER = MAGIC_ORDER + 1;
        /// <summary>
        /// 消息体的顺序
        /// </summary>
        public static readonly int BODY_ORDER = LEN_ORDER + 1;
        /// <summary>
        /// 开始协议的位置
        /// </summary>
        public static readonly int START_POS = 0;
        /// <summary>
        /// 版本的位置
        /// </summary>
        public static readonly int VERSION_POS = START_POS + START_LEN;
        /// <summary>
        /// 类型的位置
        /// </summary>
        public static readonly int TYPE_POS = VERSION_POS + VERSION_LEN;
        /// <summary>
        /// 魔数的位置
        /// </summary>
        public static readonly int MAGIC_POS = TYPE_POS + TYPE_LEN;
        /// <summary>
        /// 消息体长度的位置
        /// </summary>
        public static readonly int LEN_POS = MAGIC_POS + MAGIC_POS;
        /// <summary>
        /// 消息体的位置
        /// </summary>
        public static readonly int BODY_POS = LEN_POS + LEN_LEN;
    }
}
