using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Asha.Tools;

namespace Asha
{
    public class WarningBox : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            transform.Find("Button").GetComponent<Button>().onClick.AddListener(()=> {
                Destroy(gameObject);
            });
        }

        /// <summary>
        /// 显示一个警告信息
        /// </summary>
        /// <param name="msg">要显示的信息</param>
        public static void Show(string msg)
        {
            var obj = InstantiateHelper.InsObj(Resources.Load<GameObject>("Prefabs/UI/MessageBox/warningBox"),Options.MainCanvas,"WarningBox");
            obj.transform.Find("Text").GetComponent<Text>().text = msg;
        }

    }
}

