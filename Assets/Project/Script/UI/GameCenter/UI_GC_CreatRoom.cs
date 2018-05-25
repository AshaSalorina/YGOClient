using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Egan.Controllers;
using Egan.Models;

namespace Asha
{
    public class UI_GC_CreatRoom : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                StopAllCoroutines();
                StartCoroutine(CreatRoom());
            });
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        IEnumerator CreatRoom()
        {
            try
            {
                var room = new Room();
                room.Host = Options.player;
                room.Name = transform.parent.Find("RoomName").GetComponent<InputField>().text;
                room.Password = "";
                room.Password = transform.parent.Find("RoomPassword").GetComponent<InputField>().text;
                room.HasPwd = room.Password != null && room.Password != "" ? true : false;
                room.Desc = transform.parent.Find("RoomDes").GetComponent<InputField>().text;
                Options.client.CreateRoom(room).ToString();
                Options.EventSystem.SendMessage("CreatRoom", room);
                // transform.parent.gameObject.SetActive(false);
            }
            catch (System.Exception e)
            {
                Debug.Log(e.ToString());
            }
            yield return null;
        }
    }
}


