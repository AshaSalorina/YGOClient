using Egan.Models;
using Egan.Constants;
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
        public Dictionary<MessageType, List<DataPacket>> Packets;

        /// <summary>
        /// 分发消息包
        /// </summary>
        /// <param name="packet">消息包</param>
        public void Distribute(DataPacket packet)
        {

            Packets[packet.Type].Add(packet);
        }

    }
}
