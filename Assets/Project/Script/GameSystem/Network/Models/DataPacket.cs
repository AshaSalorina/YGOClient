using Egan.Constants;
using System;

namespace Egan.Models
{
    /// <summary>
    /// 自定义协议YGOP的数据包
    ///  +——--------——+——-----------——+——------------——+——-------——+
    ///  |  版本号(4)  |  消息类型(4)  |  魔数校验码(4)  |  长度(4)  |
    ///  +——--------——+——-----------——+——------------——+——-------——+
    ///  |                  JSON数据(UNKNOW)                       |
    ///  +——-----------------------------------------------------——+
    /// </summary>
    public class DataPacket
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
        public DataPacket(String body, MessageType type)
        {
            this.version = YGOP.VERSION;
            this.type = type;
            this.magic = YGOP.MAGIC;
            this.body = body;
        }

        public DataPacket(float version, 
            MessageType type, int magic, int len, string body)
        {
            this.version = version;
            this.type = type;
            this.magic = magic;
            this.len = len;
            this.body = body;
        }

        /// <summary>
        /// 版本号
        /// </summary>
        public float Version
        {
            get
            {
                return version;
            }

            set
            {
                version = value;
            }
        }

        /// <summary>
        /// 类型
        /// </summary>
        public MessageType Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        /// <summary>
        /// 魔数
        /// </summary>
        public int Magic
        {
            get
            {
                return magic;
            }

            set
            {
                magic = value;
            }
        }

        /// <summary>
        /// 消息体长度
        /// </summary>
        public int Len
        {
            get
            {
                return len;
            }

            set
            {
                len = value;
            }
        }

        /// <summary>
        /// json消息体
        /// </summary>
        public string Body
        {
            get
            {
                return body;
            }

            set
            {
                body = value;
            }
        }

        
    }
}
