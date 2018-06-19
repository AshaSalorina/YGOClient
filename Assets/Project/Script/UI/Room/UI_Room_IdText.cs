using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asha
{
    public class UI_Room_IdText : MonoBehaviour
    {

        void Start()
        {
            gameObject.GetComponent<Text>().text = RoomInfo.Id.ToString();
        }

    }

}
