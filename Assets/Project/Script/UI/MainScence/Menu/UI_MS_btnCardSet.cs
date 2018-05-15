using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asha
{
    public class UI_MS_btnCardSet : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (Options.CardsSet == null)
                {
                    Options.CardsSet = GameObject.Find("CardsSet");
                }
                Options.CardsSet.SetActive(true);
                Options.Menu.SetActive(false);
            });
        }

    }
}


