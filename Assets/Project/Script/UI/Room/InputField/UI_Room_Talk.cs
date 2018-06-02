using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Room_Talk : MonoBehaviour {

	void ShowText(string str)
    {
        transform.Find("Text").GetComponent<Text>().text += '\n'+ str;
    }



}
