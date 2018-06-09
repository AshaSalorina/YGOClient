using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asha
{
    public class UI_CS_Back : MonoBehaviour
    {
        void Start()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                Options.Menu.SetActive(true);
                Options.CardsSet.SetActive(false);
            });
    
    }

    }
}

