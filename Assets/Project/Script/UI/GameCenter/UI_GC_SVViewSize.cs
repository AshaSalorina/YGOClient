using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asha
{
    public class UI_GC_SVViewSize : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Refresh();
        }

        /// <summary>
        /// 刷新房间控件的大小
        /// </summary>
        void Refresh()
        {
            int ct = gameObject.transform.childCount;
            Vector2 v2 = gameObject.GetComponent<RectTransform>().sizeDelta;
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(v2.x, ct * 105);
        }


    }
}


