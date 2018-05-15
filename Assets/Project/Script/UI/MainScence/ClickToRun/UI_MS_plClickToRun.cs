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
                    Options.Menu.SetActive(true);
                    gameObject.SetActive(false);
                    enabled = false;
                }
            });
        }

    }
}

