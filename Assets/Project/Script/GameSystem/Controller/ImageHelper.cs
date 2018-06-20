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
            /// <summary>
            /// www协议或者file协议
            /// </summary>
            WebOrLocal,
            /// <summary>
            /// 工程资源文件
            /// </summary>
            Resources,
            /// <summary>
            /// 通过String字串转化为Byte来加载
            /// </summary>
            Byte
        }

        /// <summary>
        /// 载入图片
        /// </summary>
        /// <param name="obj">目标对象</param>
        /// <param name="img">地址</param>
        /// <param name="tp">载入类型</param>
        /// <param name="width">图片宽度</param>
        /// <param name="height">图片高度</param>
        /// <returns></returns>
        public static IEnumerator LoadImage(GameObject obj, string img, LoadImageType tp = LoadImageType.Byte, int width = 256,int height = 256)
        {

            switch (tp)
            {
                case LoadImageType.WebOrLocal:
                    WWW wLink = new WWW(img);
                    yield return wLink;

                    Texture2D t2D = wLink.texture;
                    if (t2D == null)
                    {
                        wLink = new WWW("file://" + img);
                        yield return wLink;
                        t2D = wLink.texture;
                    }
                    if (t2D != null)
                    {
                        Sprite sprite = Sprite.Create(t2D, new Rect(0, 0, t2D.width, t2D.height), new Vector2(0.5f, 0.5f));
                        obj.GetComponent<Image>().sprite = sprite;
                    }
                    else
                    {
                        WarningBox.Show("输入的可能不是图片,如果是网页图片,请加上协议");
                    }

                    break;
                case LoadImageType.Resources:
                    try
                    {
                        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>(img);
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                    break;
                case LoadImageType.Byte:
                    try
                    {
                        var sp = ConvertHelper.ConvertSTI(img);
                        obj.GetComponent<Image>().sprite = sp;
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
