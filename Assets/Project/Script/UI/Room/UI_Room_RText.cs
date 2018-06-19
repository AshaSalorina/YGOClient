using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asha
{
    public class UI_Room_RText : MonoBehaviour
    {
        Text txt;
        
        void Start()
        {
            txt = gameObject.GetComponent<Text>();
        }
        
        void Update()
        {
            if (RoomInfo.IsReady)
            {
                txt.text = "Ready!";
            }
            else
            {
                txt.text = "Not Ready";
            }
        }
    }
}


