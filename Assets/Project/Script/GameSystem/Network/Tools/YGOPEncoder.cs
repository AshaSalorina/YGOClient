using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Egan.Constants;
using Egan.Models;

namespace Egan.Tools
{
    /// <summary>
    /// YGOP数据包编码器
    /// </summary>
    public class YGOPEncoder
    {
        public static byte[] Encoder(YGOPDataPacket packet)
        {
            byte[][] array = ToBytesArray(packet);
            return Compose(array);
        }

        /// <summary>
        /// 将所有属性转换为字节数组
        /// </summary>
        /// <param name="packet">数据包</param>
        /// <returns>若干个字节数组</returns>
        private static byte[][] ToBytesArray(YGOPDataPacket packet)
        {
            byte[][] bytesArray = new byte[ProtocolConstant.PART_COUNT][];

            bytesArray[ProtocolConstant.VERSION_ORDER] = BitConverter.GetBytes(packet.Version);
            bytesArray[ProtocolConstant.TYPE_ORDER] = BitConverter.GetBytes((int)packet.Type);
            bytesArray[ProtocolConstant.MAGIC_ORDER] = BitConverter.GetBytes(packet.Magic);
            bytesArray[ProtocolConstant.BODY_ORDER] = System.Text.UTF8Encoding.Default.GetBytes(packet.Body);
            bytesArray[ProtocolConstant.LEN_ORDER] = BitConverter.GetBytes(bytesArray[4].Length);

            return bytesArray;
        }

        private static byte[] Compose(byte[][] bytesArray)
        {
            int len = 0;
            foreach(byte[] bytes in bytesArray)
                len += bytes.Length;
            byte[] total = new byte[len];
            bytesArray[ProtocolConstant.VERSION_ORDER].CopyTo(total, ProtocolConstant.VERSION_POS);
            bytesArray[ProtocolConstant.TYPE_ORDER].CopyTo(total, ProtocolConstant.TYPE_POS);
            bytesArray[ProtocolConstant.MAGIC_ORDER].CopyTo(total, ProtocolConstant.MAGIC_POS);
            bytesArray[ProtocolConstant.LEN_ORDER].CopyTo(total, ProtocolConstant.LEN_POS);
            bytesArray[ProtocolConstant.BODY_ORDER].CopyTo(total,ProtocolConstant.BODY_POS);

            return total;
        }
    }
}
