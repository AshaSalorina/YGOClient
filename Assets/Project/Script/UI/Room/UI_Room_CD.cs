using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Room_CD : MonoBehaviour {

    Transform CD;
    Transform Dual;

	// Use this for initialization
	void Start () {
        CD = transform.Find("CountDown");
        Dual = transform.Find("Dual");
        CD.gameObject.SetActive(false);
        Dual.gameObject.SetActive(false);
	}
	
    /// <summary>
    /// 计时
    /// </summary>
    /// <param name="ocd"></param>
	void CountDown(object ocd)
    {
        int cd = (int)ocd;
        if (cd != 1)
        {
            CD.gameObject.SetActive(true);
            CD.GetComponent<Text>().text = cd.ToString();
        }
        else
        {
            Dual.gameObject.SetActive(true);
            CD.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 终止计时
    /// </summary>
    void StopCD()
    {
        CD.gameObject.SetActive(false);
        Dual.gameObject.SetActive(false);
    }

}
