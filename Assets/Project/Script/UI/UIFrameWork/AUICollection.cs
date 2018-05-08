using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asha.UI
{
    public class AUICollection
    {
        static List<AUIBase> MainUIRoot = new List<AUIBase>();

        /// <summary>
        /// 创建类型为T的UIprefab
        /// </summary>
        /// <typeparam name="T">UI类型,基于AUIBase类</typeparam>
        static void Creat<T>() where T : AUIBase,new()
        {
            AUIBase abe = new T();
            
            GameObject obj = (GameObject)Resources.Load(abe.path);

            abe.self = obj;

            MainUIRoot.Add(abe);

        }

        public static void ShowOrUpdate<T>() where T : AUIBase, new()
        {

        }

    }
}