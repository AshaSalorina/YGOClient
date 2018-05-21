using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asha.Tools
{
    /// <summary>
    /// 调节滚动框大小，和Layout配合使用
    /// </summary>
    public class ScrollHelper
    {
        public enum Type
        {
            KeepX,
            KeepY
        }
        public static void AutoSetContentSize(GameObject obj)
        {
            int ct = obj.transform.childCount;
            LayoutGroup lygp = obj.transform.GetComponent<LayoutGroup>();
            int xScaping;
            Vector2 v2 = new Vector2();
            Vector2 v2r = new Vector2();
            for (int i = 0; i < ct; i++)
            {
                v2r = obj.transform.GetChild(i).GetComponent<RectTransform>().sizeDelta;
                v2.x += v2r.x;
                v2.y += v2r.y;
            }
            
            obj.GetComponent<RectTransform>().sizeDelta = v2;
        }

        public static void SetContentSize(GameObject obj, int pScaping, int cellSize, Type type = Type.KeepX)
        {
            int ct = obj.transform.childCount;
            Vector2 v2 = obj.GetComponent<RectTransform>().sizeDelta;
            obj.GetComponent<RectTransform>().sizeDelta = new Vector2(v2.x, ct * (pScaping + cellSize));
        }

    }

}
