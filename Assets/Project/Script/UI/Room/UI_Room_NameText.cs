using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asha
{

    public class UI_Room_NameText : MonoBehaviour
    {
        void Start()
        {
            gameObject.GetComponent<Text>().text = RoomInfo.Name;
        }

    }

}
