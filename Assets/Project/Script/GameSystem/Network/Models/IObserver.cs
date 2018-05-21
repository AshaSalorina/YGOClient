using Egan.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public interface IObserver{
    int MessageCount { get; }
    DataPacket SendDataPacket();
}

public class Test : MonoBehaviour
{

    private void Start()
    {
        Fun(new ThreadStart(TA));
    }

    public void Fun(ThreadStart start)
    {
        StartCoroutine(GetInfo());
    }
    public void TA()
    {

    }
    IEnumerator GetInfo(DataPacket dp)
    {
        while (true)
        {

            yield return TA();
        }
        
    }
}