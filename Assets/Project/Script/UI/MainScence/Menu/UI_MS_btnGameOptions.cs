using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asha
{
    public class UI_MS_btnGameOptions : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                Options.Optionpl.SetActive(true);
                Options.Menu.SetActive(false);
            });
        }

    }
}

