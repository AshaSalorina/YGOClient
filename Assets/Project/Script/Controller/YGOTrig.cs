using Egan.Models;
using Egan.Constants;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Newtonsoft.Json;
using Egan.Tools;

namespace Asha.Tools
{
    /// <summary>
    /// 消息触发器，用于分发消息和构建消息队列,请通过Options下的消息机对象调用
    /// </summary>
    public class YGOTrig
    {
        #region MonoBehaviour,交给Loader调用

        /// <summary>
        /// 先扫描开关,如果开关被打开,则扫描对应的消息队列
        /// </summary>
        public void Update()
        {
            foreach (MessageType item in Enum.GetValues(typeof(MessageType)))
            {
                if (PacketsSwitch[item])
                {
                    switch (item)
                    {
                        case MessageType.GET_ROOMS:
                            break;
                        case MessageType.CREATE:
                            break;
                        case MessageType.JOIN:
                            break;
                        case MessageType.LEAVE:
                            break;
                        case MessageType.KICK_OUT:
                            break;
                        case MessageType.READY:
                            break;
                        case MessageType.STARTED:
                            break;
                        case MessageType.COUNT_DOWN:
                            break;
                        case MessageType.CHAT:
                            break;
                        case MessageType.DECK:
                            break;
                        case MessageType.FINGER_GUESS:
                            break;
                        case MessageType.OPERATE:
                            break;
                        case MessageType.EXIT:
                            break;
                        case MessageType.GET_VERSION:
                            break;
                        case MessageType.GET_BULLETIN:
                            break;
                        case MessageType.VERITY:
                            break;
                        case MessageType.WARRING:
                            OnWarning();
                            break;
                        default:
                            break;
                    }
                }
            }

        }

        #endregion

        #region Static
        /// <summary>
        /// 消息缓冲池
        /// </summary>
        public static Dictionary<MessageType, List<DataPacket>> Packets;

        /// <summary>
        /// 是否要处理该类消息的开关
        /// </summary>
        public static Dictionary<MessageType, bool> PacketsSwitch;



        public static void Load()
        {
            Packets = new Dictionary<MessageType, List<DataPacket>>();
            foreach (MessageType item in Enum.GetValues(typeof(MessageType)))
            {
                if (!Packets.ContainsKey(item))
                {
                    Packets.Add(item, new List<DataPacket>());
                }

            }
        }

        #endregion

        #region 分发开关
        /// <summary>
        /// 分发消息包
        /// </summary>
        /// <param name="packet">消息包</param>
        public void Distribute(DataPacket packet)
        {
            Packets[packet.Type].Add(packet);
        }

        /// <summary>
        /// 打开某类开关
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public void Switch(MessageType msg, bool e)
        {

        }
        #endregion

        #region 具体处理

        void OnWarning()
        {
            foreach (var item in Packets[MessageType.WARRING])
            {
                var rb = JsonConvert.DeserializeObject<R>(item.Body);
                StatusCode code = (StatusCode)rb.Code;
                switch (code)
                {
                    case StatusCode.INCORRECT:
                        //拒绝加入
                        //弹窗提示
                        break;
                    case StatusCode.PLAYING:
                        //拒绝加入
                        //弹窗提示
                        break;
                    case StatusCode.UNPREPARED:
                        //todo
                        break;
                    case StatusCode.DISMISSED:
                        //拒绝加入
                        //弹窗提示
                        break;
                    case StatusCode.FULL_LOBBY:
                        //拒绝创建房间
                        //弹窗提示
                        break;
                    case StatusCode.FULL_ROOM:
                        //拒绝加入
                        //弹窗提示
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion


    }
}
