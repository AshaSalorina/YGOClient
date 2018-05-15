using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asha
{
    /// <summary>
    /// 我实在受不了那么多加载了，就总结了一个
    /// </summary>
    public class InstantiateHelper
    {

        /// <summary>
        /// 调用GameObject.Instantiate载入预制体
        /// </summary>
        /// <param name="prefab">预制体</param>
        /// <param name="parent">父对象</param>
        /// <param name="localPositon">本地坐标</param>
        /// <param name="localScale">缩放</param>
        /// <param name="isActive">是否激活</param>
        /// <returns></returns>
        public static GameObject InsObj(GameObject prefab, GameObject parent, Vector3 localPositon, Vector3 localScale, bool isActive)
        {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.transform.SetParent(parent.transform);
            obj.transform.localPosition = localPositon;
            obj.transform.localScale = localScale;
            obj.SetActive(isActive);
            return obj;
        }
    }
}

