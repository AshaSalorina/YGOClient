using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Asha.Tools;
namespace Asha
{

    public class UI_MS_Background : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            if (Setting.MS_Background_URL != null && Setting.MS_Background_URL != "")
            {
                StartCoroutine(ImageHelper.LoadImage(gameObject, Setting.MS_Background_URL, ImageHelper.LoadImageType.WebOrLocal));
                //StartCoroutine(ImageHelper.LoadImage(gameObject, "E:/YGOClient/Assets/Project/Resources/Images/Backgrounds/df1.jpg", ImageHelper.LoadImageType.WebOrLocal));
            }
            else
            {
                StartCoroutine(ImageHelper.LoadImage(gameObject, "Images/Backgrounds/df1", ImageHelper.LoadImageType.Resources));
            }
        }
    }
}

