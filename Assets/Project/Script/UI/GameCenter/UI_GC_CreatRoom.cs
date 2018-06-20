using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Egan.Controllers;
using Egan.Models;

namespace Asha
{
    /// <summary>
    /// In CreatRoom
    /// </summary>
    public class UI_GC_CreatRoom : MonoBehaviour
    {
        void Start()
        {
            transform.Find("RoomName").GetComponent<InputField>().text = "新的房间";

            transform.Find("OK").GetComponent<Button>().onClick.AddListener(() =>
            {
                StopAllCoroutines();
                CreatRoom();
            });

            transform.Find("Canel").GetComponent<Button>().onClick.AddListener(() =>
            {
                Destroy(gameObject);
            });
        }

        private void OnDisable()
        {
            //StopAllCoroutines();
        }

        void CreatRoom()
        {
            var room = new Room();
            room.Host = Options.player;
            room.Name = transform.Find("RoomName").GetComponent<InputField>().text;

            if (room.Name == "" || room.Name == null)
            {
                WarningBox.Show("房间名不能为空");
                StopAllCoroutines();
                return;
            }

            room.Password = "";
            room.Password = transform.Find("RoomPassword").GetComponent<InputField>().text;
            room.HasPwd = room.Password != null && room.Password != "" ? true : false;
            room.Desc = transform.Find("RoomDes").GetComponent<InputField>().text;

            //预先注册房间名
            RoomInfo.Name = room.Name;

            Options.client.CreateRoom(room);
            //开始监听创建房间的消息
            Options.YGOWaiter.Switch(Egan.Constants.MessageType.CREATE, true);
            //todo:打开一个转圈圈的panel
            //销毁自身
            Destroy(gameObject);
        }
    }
}


