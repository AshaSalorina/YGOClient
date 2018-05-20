using Egan.Constants;
using Egan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Egan.Tools
{
    /// <summary>
    /// YGOP解码器
    /// </summary>
    public class YGOPDecoder
    {

        /// <summary>
        /// 外部socket
        /// </summary>
        private Socket socket;

        /// <summary>
        /// 一个数据包的头部缓冲区
        /// </summary>
        private byte[] packetHead = new byte[ProtocolConstant.HEAD_LEN];

        /// <summary>
        /// 一个数据包的消息体缓冲区
        /// </summary>
        private byte[] packetBody;

        /// <summary>
        /// 待接收的头部消息字节数
        /// </summary>
        private int remaingHead = ProtocolConstant.HEAD_LEN;

        /// <summary>
        /// 待接收的消息体字节数
        /// </summary>
        private int remaingBody;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="socket">socket</param>
        public YGOPDecoder(Socket socket)
        {
            this.socket = socket;
        }

        /// <summary>
        /// 接收socket接收的消息，将其还原成一个完整的数据包
        /// </summary>
        /// <returns>是否完全接收一个包</returns>
        public bool ReceivePacket()
        {
            if (ReceiveHead())
            {
                //获取消息体长度
                byte[] lenBytes = new byte[ProtocolConstant.LEN_LEN];
                Array.Copy(packetHead, ProtocolConstant.LEN_POS, lenBytes, 0, ProtocolConstant.LEN_LEN);
                Array.Reverse(lenBytes);
                int len = BitConverter.ToInt32(lenBytes, 0);

                packetBody = new byte[len];
                remaingBody = len;

                if (ReceiveBody())
                    return true;

                return false;
            }

            return false;
        }

        /// <summary>
        /// 接收socket接收的消息，将其还原成一个数据包头
        /// </summary>
        /// <returns>是否完全接收一个数据包头/returns>
        private bool ReceiveHead()
        {
            
            if(remaingHead > 0)
            {
                //此次接收的头部消息字节数
                int receiveHeadCount;
                //此次接收的头部消息
                byte[] currentHead = new byte[ProtocolConstant.HEAD_LEN];
                if (remaingHead >= packetHead.Length)
                {
                    receiveHeadCount = socket.Receive(currentHead, currentHead.Length, 0);
                }
                else
                {
                    receiveHeadCount = socket.Receive(currentHead, remaingHead, 0);
                }

                currentHead.CopyTo(packetHead, currentHead.Length - remaingHead);
                remaingHead -= receiveHeadCount;
            }

            return remaingHead == 0 ? true : false;
        }

        /// <summary>
        /// 接收socket接收的消息，将其还原成一个完整的数据包消息体
        /// </summary>
        /// <returns>是否完全接收一个消息体</returns>
        private bool ReceiveBody()
        {
            if(remaingBody > 0)
            {
                //此次接收的消息体字节数
                int receiveBodyCount;

                //此次接收的消息体
                byte[] currentBody = new byte[packetBody.Length];
                if (remaingBody >= packetBody.Length)
                {
                    receiveBodyCount = socket.Receive(currentBody, currentBody.Length, 0);
                }
                else
                {
                    receiveBodyCount = socket.Receive(currentBody, remaingBody, 0);
                }

                currentBody.CopyTo(packetBody, currentBody.Length - remaingBody);
                remaingBody -= receiveBodyCount;
            }

            return remaingBody == 0 ? true : false;
        }

        /// <summary>
        /// 将数据包头和消息体从字节数组还原成一个数据包对象
        /// </summary>
        /// <returns></returns>
        public DataPacket ParsePacket()
        {
            byte[] versionBytes = new byte[ProtocolConstant.VERSION_LEN];
            byte[] typeBytes = new byte[ProtocolConstant.TYPE_LEN];
            byte[] magicBytes = new byte[ProtocolConstant.MAGIC_LEN];

            Array.Copy(packetHead, ProtocolConstant.VERSION_POS, versionBytes, 0, ProtocolConstant.VERSION_LEN);
            Array.Copy(packetHead, ProtocolConstant.TYPE_POS, typeBytes, 0, ProtocolConstant.TYPE_LEN);
            Array.Copy(packetHead, ProtocolConstant.MAGIC_POS, magicBytes, 0, ProtocolConstant.MAGIC_LEN);

            Array.Reverse(versionBytes);
            Array.Reverse(typeBytes);
            Array.Reverse(magicBytes);

            int version = BitConverter.ToInt32(versionBytes, 0);
            MessageType type = (MessageType)BitConverter.ToInt32(typeBytes, 0);
            int magic = BitConverter.ToInt32(magicBytes, 0);
            int len = packetBody.Length;

            string body = System.Text.Encoding.UTF8.GetString(packetBody);

            //重置待接收的头和消息体字节数
            remaingHead = ProtocolConstant.HEAD_LEN;

            return new DataPacket(version, type, magic, len, body);
        }
    }
}
