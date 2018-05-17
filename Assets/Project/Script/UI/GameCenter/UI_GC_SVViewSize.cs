using Egan.Cotrollers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Asha
{
    public class UI_GC_SVViewSize : MonoBehaviour
    {
        ScrollRect sR;
        // Use this for initialization
        void Start()
        {
            sR = gameObject.GetComponent<ScrollRect>();
            Refresh();
            StartCoroutine(RefreshRoomList());
        }

        private void OnDisable()
        {
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
                    //通过NetWorkWrapper获取房间列表
                    var nT = new NetworkWrapper();
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
                Refresh();
                yield return new WaitForSeconds(30f);
            }

        }


    }
}


