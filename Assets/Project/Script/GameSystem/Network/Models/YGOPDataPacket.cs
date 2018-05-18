using Egan.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Egan.Models
{
    /// <summary>
    /// 自定义协议YGOP的数据包
    ///  +——--------——+——-----------——+——------------——+——-------——+
    ///  |  版本号(4)  |  消息类型(4)  |  魔数校验码(4)  |  长度(4)  |
    ///  +——--------——+——-----------——+——------------——+——-------——+
    ///  |                      JSON数据(UNKNOW)                   |
    ///  +——-----------------------------------------------------——+
    /// </summary>
    public class YGOPDataPacket
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
        /// 消息体长度
        /// </summary>
        private int len;

        /// <summary>
        /// json消息体
        /// </summary>
        private String body;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="body">消息体</param>
        /// <param name="type">消息类型</param>
        public YGOPDataPacket(String body, MessageType type)
        {
            this.version = ProtocolConstant.version;
            this.type = type;
            this.magic = ProtocolConstant.MAGIC;
            this.body = body;
        }
    }
}
