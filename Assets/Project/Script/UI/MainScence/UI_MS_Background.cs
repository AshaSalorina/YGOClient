using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Asha.Tools;
namespace Asha
{

    public class UI_MS_Background : MonoBehaviour
    {
        static UI_MS_Background obj;

        void Start()
        {
            obj = this;
            Refresh();
        }

        /// <summary>
        /// 刷新背景图
        /// </summary>
        public static void Refresh()
        {
            if (Setting.MS_Background_URL != null && Setting.MS_Background_URL != "")
            {
                obj.StartCoroutine(ImageHelper.LoadImage(gameObject, Setting.MS_Background_URL, ImageHelper.LoadImageType.WebOrLocal));
            }
            else
            {
                obj.StartCoroutine(ImageHelper.LoadImage(gameObject, "Images/UI/Backgrounds/df1", ImageHelper.LoadImageType.Resources));
            }
        }


    }
}

