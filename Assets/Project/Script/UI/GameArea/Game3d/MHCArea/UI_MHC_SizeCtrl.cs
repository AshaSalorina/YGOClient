using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MHC_SizeCtrl : MonoBehaviour {

    HorizontalLayoutGroup Hlg;

    void Start () {
        Hlg = GetComponent<HorizontalLayoutGroup>();
	}
	
	void Update () {
        int ct = gameObject.transform.childCount;
        Hlg.spacing = (750 - 180 * ct) / ct - 180 / ct;
	}
}
