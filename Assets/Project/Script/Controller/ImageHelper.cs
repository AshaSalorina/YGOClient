using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asha.Tools
{
    public class ImageHelper
    {
        /// <summary>
        /// 载入图片的方式
        /// </summary>
        public enum LoadImageType
        {
            WebOrLocal,
            Resources
        }

        /// <summary>
        /// 载入图片
        /// </summary>
        /// <param name="obj">目标对象</param>
        /// <param name="url">地址</param>
        /// <param name="tp">载入类型</param>
        /// <returns></returns>
        public static IEnumerator LoadImage(GameObject obj, string url, LoadImageType tp)
        {

            switch (tp)
            {
                case LoadImageType.WebOrLocal:
                    WWW wLink = new WWW(url);
                    yield return wLink;
                    try
                    {
                        Texture2D t2D = wLink.texture;
                        Sprite sprite = Sprite.Create(t2D, new Rect(0, 0, t2D.width, t2D.height), new Vector2(0.5f, 0.5f));
                        obj.GetComponent<Image>().sprite = sprite;
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                    break;
                case LoadImageType.Resources:
                    try
                    {
                        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>(url);
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                    break;
                default:
                    break;
            }
        }
    }

}
