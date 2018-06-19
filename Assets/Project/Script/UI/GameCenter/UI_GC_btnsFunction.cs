using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Asha.Tools;
using Egan.Models;
using Egan.Constants;

namespace Asha
{
    /// <summary>
    /// In GameCenter
    /// </summary>
    public class UI_GC_btnsFunction : MonoBehaviour
    {
        void Start()
        {
            transform.Find("btn_CreatRoom").GetComponent<Button>().onClick.AddListener(CreatRoom);
            transform.Find("btn_JoinRoom").GetComponent<Button>().onClick.AddListener(JoinRoom);
            transform.Find("btn_RandomJoin").GetComponent<Button>().onClick.AddListener(RandomJoin);
            transform.Find(" btn_Refresh").GetComponent<Button>().onClick.AddListener(Refresh);
        }

        void CreatRoom()
        {
            var obj = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\GameCenter\CreatRoom"), Options.MainCanvas, "CreatRoom");
        }

        void JoinRoom()
        {
            if (RoomInfo.Selected == -1)
            {
                WarningBox.Show("请选中一个房间");
                return;
            }
            //todo:密码
            Options.client.JoinRoom(RoomInfo.Selected,Options.player);
            //等待加入房间
            Options.YGOWaiter.Switch(MessageType.JOIN, true);
        }

        void RandomJoin()
        {

        }

        void Refresh()
        {
            GameObject.Find("pl_Room").transform.Find("Viewport").SendMessage("RefreshRoomList");
        }

    }
}

