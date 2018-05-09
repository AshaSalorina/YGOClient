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
            }
            else
            {
                // StartCoroutine(ImageHelper.LoadImage(gameObject, "/Images/Backgrounds/default.jpg", ImageHelper.LoadImageType.Resources));
                gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("/Images/Backgrounds/default.jpg");
            }
        }
    }
}

