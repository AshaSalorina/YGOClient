using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MS_cTRAnime : MonoBehaviour {
    Outline ol;
	// Use this for initialization
	void Start () {
        ol = gameObject.GetComponent<Outline>();
	}


    static int flag = 1;
    void Update()
    {

        Color c = ol.effectColor;
        c.a += flag * 0.01f;
        c.a = Mathf.Max(c.a, 0);
        c.a = Mathf.Min(c.a, 0.6f);
        ol.effectColor = c;

        if (c.a == 0 || c.a == 0.6f)
        {
            flag *= -1;
        }
    }
}
