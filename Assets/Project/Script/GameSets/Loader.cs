﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Asha
{
    public class Loader : MonoBehaviour
    {
        private void Awake()
        {
            Load();
        }

        public static void Load()
        {
            #region 配置文件载入
            try
            {
                FileStream fS = new FileStream($"{Application.dataPath}/StreamingAssets/Setting.ygo", FileMode.OpenOrCreate);
                StreamReader sR = new StreamReader(fS);
                while (sR.Peek() != -1)
                {
                    Options.MS_Background_URL = sR.ReadLine();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            #endregion

            #region 路径实例化和预载入
            Options.MainScence = GameObject.Find("MainScence");

            /*
            GameObject pl_menu = Instantiate(Resources.Load<GameObject>(@"Prefabs\UI\MainScence\pl_menu"));
            pl_menu.transform.SetParent(Options.MainScence.transform);
            pl_menu.transform.localPosition = new Vector3(0, 0, 0);
            pl_menu.transform.localScale = new Vector3(1, 1, 1);
            */
            Options.Menu = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\MainScence\pl_menu"),Options.MainScence,new Vector3(0,0,0),new Vector3(1,1,1),false);
            //pl_menu.SetActive(false);


            Options.GameCenter = GameObject.Find("GameCenter");
            Options.CardsSet = GameObject.Find("CardsSet");
            Options.Game2D = GameObject.Find("Game2D");
            Options.Game3D = GameObject.Find("Game2D");
            #endregion
        }


        public static void Save()
        {
            try
            {
                FileStream fS = new FileStream($"{Application.dataPath}/StreamingAssets/Setting.ygo", FileMode.OpenOrCreate);
                StreamWriter sW = new StreamWriter(fS);

                sW.WriteLine(Options.MS_Background_URL);


            }
            catch (System.Exception)
            {

                throw;
            }

        }
    }
}

