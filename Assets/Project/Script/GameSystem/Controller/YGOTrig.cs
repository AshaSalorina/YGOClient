﻿using Egan.Models;
using Egan.Constants;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Newtonsoft.Json;
using Egan.Tools;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

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
                            OnGetRooms();
                            break;
                        case MessageType.CREATE:
                            OnCreat();
                            break;
                        case MessageType.JOIN:
                            OnJoin();
                            break;
                        case MessageType.LEAVE:
                            OnLeave();
                            break;
                        case MessageType.KICK_OUT:
                            break;
                        case MessageType.READY:
                            break;
                        case MessageType.STARTED:
                            break;
                        case MessageType.COUNT_DOWN:
                            OnCountDown();
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
            PacketsSwitch = new Dictionary<MessageType, bool>();
            foreach (MessageType item in Enum.GetValues(typeof(MessageType)))
            {
                if (!Packets.ContainsKey(item))
                {
                    Packets.Add(item, new List<DataPacket>());
                    PacketsSwitch.Add(item, false);
                }

            }
        }

        #endregion

        #region 分发消息包和开关
        /// <summary>
        /// 分发消息包
        /// </summary>
        /// <param name="packet">消息包</param>
        public void Distribute(DataPacket packet)
        {
            Packets[packet.Type].Add(packet);
        }

        /// <summary>
        /// 控制某类开关
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public void Switch(MessageType msg, bool e)
        {
            PacketsSwitch[msg] = e;
        }
        #endregion

        #region 具体处理

        /// <summary>
        /// 获取房间列表的处理
        /// </summary>
        void OnGetRooms()
        {
            if (Packets[MessageType.GET_ROOMS].Count > 0)
            {
                UI_GC_SVViewSize.rooms = PacketExp.ExpGetRooms(Packets[MessageType.GET_ROOMS][0]);
                Switch(MessageType.GET_ROOMS, false);
                Packets[MessageType.GET_ROOMS].RemoveRange(0, 1);
            }
        }

        /// <summary>
        /// 加入房间的处理
        /// </summary>
        void OnJoin()
        {
            if (RoomInfo.IsMaster)
            {
                //房主应该做什么
                if (Packets[MessageType.JOIN].Count > 0)
                {
                    //WarningBox.Show(Packets[MessageType.JOIN].Count.ToString());
                    var custom = PacketExp.ExpHJoin(Packets[MessageType.JOIN][0]);
                    #region 写入玩家数据

                    Options.Room.transform.Find("Other").Find("Name").GetComponent<Text>().text = custom.Name;
                    ImageHelper.LoadImage(Options.Room.transform.Find("Other").Find("Head").gameObject, custom.Head, ImageHelper.LoadImageType.Byte);

                    #endregion
                    //移除过时消息
                    Packets[MessageType.JOIN].RemoveRange(0, 1);
                    RoomInfo.CustomIn = true;
                    //打开leave和ready监听,并关闭join监听
                    Switch(MessageType.LEAVE, true);
                    Switch(MessageType.READY, true);
                    Switch(MessageType.JOIN, false);
                }
            }
            else
            {
                //房客应该做什么
                if (Packets[MessageType.JOIN].Count > 0)
                {
                    var room = PacketExp.ExpGJoin(Packets[MessageType.JOIN][0]);
                    #region 写入玩家数据

                    Options.EventSystem.SendMessage("JoinRoom", room);
                    #endregion
                    //移除过时消息
                    Packets[MessageType.JOIN].RemoveRange(0, 1);
                    RoomInfo.CustomIn = true;
                    Switch(MessageType.LEAVE, true);
                    Switch(MessageType.READY, true);
                    Switch(MessageType.JOIN, false);
                }
            }
        }


        void OnLeave()
        {
            if (RoomInfo.IsMaster)
            {
                if (Packets[MessageType.LEAVE].Count > 0)
                {
                    //WarningBox.Show(Packets[MessageType.LEAVE].Count.ToString());
                    #region 清空玩家数据

                    Options.Room.transform.Find("Other").Find("Name").GetComponent<Text>().text = "NoPlayer";
                    Options.Room.transform.Find("Other").Find("Head").GetComponent<Image>().sprite = null;
                    WarningBox.Show("ClearPlayer");
                    #endregion
                    //移除过时消息
                    Packets[MessageType.LEAVE].RemoveRange(0, 1);
                    RoomInfo.CustomIn = false;
                    //打开join监听,并关闭leave监听
                    Switch(MessageType.JOIN, true);
                    Switch(MessageType.READY, false);
                    Switch(MessageType.LEAVE, false);
                    WarningBox.Show("OpenJoinList");
                }
            }
            else
            {
                if (Packets[MessageType.LEAVE].Count > 0)
                {
                    Switch(MessageType.LEAVE, false);
                    Options.EventSystem.SendMessage("DestroyRoom");
                    WarningBox.Show("房主关闭了房间");
                    Packets[MessageType.LEAVE].RemoveRange(0, 1);
                }

            }
        }

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
                        //停止监听join消息
                        Switch(MessageType.JOIN, false);
                        WarningBox.Show("密码错误");
                        break;
                    case StatusCode.PLAYING:
                        //拒绝加入
                        WarningBox.Show("房间已开始游戏");
                        break;
                    case StatusCode.UNPREPARED:
                        //todo
                        break;
                    case StatusCode.DISMISSED:
                        //拒绝加入
                        WarningBox.Show("房间已解散");
                        break;
                    case StatusCode.FULL_LOBBY:
                        //拒绝并中断创建房间
                        Switch(MessageType.CREATE, false);
                        WarningBox.Show("大厅已满");
                        break;
                    case StatusCode.FULL_ROOM:
                        //拒绝加入
                        WarningBox.Show("房间已满");
                        break;
                    default:
                        WarningBox.Show("未知的错误");
                        break;
                }
            }
            Packets[MessageType.WARRING].Clear();
        }

        void OnCreat()
        {
            if (Packets[MessageType.CREATE].Count > 0) 
            {
                //var room = PacketExp.ExpCreate(Packets[MessageType.CREATE][0]);
                //确认创建房间成功,通知事件系统创建房间
                Options.EventSystem.SendMessage("CreatRoom");
                //清空队列
                Packets[MessageType.CREATE].Clear();
            }
        }

        void OnCountDown()
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}