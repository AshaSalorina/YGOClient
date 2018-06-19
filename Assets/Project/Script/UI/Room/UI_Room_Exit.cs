using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asha
{
    public class UI_Room_Exit : MonoBehaviour
    {
        private void Start()
        {
            //监听退出房间
            GetComponent<Button>().onClick.AddListener(() =>
            {
                Options.EventSystem.SendMessage("LeaveRoom");
            });
        }

    }
}

