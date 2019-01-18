using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
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
    public GameObject[] Field;

    public Sprite[] CarImage;
    public Sprite[] FieldImage;

    public int MyCar = 0;
    public int OurField = 0;

    public Image CarImageField;
    public Image FieldImageField;

    public bool is_game_start = false;
    public bool is_map_created = false;
    public bool isReady = false;
    
    // Start is called before the first frame update
    void Start()
    {
        LobbyUI.gameObject.SetActive(false);
        InGameUI.gameObject.SetActive(false);
        if (isLocalPlayer)
        {
            CmdAddNowUser();
            LobbyUI.gameObject.SetActive(true);
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

    [Command]
    void CmdOnClickReadyOrCancel()
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
            if (FindObjectOfType<CheckPlayerAndReady>().NowPlayer <= FindObjectOfType<CheckPlayerAndReady>().ReadyPlayer)
            {
                if ((is_map_created == false) && (is_game_start == false))
                {
                    RpcStartGame();
                    is_map_created = true;
                    is_game_start = true;
                    NetworkServer.Spawn(Instantiate(Field[OurField], new Vector3(-100, -100, -100), Quaternion.Euler(0, 0, 0)));
                }
                else
                {
                    RpcChangeSpriteCancel();
                }
            }
            
        }
        RpcUpdateTextField(FindObjectOfType<CheckPlayerAndReady>().NowPlayer, FindObjectOfType<CheckPlayerAndReady>().ReadyPlayer);
    }
    [Command]
    void CmdMakeUserCar(int MyCar)
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
    void CmdAddNowUser()
    {
        FindObjectOfType<CheckPlayerAndReady>().NowPlayer++;
        RpcUpdateTextField(FindObjectOfType<CheckPlayerAndReady>().NowPlayer, FindObjectOfType<CheckPlayerAndReady>().ReadyPlayer);
    }

    [ClientRpc]
    void RpcStartGame()
    {
        if (isLocalPlayer)
        {
            CmdMakeUserCar(MyCar);
            LobbyUI.gameObject.SetActive(false);
            InGameUI.gameObject.SetActive(true);
        }
    }
    [ClientRpc]
    void RpcUpdateTextField(int NowPlayer, int ReadyPlayer)
    {
        if (isLocalPlayer)
        {
            NowPlayerText.text = "Now Player : " + NowPlayer.ToString();
            ReadyPlayerText.text = "Ready Player : " + ReadyPlayer.ToString();
        }
    }
    [ClientRpc]
    void RpcChangeSpriteCancel()
    {
        if (isLocalPlayer)
        {
            ReadyOrCancel.sprite = Cancel;
        }
    }
    [ClientRpc]
    void RpcChangeSpriteReady()
    {
        if (isLocalPlayer)
        {
            ReadyOrCancel.sprite = Ready;
        }
    }

}
