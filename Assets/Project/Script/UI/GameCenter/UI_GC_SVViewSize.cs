using Egan.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Asha.Tools;
using Egan.Models;

namespace Asha
{
    public class UI_GC_SVViewSize : MonoBehaviour
    {
        public static List<Room> rooms;

        private void Awake()
        {
            rooms = new List<Room>();
        }

        private void OnEnable()
        {
            //携程启动
            StartCoroutine(RefreshRoomList());
        }
        
        private void OnDisable()
        {
            //携程维护
            StopAllCoroutines();
        }


        private void OnDestroy()
        {
            //携程维护
            StopAllCoroutines();
        }

        /// <summary>
        /// 刷新房间控件的大小
        /// </summary>
        void Refresh()
        {
            int ct = gameObject.transform.childCount;
            Vector2 v2 = gameObject.GetComponent<RectTransform>().sizeDelta;
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(v2.x, ct * 105);    
        }


        public IEnumerator RefreshRoomList()
        {
            while (true)
            {
                //清空过期列表
                rooms.Clear();
                Options.client.GetRooms();
                Options.YGOWaiter.Switch(Egan.Constants.MessageType.GET_ROOMS, true);
                //等待rooms被载入
                int outofFrame = 1000;
                while (rooms.Count == 0)
                {
                    yield return new WaitForFixedUpdate();
                    outofFrame--;
                    if (outofFrame == 0)
                    {
                        WarningBox.Show("连接超时");
                        break;
                    }
                }
                if (outofFrame == 0)
                {
                    continue;
                }
                //移除旧的列表
                for (int i = 0; i < transform.childCount; i++)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
                foreach (var item in rooms)
                {
                    //等待一帧
                    yield return new WaitForFixedUpdate();
                    GameObject obj = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\GameCenter\room"), gameObject);
                    obj.GetComponent<Toggle>().onValueChanged.AddListener(var =>
                    {
                        RoomInfo.Selected = var ? item.Id : -1;
                    });
                    obj.transform.Find("ID").GetComponent<Text>().text = item.Id.ToString();
                    obj.name = item.Name;
                    obj.transform.Find("Name").GetComponent<Text>().text = item.Name;
                    obj.transform.Find("Host").GetComponent<Text>().text = item.Host.Name;
                    obj.transform.Find("Desc").GetComponent<Text>().text = item.Desc;
                }
                //更新控件框大小
                Refresh();
                //等待30s
                yield return new WaitForSeconds(30f);
            }

        }


    }
}


