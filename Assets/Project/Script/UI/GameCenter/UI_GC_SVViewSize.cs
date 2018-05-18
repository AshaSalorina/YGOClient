using Egan.Cotrollers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Asha.Tools;

namespace Asha
{
    public class UI_GC_SVViewSize : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Refresh();
            //携程启动
            StartCoroutine(RefreshRoomList());
        }

        private void OnDisable()
        {
            //携程维护
            StopCoroutine(RefreshRoomList());
        }


        private void OnDestroy()
        {
            //携程维护
            StopCoroutine(RefreshRoomList());
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
                
                //移除旧的列表
                for (int i = 0; i < transform.childCount; i++)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
                try
                {
<<<<<<< HEAD
                    //通过NetWorkWrapper获取房间列表，并生成房间置入滚动框
                    var nT = new NetworkWrapper();
=======
                    //通过NetWorkWrapper获取房间列表
                    var nT = new NetworkClient();
>>>>>>> 35a274449469c9ad25d8d0cc175da20cd1fcd931
                    var ls = nT.GetRooms();
                    foreach (var item in ls)
                    {
                        GameObject obj = InstantiateHelper.InsObj(Resources.Load<GameObject>(@"Prefabs\UI\GameCenter\room"), gameObject);
                        obj.transform.Find("ID").GetComponent<Text>().text = item.Id.ToString();
                        obj.name = item.Name;
                        obj.transform.Find("Name").GetComponent<Text>().text = item.Name;
                        obj.transform.Find("Host").GetComponent<Text>().text = item.Host.Name;
                        obj.transform.Find("Desc").GetComponent<Text>().text = item.Desc;
                    }
                }
                catch (System.Exception e)
                {
                    //todo：删除debug
                    Debug.Log(e.ToString());
                    //throw;
                }
                //更新控件框大小
                Refresh();
                //等待30s
                yield return new WaitForSeconds(30f);
            }

        }


    }
}


