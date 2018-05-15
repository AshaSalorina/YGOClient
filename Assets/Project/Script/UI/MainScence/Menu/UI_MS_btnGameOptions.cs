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
                GameObject opt = GameObject.Find("pl_Options");
                if (opt == null)
                {
                    opt = Instantiate(Resources.Load<GameObject>(@"Prefabs\UI\MainScenc\pl_Options"));
                    opt.transform.SetParent(Options.MainScence.transform);
                    opt.transform.localPosition = new Vector3(0, 0, 0);
                }
                opt.SetActive(true);
                Options.Menu.SetActive(false);
            });
        }

    }
}

