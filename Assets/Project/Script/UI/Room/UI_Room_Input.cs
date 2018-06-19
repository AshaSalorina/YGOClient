using Asha;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Room_Input : MonoBehaviour {

    Text ts;

	// Use this for initialization
	void Start () {
        ts = transform.Find("Text").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            Options.client.Chat(ts.text);
            ts.text = "";
        }
	}
}
