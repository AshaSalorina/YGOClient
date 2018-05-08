using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asha.UI
{
    public class AUIBase
    {

        public GameObject self;

        /// <summary>
        /// Prefab地址
        /// </summary>
        public string path;

        public AUIBase() { }

        
        public void Show() { self.SetActive(true); }
        public void Close() { self.SetActive(false); }

    }
}
