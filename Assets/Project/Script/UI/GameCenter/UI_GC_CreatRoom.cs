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
                StartCoroutine(CreatRoom());
            });

            transform.Find("Canel").GetComponent<Button>().onClick.AddListener(() =>
            {
                Destroy(gameObject);
            });
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        IEnumerator CreatRoom()
        {

            var room = new Room();
            room.Host = Options.player;
            room.Name = transform.Find("RoomName").GetComponent<InputField>().text;

            if (room.Name == "" || room.Name == null)
            {
                WarningBox.Show("房间名不能为空");
                StopAllCoroutines();
            }

            room.Password = "";
            room.Password = transform.Find("RoomPassword").GetComponent<InputField>().text;
            room.HasPwd = room.Password != null && room.Password != "" ? true : false;
            room.Desc = transform.Find("RoomDes").GetComponent<InputField>().text;

            yield return new WaitForSeconds(0.1f);

            try
            {
                room.Id = Options.client.CreateRoom(room);
            }
            catch (System.Exception e)
            {
                WarningBox.Show(e.ToString());
                Destroy(gameObject);
            }

            yield return new WaitForSeconds(0.1f);

            Options.EventSystem.SendMessage("CreatRoom", room);
            Destroy(gameObject);
        }
    }
}


