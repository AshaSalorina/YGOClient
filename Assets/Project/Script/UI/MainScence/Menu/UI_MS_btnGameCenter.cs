using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asha
{
    public class UI_MS_btnGameCenter : MonoBehaviour {

        void Start() {
            gameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                Options.GameCenter.SetActive(true);
                Options.Menu.SetActive(false);
            });
        }

    }
}

