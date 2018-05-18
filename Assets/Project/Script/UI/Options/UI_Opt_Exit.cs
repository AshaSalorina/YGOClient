using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asha
{
    public class UI_Opt_Exit : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Options.Menu.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

}
