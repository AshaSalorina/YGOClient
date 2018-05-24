using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asha
{
    public class UI_MS_btnExit : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }


    }
}


