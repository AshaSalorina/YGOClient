using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Asha.Tools;
namespace Asha
{

    public class UI_MS_Background : MonoBehaviour
    {
        void Start()
        {
            Refresh();
        }

        /// <summary>
        /// 刷新背景图
        /// </summary>
        public void Refresh()
        {
            if (Options.backgroundURL != null && Options.backgroundURL != "")
            {
                StartCoroutine(ImageHelper.LoadImage(gameObject, Options.backgroundURL, ImageHelper.LoadImageType.WebOrLocal));
            }
            else
            {
                StartCoroutine(ImageHelper.LoadImage(gameObject, "Images/UI/Backgrounds/df1", ImageHelper.LoadImageType.Resources));
            }
        }


    }
}

