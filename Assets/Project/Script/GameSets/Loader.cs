using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Asha.Tools;
using Egan.Controllers;
using Egan.Models;

namespace Asha
{
    public class Loader : MonoBehaviour
    {
        private void Awake()
        {
            Load();
            Application.wantsToQuit += ShutDownGracefully;
        }

        bool ShutDownGracefully()
        {
            Options.client.ShutDownGracefully();//断开连接
            return true;
        }

        public void Load()
        {
            
            #region 配置文件载入
            try
            {
                FileStream fS = new FileStream($"{Application.dataPath}/StreamingAssets/Setting.ygo", FileMode.OpenOrCreate);
                StreamReader sR = new StreamReader(fS);
                while (sR.Peek() != -1)
                {
                    Options.backgroundURL = sR.ReadLine();
                }
                sR.Close();
                fS.Close();             
            }
            catch (System.Exception e)
            {
                Debug.Log(e.ToString());
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
            /*
            Options.Game2D = GameObject.Find("Game2D");
            Options.Game2D.SetActive(false);
            Options.GameArea = GameObject.Find("GameArea");
            Options.GameArea.SetActive(false);
            */
            #endregion

            #region 建立玩家对象

            Options.player = new Player();
            try
            {
                FileStream fS2 = new FileStream($"{Application.dataPath}/StreamingAssets/player.ygo", FileMode.OpenOrCreate);
                BinaryReader bR = new BinaryReader(fS2);
                if (bR.PeekChar() != -1)
                {
                    Options.player.Name = bR.ReadString();
                    Options.player.Head = bR.ReadString();

                }

                bR.Close();
                fS2.Close();
            }
            catch (System.Exception)
            {
                throw;
            }

            #endregion

            #region 网络连接

            Options.client = new NetworkClient();

            #endregion
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        public void Save()
        {
            try
            {
                #region 配置文件
                FileStream fS = new FileStream($"{Application.dataPath}/StreamingAssets/Setting.ygo", FileMode.OpenOrCreate);
                StreamWriter sW = new StreamWriter(fS);
                sW.WriteLine(Options.backgroundURL);

                #endregion

                #region 玩家信息文件
                FileStream fS2 = new FileStream($"{Application.dataPath}/StreamingAssets/player.ygo", FileMode.OpenOrCreate);
                var bW = new BinaryWriter(fS2);
                bW.Write(Options.player.Name);
                bW.Write(Options.player.Head);
                #endregion
            }
            catch (System.Exception)
            {

                throw;
            }

        }



    }
}

