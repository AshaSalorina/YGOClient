using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asha
{
    public class UI_CS_SVViewSize : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            Refresh();
        }

        /// <summary>
        /// 刷新控件的大小
        /// </summary>
        void Refresh()
        {
            int ct = gameObject.transform.childCount;
            if (ct <= 12)
            {
                gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 17);
            }
            else
            {
                var v2 = new Vector2((105 + ((ct - 13) / 2) * (180 + 50)), 17);
                gameObject.GetComponent<RectTransform>().sizeDelta = v2;
                    
            }
        }
    }
}


