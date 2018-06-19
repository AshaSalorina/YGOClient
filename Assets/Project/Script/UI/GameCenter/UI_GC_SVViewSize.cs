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
        /// <summary>
        /// 用于搜索的暂定筛选器,表示房间ID,之后加入筛选期后做改动
        /// </summary>
        public static int CheckID = 0;

        /// <summary>
        /// 刷新是否完成,防止重复刷新
        /// </summary>
        bool refDone = false;

        /// <summary>
        /// 是否需要筛选
        /// </summary>
        bool isFilter = false;

        /// <summary>
        /// 筛选器是否更变,或者是否获取了新的房间列表,用于防止多次筛选
        /// </summary>
        bool changedFilter = false;

        /// <summary>
        /// 当前的房间列表
        /// </summary>
        public static List<Room> rooms;
        /// <summary>
        /// 房间列表对应的对象
        /// </summary>
        public static List<GameObject> roomsObj;
    

        private void Awake()
        {
            rooms = new List<Room>();
            roomsObj = new List<GameObject>();
        }

        private void OnEnable()
        {
            //携程启动
            StartCoroutine(IERefreshRoomList());
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

        private void Update()
        {
            string str = GameObject.Find("IF_IDFilter").GetComponent<InputField>().text;
            int p = 0;
            if (str != "" && int.TryParse(str, out p))
            {
                if (!(p == 0 || p == CheckID))
                {
                    CheckID = Mathf.Abs(p);
                    changedFilter = true;
                }
            }
            else
            {
                CheckID = 0;
                isFilter = false;
            }
        }

        /// <summary>
        /// 应对刷新整个房间列表
        /// </summary>
        void RefreshRoomList()
        {
            if (refDone)
            {
                StopAllCoroutines();
                StartCoroutine(IERefreshRoomList());
            }
        }

        /// <summary>
        /// 刷新房间控件的大小
        /// </summary>
        void RefreshRoomSize()
        {
            int ct = gameObject.transform.childCount;
            Vector2 v2 = gameObject.GetComponent<RectTransform>().sizeDelta;
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(v2.x, ct * 105);    
        }

        /// <summary>
        /// 筛选显示条件
        /// </summary>
        void ShowRoomsInFilter()
        {
            foreach (var item in roomsObj)
            {
                ShowRoomsInFilter(item);
            }
        }

        /// <summary>
        /// 单独筛选某个房间
        /// </summary>
        /// <param name="obj"></param>
        void ShowRoomsInFilter(GameObject obj)
        {
            if (isFilter)
            {
                if (changedFilter)
                {
                    //如果符合筛选器条件,那么显示,否则不显示
                    if (CheckID.ToString() == obj.name)
                    {
                        obj.SetActive(true);
                    }
                    else
                    {
                        obj.SetActive(false);
                    }
                    //筛选器未改变
                    changedFilter = false;
                }
            }
            else
            {
                obj.SetActive(true);
            }
        }

        public IEnumerator IERefreshRoomList()
        {
            yield return new WaitForFixedUpdate();
            while (true)
            {
                refDone = false;
                changedFilter = true;
                //清空并移除过期列表
                rooms.Clear();
                roomsObj.Clear();
                for (int i = 0; i < transform.childCount; i++)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
                //开始等待获取列表
                Options.YGOWaiter.Switch(Egan.Constants.MessageType.GET_ROOMS, true);
                Options.client.GetRooms();
                //等待rooms被载入,并设置超时时间
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
                //重新申请获取
                if (outofFrame == 0)
                {
                    continue;
                }
                //添加获取到的房间
                foreach (var item in rooms)
                {
                    //等待一帧
                    yield return new WaitForFixedUpdate();
                    GameObject obj = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\GameCenter\room"), gameObject);
                    obj.GetComponent<Toggle>().onValueChanged.AddListener(var =>
                    {
                        RoomInfo.Selected = var ? item.Id : -1;
                        RoomInfo.Id = item.Id;
                        RoomInfo.Name = item.Name;
                    });
                    obj.transform.Find("ID").GetComponent<Text>().text = item.Id.ToString();
                    obj.name = item.Id.ToString();
                    obj.transform.Find("Name").GetComponent<Text>().text = item.Name;
                    obj.transform.Find("Host").GetComponent<Text>().text = item.Host.Name;
                    obj.transform.Find("Desc").GetComponent<Text>().text = item.Desc;
                    roomsObj.Add(obj);
                    ShowRoomsInFilter(obj);
                }
                //更新控件框大小
                RefreshRoomSize();
                //刷新标志完成
                refDone = true;
                //等待30s
                yield return new WaitForSeconds(30f);
            }

        }


    }
}


