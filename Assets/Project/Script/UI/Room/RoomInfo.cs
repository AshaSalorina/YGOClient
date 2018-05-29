using Egan.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Asha.Tools;
using Newtonsoft.Json;

namespace Asha
{
    /// <summary>
    /// In EventSystem
    /// </summary>
    public class RoomInfo : MonoBehaviour
    {

        static int selected;
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
        bool customIn = false;

        public void CreatRoom(Room rm)
        {

            Options.GameCenter.SetActive(false);

            Options.isRoomMaster = true;
            Options.Room = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\Room\Room"), Options.MainCanvas, MathCommonData.ZVector3, MathCommonData.EVector3, "Room", true);

            #region 房主信息载入
            Options.Room.transform.Find("Self").Find("Name").GetComponent<Text>().text = Options.player.Name;
            if (Options.player.Head != null && Options.player.Head != "")
            {
                Options.Room.transform.Find("Self").Find("Head").GetComponent<Text>().text = Options.player.Head;
            }
            #endregion

            #region 等待房客
            StartCoroutine(WaitForCustomAndRoomMessage());
            #endregion

        }

        public void JoinRoom(Room rm)
        {
            Options.GameCenter.SetActive(false);
            Options.isRoomMaster = false;
            Options.Room = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\Room\Room"), Options.MainCanvas, MathCommonData.ZVector3, MathCommonData.EVector3, "Room", true);

            #region 房主信息载入
            Options.Room.transform.Find("Self").Find("Name").GetComponent<Text>().text = Options.player.Name;
            if (Options.player.Head != null && Options.player.Head != "")
            {
                Options.Room.transform.Find("Self").Find("Head").GetComponent<Text>().text = Options.player.Head;
            }
            #endregion

        }

        /// <summary>
        /// 玩家主动离开房间
        /// </summary>
        public void LeaveRoom()
        {
            StopAllCoroutines();
            //Options.client.LeaveRoom();
            Options.GameCenter.SetActive(true);
            Destroy(Options.Room);
        }


        /// <summary>
        /// 游戏开始
        /// </summary>
        public void GameBegin()
        {

        }


        /// <summary>
        /// 循环消息机,等待房客加入和获取房间中聊天信息
        /// </summary>
        /// <returns></returns>
        IEnumerator WaitForCustomAndRoomMessage()
        {
            while (true)
            {
                //一个join必然对应一个leave
                if (!customIn)
                {
                    if (YGOTrig.Packets[Egan.Constants.MessageType.JOIN].Count > 0)
                    {
                        var custom = JsonConvert.DeserializeObject<Player>(
                            YGOTrig.Packets[Egan.Constants.MessageType.JOIN][0].Body);
                        #region 写入玩家数据

                        Options.Room.transform.Find("Other").Find("Name").GetComponent<Text>().text = custom.Name;
                        ImageHelper.LoadImage(Options.Room.transform.Find("Other").Find("Head").gameObject, custom.Head,ImageHelper.LoadImageType.Byte);
                        #endregion
                        customIn = true;
                    }
                }
                else
                {
                    if (YGOTrig.Packets[Egan.Constants.MessageType.LEAVE].Count > 0)
                    {
                        #region 清空玩家数据

                        Options.Room.transform.Find("Other").Find("Name").GetComponent<Text>().text = "NoPlayer";
                        Options.Room.transform.Find("Other").Find("Head").GetComponent<Text>().text = "";


                        #endregion
                        customIn = false;
                    }
                }

                yield return new WaitForFixedUpdate();
            }

        }

    }
}

