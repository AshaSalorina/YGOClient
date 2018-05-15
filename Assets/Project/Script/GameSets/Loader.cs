using System.Collections;
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
            Options.MainCanvas = GameObject.Find("Canvas");
            Options.MainScence = GameObject.Find("MainScence");

            Options.Menu = InstantiateHelper.InsObj( Resources.Load<GameObject>(@"Prefabs\UI\MainScence\pl_menu"),Options.MainScence, "pl_menu", false);
            //Options.Menu = GameObject.Find("pl_menu");
            //Options.Menu.SetActive(false);
            Options.GameCenter = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\GameCenter\GameCenter"), Options.MainCanvas, "GameCenter", false);
            Options.GameCenter.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);

            //Options.GameCenter = GameObject.Find("GameCenter");
            //Options.GameCenter.SetActive(false);


            Options.Optionpl = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\MainScence\pl_Options"), Options.MainScence, "pl_Options", false);
            //Options.Optionpl = GameObject.Find("pl_Options");
            //Options.Optionpl.SetActive(false);

            Options.CardsSet = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\CardSet\CardsSet"), Options.MainCanvas, "CardsSet", false);
            Options.CardsSet.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
            //Options.CardsSet = GameObject.Find("CardsSet");
            //Options.CardsSet.SetActive(false);
            Options.Game2D = GameObject.Find("Game2D");
            Options.Game2D.SetActive(false);
            Options.Game3D = GameObject.Find("Game3D");
            Options.Game3D.SetActive(false);
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

