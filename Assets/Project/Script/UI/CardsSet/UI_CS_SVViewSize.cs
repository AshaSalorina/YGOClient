using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asha
{
    public class UI_CS_SVViewSize : MonoBehaviour
    {
        public GameObject ViewPort;
        // Update is called once per frame
        void Update()
        {
            Refresh();
        }

        //todo:加入tools套餐
        /// <summary>
        /// 刷新控件的大小
        /// </summary>
        void Refresh()
        {
            int ct = ViewPort.transform.childCount;
            var len = GetComponent<RectTransform>().sizeDelta.x;
            var glg = ViewPort.GetComponent<GridLayoutGroup>();
            float i = len > (ct / glg.constraintCount) * (glg.cellSize.x + glg.spacing.x) ? 0 : (ct / glg.constraintCount) * (glg.cellSize.x + glg.spacing.x) - len;
            var v2 = new Vector2(i, 0);
            ViewPort.GetComponent<RectTransform>().sizeDelta = v2;
        }
    }
}


