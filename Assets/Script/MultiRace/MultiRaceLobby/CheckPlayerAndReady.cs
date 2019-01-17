using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;

public class CheckPlayerAndReady : MonoBehaviour 
{
    public int NowPlayer;
    public int ReadyPlayer;

    private void Start()
    {
        NowPlayer = 0;
        ReadyPlayer = 0;
    }

    public void OnPlayerConnected()
    {
        Debug.Log("Add Now Player");
        FindObjectOfType<CheckPlayerAndReady>().NowPlayer++;
    }

    public void OnPlayerDisconnected()
    {
        Debug.Log("Sub Now Player");
        FindObjectOfType<CheckPlayerAndReady>().NowPlayer--;
    }
    
}

