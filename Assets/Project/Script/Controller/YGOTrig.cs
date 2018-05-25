using Egan.Models;
using Egan.Constants;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace Asha.Tools
{
    /// <summary>
    /// 消息触发器，用于分发消息和构建消息队列
    /// </summary>
    public class YGOTrig
    {
        /// <summary>
        /// 消息缓冲池
        /// </summary>
        public static Dictionary<MessageType, List<DataPacket>> Packets;

        public static void Load()
        {
            foreach (MessageType item in Enum.GetValues(typeof(MessageType)))
            {
                if (!Packets.ContainsKey(item))
                {
                    Packets.Add(item, new List<DataPacket>());
                }

            }
        }

        /// <summary>
        /// 分发消息包
        /// </summary>
        /// <param name="packet">消息包</param>
        public static void Distribute(DataPacket packet)
        {
            Packets[packet.Type].Add(packet);
        }

    }
}
