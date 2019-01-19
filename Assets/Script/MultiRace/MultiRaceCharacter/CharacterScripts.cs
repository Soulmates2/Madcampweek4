using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;


[NetworkSettings(sendInterval = 0.016f)]
public class CharacterScripts : NetworkBehaviour
{
    public Text NowPlayerText;
    public Text ReadyPlayerText;
    public Image ReadyOrCancel;
    public Sprite Ready;
    public Sprite Cancel;
    public GameObject LobbyUI;
    public GameObject InGameUI;

    public GameObject[] Car;

    public Sprite[] CarImage;
    public Sprite[] FieldImage;

    public int MyCar = 0;

    public Image CarImageField;
    public Image FieldImageField;


    public bool isReady = false;

    public delegate void TakeStartGame();

    [SyncEvent]
    public event TakeStartGame EventStartGame;

    // Start is called before the first frame update
    void Start()
    {
        LobbyUI.gameObject.SetActive(false);
        InGameUI.gameObject.SetActive(false);
        if (NetworkClient.active)
        {
            this.EventStartGame += StartGame;
        }
        if (isLocalPlayer)
        {
            CmdAddNowUser();
            LobbyUI.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (isServer && CheckPlayerAndReady.is_game_start)
        {
            CheckPlayerAndReady.is_game_start = false;
            //EventStartGame();
        }
    }

    public void OnClickReadyOrCancel()
    {
        CmdOnClickReadyOrCancel();
    }

    public void OnClickMyCarRight()
    {
        MyCar++;
        if (MyCar > Car.Length - 1)
        {
            MyCar = 0;
        }
        CarImageField.sprite = CarImage[MyCar];
    }

    public void OnClickMyCarLeft()
    {
        MyCar--;
        if (MyCar < 0)
        {
            MyCar = Car.Length - 1;
        }
        CarImageField.sprite = CarImage[MyCar];
    }

    public void StartGame()
    {
        if (isLocalPlayer)
        {
            CmdMakeUserCar(MyCar);
            LobbyUI.gameObject.SetActive(false);
            InGameUI.gameObject.SetActive(true);
        }
    }

    [Command]
    public void CmdOnClickReadyOrCancel()
    {
        if (isReady)
        {
            FindObjectOfType<CheckPlayerAndReady>().ReadyPlayer--;
            isReady = false;
            RpcChangeSpriteReady();
        }
        else
        {
            FindObjectOfType<CheckPlayerAndReady>().ReadyPlayer++;
            isReady = true;
            RpcChangeSpriteCancel();
            FindObjectOfType<CheckPlayerAndReady>().StartGame();
        }
        RpcUpdateTextField(FindObjectOfType<CheckPlayerAndReady>().NowPlayer, FindObjectOfType<CheckPlayerAndReady>().ReadyPlayer);
    }
    [Command]
    public void CmdMakeUserCar(int MyCar)
    {
        GameObject[] StartPositionObject = GameObject.FindGameObjectsWithTag("StartPosition");
        Debug.Log(StartPositionObject.Length);
        if(MyCar == 0)
        {
            var go = (GameObject)Instantiate(Car[MyCar], StartPositionObject[netId.Value - 2].transform.position, Quaternion.Euler(0, -90, 0));
            go.transform.SetParent(transform);
            NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        }else if(MyCar == 1)
        {
            var go = (GameObject)Instantiate(Car[MyCar], StartPositionObject[netId.Value - 2].transform.position, Quaternion.Euler(0, 0, 0));
            go.transform.SetParent(transform);
            NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        }
        else if (MyCar == 2)
        {
            var go = (GameObject)Instantiate(Car[MyCar], StartPositionObject[netId.Value - 2].transform.position, Quaternion.Euler(0, 0, 0));
            go.transform.SetParent(transform);
            NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        }
        else if (MyCar == 3)
        {
            var go = (GameObject)Instantiate(Car[MyCar], StartPositionObject[netId.Value - 2].transform.position, Quaternion.Euler(-90, 0, 0));
            go.transform.SetParent(transform);
            NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        }
    }
    [Command]
    public void CmdAddNowUser()
    {
        FindObjectOfType<CheckPlayerAndReady>().NowPlayer++;
        RpcUpdateTextField(FindObjectOfType<CheckPlayerAndReady>().NowPlayer, FindObjectOfType<CheckPlayerAndReady>().ReadyPlayer);
    }

    /*
    [ClientRpc]
    public void RpcStartGame()
    {
        if (isLocalPlayer)
        {
            CmdMakeUserCar(MyCar);
            LobbyUI.gameObject.SetActive(false);
            InGameUI.gameObject.SetActive(true);
        }
    }
    */
    [ClientRpc]
    public void RpcUpdateTextField(int NowPlayer, int ReadyPlayer)
    {
        if (isLocalPlayer)
        {
            NowPlayerText.text = "Now Player : " + NowPlayer.ToString();
            ReadyPlayerText.text = "Ready Player : " + ReadyPlayer.ToString();
            if(NowPlayer == ReadyPlayer)
            {
                StartGame();
            }
        }
    }
    [ClientRpc]
    public void RpcChangeSpriteCancel()
    {
        if (isLocalPlayer)
        {
            ReadyOrCancel.sprite = Cancel;
        }
    }
    [ClientRpc]
    public void RpcChangeSpriteReady()
    {
        if (isLocalPlayer)
        {
            ReadyOrCancel.sprite = Ready;
        }
    }


}
