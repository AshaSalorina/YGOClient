using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Asha
{
    public class Options
    {

        #region 全局字段
        /// <summary>
        /// 背景图片的地址（URL）
        /// </summary>
        public static string MS_Background_URL = "";

        /// <summary>
        /// 音量大小
        /// </summary>
        public static int AudioLaude;


        #endregion

        #region 全局路径

        public static GameObject MainCanvas;

        public static GameObject MainScence;
        public static GameObject Menu;
        public static GameObject GameCenter;
        public static GameObject CardsSet;
        public static GameObject Game2D;
        public static GameObject Optionpl;
        public static GameObject Game3D;

        /// <summary>
        /// 声音源
        /// </summary>
        public static GameObject AudioSource;
        #endregion


    }
}


