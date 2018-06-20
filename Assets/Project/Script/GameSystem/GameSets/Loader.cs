using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Asha.Tools;
using Egan.Controllers;
using Egan.Models;

namespace Asha
{
    /// <summary>
    /// In EventSystem
    /// </summary>
    public class Loader : MonoBehaviour
    {
        private void Awake()
        {
            Load();

            Application.wantsToQuit += ShutDownGracefully;
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        IEnumerator YGOWaiterUpdate()
        {
            while (true)
            {
                Options.YGOWaiter.Update();
                yield return new WaitForFixedUpdate();
            }
        }


        bool ShutDownGracefully()
        {
            if (Options.client != null)
            {
                if (Options.Room != null)
                {
                    Options.client.Leave();
                }
                Options.client.ShutDownGracefully();//断开连接
            }
            return true;
        }

        public void Load()
        {
            
            #region 配置文件载入
            try
            {
                FileStream fS = new FileStream($"{Application.dataPath}/StreamingAssets/Setting.ygo", FileMode.OpenOrCreate);
                StreamReader sR = new StreamReader(fS);
                if (sR.Peek() != -1)
                {
                    Options.backgroundURL = sR.ReadLine();
                }
                sR.Close();
                fS.Close();             
            }
            catch (System.Exception e)
            {
                //Debug.Log(e.ToString());
            }
            #endregion

            #region 路径实例化和预载入
            Options.EventSystem = GameObject.Find("EventSystem");
            Options.MainCanvas = GameObject.Find("Canvas");
            Options.MainScence = GameObject.Find("MainScence");

            Options.Menu = InstantiateHelper.InsObj( Resources.Load<GameObject>(@"Prefabs\UI\MainScence\pl_menu"),Options.MainScence, "pl_menu", false);

            Options.GameCenter = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\GameCenter\GameCenter"), Options.MainCanvas, "GameCenter", false);
            Options.GameCenter.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);

            Options.Optionpl = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\MainScence\pl_Options"), Options.MainScence, "pl_Options", false);

            Options.CardsSet = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\CardSet\CardsSet"), Options.MainCanvas, "CardsSet", false);
            Options.CardsSet.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);

            #endregion

            #region 预制体载入

            Options.warrningBox = Resources.Load<GameObject>("Prefabs/UI/MessageBox/warningBox");

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
                if (Options.player.Name == null || Options.player.Name == "")
                {
                    Options.player.Name = "YGOPlayer";
                }
            }
            catch (System.Exception)
            {
                throw;
            }

            #endregion

        }

        /// <summary>
        /// 玩家点击屏幕第一次后执行
        /// </summary>
        public void NetLoad()
        {
            #region 网络连接和消息分发器激活
            try
            {
                Options.client = new NetworkClient();
                YGOTrig.Load();
                Options.YGOWaiter = new YGOTrig();
                //警告消息常驻
                Options.YGOWaiter.Switch(Egan.Constants.MessageType.WARRING, true);
                StartCoroutine(YGOWaiterUpdate());
            }
            catch (System.Exception e)
            {
                WarningBox.Show(e.ToString());
            }
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

