using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Egan.Cotrollers;

public class TestRoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Test()
    {
        NetworkWrapper nT = new NetworkWrapper();
        nT.GetRooms();
    }

}
