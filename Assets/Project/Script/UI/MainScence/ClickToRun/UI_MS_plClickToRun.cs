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
                    if (Options.Menu == null)
                    {
                        Options.Menu = GameObject.Find("pl_menu");
                    }
                    Options.Menu.SetActive(true);
                    gameObject.SetActive(false);
                    enabled = false;
                }
            });
        }

    }
}

