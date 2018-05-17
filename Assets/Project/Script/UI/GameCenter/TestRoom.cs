using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Egan.Cotrollers;
using UnityEngine.UI;

public class TestRoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Test();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Test()
    {
        try
        {
            NetworkWrapper nT = new NetworkWrapper();
            var ls = nT.GetRooms();
            /*
            foreach (var item in ls)
            {
                item.Id
            }
            */
            GameObject obj = gameObject.transform.Find("ID").gameObject;
            obj.transform.GetComponent<Text>().text = ls[0].Id.ToString();
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }

    }

}
