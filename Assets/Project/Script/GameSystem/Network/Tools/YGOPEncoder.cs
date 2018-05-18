using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            byte[][] bytesArray = new byte[5][];

            bytesArray[0] = BitConverter.GetBytes(packet.Version);
            bytesArray[1] = BitConverter.GetBytes((int)packet.Type);
            bytesArray[2] = BitConverter.GetBytes(packet.Magic);
            bytesArray[4] = System.Text.UTF8Encoding.Default.GetBytes(packet.Body);
            bytesArray[3] = BitConverter.GetBytes(bytesArray[4].Length);

            return bytesArray;
        }

        private static byte[] Compose(byte[][] bytesArray)
        {
            int len = 0;
            foreach(byte[] bytes in bytesArray)
                len += bytes.Length;
            byte[] total = new byte[len];
            bytesArray[0].CopyTo(total, 0);
            bytesArray[1].CopyTo(total, 4);
            bytesArray[2].CopyTo(total, 8);
            bytesArray[3].CopyTo(total, 12);
            bytesArray[4].CopyTo(total, 16);

            return total;
        }
    }
}
