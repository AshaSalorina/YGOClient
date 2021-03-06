﻿using UnityEngine;
using UnityEngine.UI;
using Asha.Tools;
using Newtonsoft.Json;
using System;
using Egan.Constants;
using Egan.Models;
using System.Collections;
using System.Collections.Generic;

namespace Asha
{
    /// <summary>
    /// In EventSystem
    /// </summary>
    public class RoomInfo : MonoBehaviour
    {
        static int id;
        static int selected;
        static bool customIn = false;
        static bool isMaster;
        static bool isReady = false;
        static string roomName = "DefRoom";

        /// <summary>
        /// 选中的Togle
        /// </summary>
        public static int Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
            }
        }

        /// <summary>
        /// 客人进房
        /// </summary>
        public static bool CustomIn
        {
            get
            {
                return customIn;
            }
            set
            {
                customIn = value;
            }
        }

        /// <summary>
        /// 是否为房主
        /// </summary>
        public static bool IsMaster
        {
            get
            {
                return isMaster;
            }
        }

        public static bool IsReady
        {
            get
            {
                return isReady;
            }

            set
            {
                isReady = value;
            }
        }

        public static int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public static string Name
        {
            get
            {
                return roomName;
            }

            set
            {
                roomName = value;
            }
        }

        /// <summary>
        /// 玩家创建了一个房间
        /// </summary>
        public void CreatRoom(object roomID)
        {
            Options.GameCenter.SetActive(false);

            id = (int)roomID;

            isMaster = true;
            Options.Room = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\Room\Room"), Options.MainCanvas, MathCommonData.ZVector3, MathCommonData.EVector3, "Room", true);

            #region 房主信息载入
            Options.Room.transform.Find("Self").Find("Name").GetComponent<Text>().text = Options.player.Name;
            if (Options.player.Head != null && Options.player.Head != "")
            {
                //todo:这里可能有问题,pic是self的子物体的子物体,如果出现bug则需要修改
                ImageHelper.LoadImage(Options.Room.transform.Find("Self").Find("Head").Find("Mask").Find("Pic").gameObject, Options.player.Head);
                //Options.Room.transform.Find("Self").Find("Head").GetComponent<Text>().text = Options.player.Head;
            }
            #endregion

            #region 等待房客
            Options.YGOWaiter.Switch(MessageType.JOIN, true);

            Options.YGOWaiter.Switch(MessageType.CHAT, true);
            //StartCoroutine(WaitForCustomAndRoomMessage());
            #endregion

        }

        /// <summary>
        /// 玩家加入了一个房间
        /// </summary>
        /// <param name="rm"></param>
        public void JoinRoom(object room)
        {
            Options.YGOWaiter.Switch(MessageType.CHAT, true);

            #region 初始化房间
            var rm = (Room)room;
            id = rm.Id;
            Options.GameCenter.SetActive(false);
            isMaster = false;
            Options.Room = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\Room\Room"), Options.MainCanvas, MathCommonData.ZVector3, MathCommonData.EVector3, "Room", true);

            #endregion

            #region 自身信息载入
            Options.Room.transform.Find("Self").Find("Name").GetComponent<Text>().text = Options.player.Name;
            if (Options.player.Head != null && Options.player.Head != "")
            {
                ImageHelper.LoadImage(Options.Room.transform.Find("Self").Find("Head").Find("Mask").Find("Pic").gameObject, Options.player.Head);
                //Options.Room.transform.Find("Self").Find("Head").GetComponent<Text>().text = Options.player.Head;
            }

            Options.Room.transform.Find("Other").Find("Name").GetComponent<Text>().text = rm.Host.Name;
            ImageHelper.LoadImage(Options.Room.transform.Find("Other").Find("Head").gameObject, rm.Host.Head, ImageHelper.LoadImageType.Byte);

            #endregion

        }

        /// <summary>
        /// 玩家主动离开房间
        /// </summary>
        public void LeaveRoom()
        {
            Options.client.Leave();
            DestroyRoom();
        }

        /// <summary>
        /// 玩家被动离开房间
        /// </summary>
        public void BeLeavedRoom()
        {
            Options.YGOWaiter.Switch(MessageType.CHAT, false);
            //Options.YGOWaiter.Switch(MessageType.JOIN, false);
            //Options.client.Leave();
            DestroyRoom();
        }

        /// <summary>
        /// 房间被异常销毁
        /// </summary>
        public void DestroyRoom()
        {
            selected = 0;

            Options.YGOWaiter.Switch(MessageType.JOIN, true);
            Options.YGOWaiter.Switch(MessageType.CREATE, true);

            Options.YGOWaiter.Switch(MessageType.CHAT, false);
            Options.YGOWaiter.Switch(MessageType.STARTED, false);
            Options.YGOWaiter.Switch(MessageType.LEAVE, false);
            Options.YGOWaiter.Switch(MessageType.COUNT_DOWN, false);

            Options.GameCenter.SetActive(true);
            if (Options.Room != null)
            {
                Destroy(Options.Room);
            }
            if (Options.GameArea != null)
            {
                Destroy(Options.GameArea);
                Options.client.ReconnectLobby();
            }
        }

        /// <summary>
        /// 游戏开始
        /// </summary>
        public void AGameBegin()
        {
            //转到决斗服务器
            Options.client.Duel(Id, IsMaster);
            //创建决斗场景
            Options.GameArea = InstantiateHelper.InsObj(Resources.Load<GameObject>("Prefabs/UI/GameArea/GameArea"), GameObject.Find("GACanvas").gameObject, "GameArea");
            //obj.GetComponent<Canvas>().GetComponent<Camera>() = GameObject.Find("UICamera").GetComponent<Camera>();
            //移除房间
            Destroy(Options.Room);
        }


        /// <summary>
        /// 循环消息机,等待房客加入和获取房间中聊天信息
        /// 已弃用,请使用Options.YGOWaiter.Switch(msgtype,bool)来打开消息机
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        IEnumerator WaitForCustomAndRoomMessage()
        {
            while (true)
            {
                //一个join必然对应一个leave
                if (!CustomIn)
                {
                    if (YGOTrig.Packets[Egan.Constants.MessageType.JOIN].Count > 0)
                    {
                        var custom = JsonConvert.DeserializeObject<Player>(
                            YGOTrig.Packets[Egan.Constants.MessageType.JOIN][0].Body);
                        #region 写入玩家数据

                        Options.Room.transform.Find("Other").Find("Name").GetComponent<Text>().text = custom.Name;
                        ImageHelper.LoadImage(Options.Room.transform.Find("Other").Find("Head").gameObject, custom.Head,ImageHelper.LoadImageType.Byte);

                        #endregion
                        //移除过时消息
                        YGOTrig.Packets[Egan.Constants.MessageType.JOIN].RemoveRange(0, 1);
                        customIn = true;
                    }
                }
                else
                {
                    if (YGOTrig.Packets[Egan.Constants.MessageType.LEAVE].Count > 0)
                    {
                        #region 清空玩家数据

                        Options.Room.transform.Find("Other").Find("Name").GetComponent<Text>().text = "NoPlayer";
                        Options.Room.transform.Find("Other").Find("Head").GetComponent<Image>().sprite = null;

                        #endregion
                        //移除过时消息
                        YGOTrig.Packets[Egan.Constants.MessageType.LEAVE].RemoveRange(0, 1);
                        customIn = false;
                    }
                }
                yield return new WaitForFixedUpdate();
            }

        }

    }
}

