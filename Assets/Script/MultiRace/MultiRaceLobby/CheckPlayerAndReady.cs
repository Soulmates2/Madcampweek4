using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;

public class CheckPlayerAndReady : NetworkBehaviour 
{
    public int NowPlayer;
    public int ReadyPlayer;
    static public bool is_game_start = false;
    public bool is_map_created = false;
    public GameObject[] Field;
    public int OurField = 0;
    static public NetworkInstanceId[] netIDSet;
   
    private void Start()
    {
        netIDSet = new NetworkInstanceId[8];
        NowPlayer = 0;
        ReadyPlayer = 0;
    }

    public void OnPlayerConnected()
    {
        Debug.Log("Add Now Player");
        netIDSet[FindObjectOfType<CheckPlayerAndReady>().NowPlayer] = netId;
        FindObjectOfType<CheckPlayerAndReady>().NowPlayer++;
    }

    public void OnPlayerDisconnected()
    {
        Debug.Log("Sub Now Player");
        FindObjectOfType<CheckPlayerAndReady>().NowPlayer--;
    }

    public void StartGame()
    {
        if (FindObjectOfType<CheckPlayerAndReady>().NowPlayer <= FindObjectOfType<CheckPlayerAndReady>().ReadyPlayer)
        {
            if ((is_map_created == false) && (is_game_start == false) && (ReadyPlayer > 0))
            {
                is_map_created = true;
                is_game_start = true;
                NetworkServer.Spawn(Instantiate(Field[OurField], new Vector3(-100, -100, -100), Quaternion.Euler(0, 0, 0)));
            }
        }
    }




}

