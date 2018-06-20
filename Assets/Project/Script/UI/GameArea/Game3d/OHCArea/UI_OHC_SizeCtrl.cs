using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_OHC_SizeCtrl : MonoBehaviour {

    HorizontalLayoutGroup Hlg;

    void Start()
    {
        Hlg = GetComponent<HorizontalLayoutGroup>();
    }

    void Update()
    {
        int ct = gameObject.transform.childCount;
        Hlg.spacing = (600 - 108 * ct) / ct - 108 / ct;
    }
}
