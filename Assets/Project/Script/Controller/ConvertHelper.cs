using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asha.Tools
{
    /// <summary>
    /// 目前统一采用UTF8编码的转换器
    /// </summary>
    public class ConvertHelper
    {

        /// <summary>
        /// Convert String to Byte[]
        /// </summary>
        public static byte[] ConvertSTB(string str)
        {
            return  System.Text.Encoding.UTF8.GetBytes(str);
        }


        /// <summary>
        /// Convert Byte[] to String
        /// </summary>
        public static string ConvertBTS(byte[] bt)
        {
            return System.Text.Encoding.UTF8.GetString(bt);
        }

        /// <summary>
        /// Convert String to Image
        /// </summary>
        public static Sprite ConvertSTI(string str, int width = 256, int height = 256)
        {
            var bt = ConvertSTB(str);
            return ConvertBTI(bt);
        }

        /// <summary>
        /// Convert Byte[] to Image
        /// </summary>
        public static Sprite ConvertBTI(byte[] bt, int width = 256, int height = 256)
        {
            Texture2D td = new Texture2D(width, height);
            td.LoadImage(bt);
            return Sprite.Create(td, new Rect(0, 0, td.width, td.height), MathCommonData.ZVector3);
        }


    }
}

