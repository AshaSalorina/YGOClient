﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Asha.Tools;
using Egan.Models;

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
            Room rm = null;
            try
            {
                //todo:密码
               rm = Options.client.JoinRoom(RoomInfo.Selected,Options.player);
            }
            catch (System.Exception e)
            {
                WarningBox.Show(e.ToString());
            }
            Options.EventSystem.SendMessage("JoinRoom",rm);
        }

        void RandomJoin()
        {

        }
    }
}
