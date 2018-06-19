using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Room_Talk : MonoBehaviour {

    public static GameObject obj;

    private void Start()
    {
        obj = gameObject;
    }


    public static void ShowText(string str)
    {
        obj.transform.Find("Text").GetComponent<Text>().text += '\n'+ str;
    }
}
