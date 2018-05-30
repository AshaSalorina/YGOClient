using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asha
{
    public class UI_MS_plClickToRun : MonoBehaviour
    {

        private void Start()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (Input.GetMouseButtonUp(0))
                {
                    //载入网络
                    Options.EventSystem.SendMessage("NetLoad");
                    Options.Menu.SetActive(true);
                    GameObject.Find("Title").SetActive(false);
                    Destroy(gameObject);
                }
            });
        }

    }
}

