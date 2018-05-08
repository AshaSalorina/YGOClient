using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mono_MoveCard_Card : MonoBehaviour {

    public static Camera cmr;
    bool moveInSite = false;
    Vector3 startP;
    Vector3 pre;
    Vector3 V3;
    public void MouseDrag()
    {
        V3 =Input.mousePosition;
        var mover = V3 - pre;
        gameObject.transform.localPosition += mover;
        pre = V3;
    }


    public void MouseDown()
    {
        startP = gameObject.transform.position;
        pre = Input.mousePosition;
    }

    public void MouseUp()
    {
        if (!moveInSite)
        {
            gameObject.transform.position = startP;
        }
    }

}
