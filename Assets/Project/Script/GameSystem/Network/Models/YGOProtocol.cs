using Egan.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egan.Models
{
    /// <summary>
    /// 自定义协议YGOP
    ///  +——---——+——------——+——--------——+——---——+——-------——+
    ///  | 版本号 | 消息类型 |  魔数校验码 |  长度  |  json数据 |
    ///  +——---——+——------——+——--------——+——---——+——-------——+
    /// </summary>
    public class YGOProtocol
    {
        /// <summary>
        /// 版本号
        /// </summary>
        private float version;

        /// <summary>
        /// 类型
        /// </summary>
        private MessageType type;

        /// <summary>
        /// 魔数
        /// </summary>
        private int magic;

        /// <summary>
        /// 协议体长度
        /// </summary>
        private int len;

        /// <summary>
        /// json协议体
        /// </summary>
        private string body;

    }
}
