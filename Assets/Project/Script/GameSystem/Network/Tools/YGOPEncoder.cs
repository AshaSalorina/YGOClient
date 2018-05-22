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
        public static byte[] Encoder(DataPacket packet)
        {
            Console.WriteLine(packet.Body);
            byte[][] array = ToBytesArray(packet);
            return Compose(array);
        }

        /// <summary>
        /// 将所有属性转换为字节数组
        /// </summary>
        /// <param name="packet">数据包</param>
        /// <returns>若干个字节数组</returns>
        private static byte[][] ToBytesArray(DataPacket packet)
        {
            byte[][] bytesArray = new byte[YGOP.PART_COUNT][];

            bytesArray[YGOP.VERSION_ORDER] = BitConverter.GetBytes(YGOP.VERSION);
            Array.Reverse(bytesArray[YGOP.VERSION_ORDER]);

            bytesArray[YGOP.TYPE_ORDER] = BitConverter.GetBytes((int)packet.Type);
            Array.Reverse(bytesArray[YGOP.TYPE_ORDER]);

            bytesArray[YGOP.MAGIC_ORDER] = BitConverter.GetBytes(packet.Magic);
            Array.Reverse(bytesArray[YGOP.MAGIC_ORDER]);

            bytesArray[YGOP.BODY_ORDER] = 
                System.Text.Encoding.UTF8.GetBytes(packet.Body);

            bytesArray[YGOP.LEN_ORDER] = 
                BitConverter.GetBytes(bytesArray[YGOP.BODY_ORDER].Length);
            Array.Reverse(bytesArray[YGOP.LEN_ORDER]);

            return bytesArray;
        }

        private static byte[] Compose(byte[][] bytesArray)
        {
            int len = 0;
            foreach(byte[] bytes in bytesArray)
                len += bytes.Length;
            byte[] total = new byte[len];
            bytesArray[YGOP.VERSION_ORDER].CopyTo(total, YGOP.VERSION_POS);
            bytesArray[YGOP.TYPE_ORDER].CopyTo(total, YGOP.TYPE_POS);
            bytesArray[YGOP.MAGIC_ORDER].CopyTo(total, YGOP.MAGIC_POS);
            bytesArray[YGOP.LEN_ORDER].CopyTo(total, YGOP.LEN_POS);
            bytesArray[YGOP.BODY_ORDER].CopyTo(total,YGOP.BODY_POS);

            return total;
        }
    }
}
