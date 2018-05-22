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

        IEnumerator CreatRoom()
        {
            try
            {
                var room = new Room();
                room.Host = Options.player;
                room.Name = "FUckKonami";
                //......
                Options.client.CreateRoom(room);
            }
            catch (System.Exception e)
            {
                Debug.Log(e.ToString());
            }

            yield return null;
        }
    }
}


