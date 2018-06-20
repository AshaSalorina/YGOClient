using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asha
{
    public class UI_Opt_ChangeBG : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                Options.backgroundURL = GameObject.Find("BGStr").GetComponent<InputField>().text;
                GameObject.Find("MS_Background").SendMessage("Refresh");
            });
        }

    }
}

