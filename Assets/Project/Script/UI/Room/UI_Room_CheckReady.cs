using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Asha.Tools;
using Egan.Constants;

namespace  Asha
{
    public class UI_Room_CheckReady : MonoBehaviour
    {
        /// <summary>
        /// 是否允许玩家按下按钮
        /// </summary>
        static bool readyActive = false;

        Button btn;

        public static GameObject obj;

        /// <summary>
        /// 是否允许玩家按下按钮
        /// </summary>
        public static bool ReadyActive
        {
            get
            {
                return readyActive;
            }

            set
            {
                readyActive = value;
            }
        }
        
        void Start()
        {
            obj = gameObject;
            btn = GetComponent<Button>();
            Options.YGOWaiter.Switch(MessageType.STARTED, true);
            Options.YGOWaiter.Switch(MessageType.READY, true);
            readyActive = RoomInfo.IsMaster ? false : true;

            btn.onClick.AddListener(() =>
            {
                if (RoomInfo.IsMaster)
                {
                    //host
                    if (RoomInfo.IsReady)//确认准备状态
                    {
                        readyActive = false;
                        Options.client.ChangeStatus(true);
                    }
                }
                else
                {
                    //custom
                    readyActive = false;
                    Options.client.ChangeStatus(false);                  
                }

                StartCoroutine(WaitOutOfTime());

            });
        }

        void Update()
        {
            btn.enabled = readyActive;
        }

        /// <summary>
        /// 得到准备状态变更信息
        /// </summary>
        public void GetReady()
        {
            readyActive = !readyActive;
            RoomInfo.IsReady = !RoomInfo.IsReady;

            //取消超时监听
            StopAllCoroutines();
        }

        /// <summary>
        /// 得到开始成功信息
        /// </summary>
        public void GetStart()
        {
            //Options.YGOWaiter.Switch(MessageType.READY, false);
            readyActive = false;//锁死准备按钮
            //取消超时监听
            StopAllCoroutines();
            //监听倒计时
            Options.YGOWaiter.Switch(MessageType.COUNT_DOWN, true);
            //计算超时
            //StartCoroutine(WaitOutOfTime());
        }

        /// <summary>
        /// 倒计时到0
        /// </summary>
        public void ToStart()
        {
            Options.EventSystem.SendMessage("AGameBegin");
            //Options.YGOWaiter.Switch(MessageType.COUNT_DOWN, false);
            StopAllCoroutines();
        }


        /// <summary>
        /// 因为超时而解锁[准备/开始]按钮
        /// </summary>
        void ShutDown()
        {
            if (RoomInfo.IsMaster)
            {
                if (RoomInfo.IsReady)
                {
                    readyActive = true;
                }
            }
            else
            {
                readyActive = true;
            }
        }

        /// <summary>
        /// 超时
        /// </summary>
        IEnumerator WaitOutOfTime()
        {
            yield return new WaitForSeconds(10);
            ShutDown();
        }


    }
}

