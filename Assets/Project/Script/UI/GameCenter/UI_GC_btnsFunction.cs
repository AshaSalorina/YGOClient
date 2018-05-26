using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Asha.Tools;

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
            var obj = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\GameCenter\CreatRoom"), Options.GameCenter, "CreatRoom");
        }

        void JoinRoom()
        {

        }

        void RandomJoin()
        {

        }
    }
}

