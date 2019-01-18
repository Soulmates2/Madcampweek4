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
    public GameObject UI;

    public GameObject[] Car;
    public GameObject[] Field;

    public bool isReady = false;
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            CmdAddNowUser();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        
    }

    public void OnClickReadyOrCancel()
    {
        if (isReady)
        {
            isReady = false;
            //레디 한 상태였다면
            CmdSubReadyUser();
            ReadyOrCancel.sprite = Ready;
        }
        else
        {
            isReady = true;
            CmdAddReadyUser();
            ReadyOrCancel.sprite = Cancel;
        }
    }

    [Command]
    void CmdAddReadyUser()
    {
        FindObjectOfType<CheckPlayerAndReady>().ReadyPlayer++;
        if (FindObjectOfType<CheckPlayerAndReady>().NowPlayer <= FindObjectOfType<CheckPlayerAndReady>().ReadyPlayer)
        {
            if (netId.Value == 2)
            {
                NetworkServer.Spawn(Instantiate(Field[0], new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)));
            }
            RpcStartGame();
        }
        else
        {
            RpcUpdateTextField(FindObjectOfType<CheckPlayerAndReady>().NowPlayer, FindObjectOfType<CheckPlayerAndReady>().ReadyPlayer);
        }
    }

    [ClientRpc]
    void RpcStartGame()
    {
        UI.gameObject.SetActive(false);
        if (isLocalPlayer)
        {
            CmdMakeUserCar();
        }
    }

    [Command]
    void CmdMakeUserCar()
    {
        GameObject[] StartPositionObject = GameObject.FindGameObjectsWithTag("StartPosition");
        var go = (GameObject)Instantiate(Car[2], StartPositionObject[0].transform.position, Quaternion.Euler(0, 0, 0));
        go.transform.SetParent(transform);
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
    }

    [Command]
    void CmdSubReadyUser()
    {
        FindObjectOfType<CheckPlayerAndReady>().ReadyPlayer--;
        RpcUpdateTextField(FindObjectOfType<CheckPlayerAndReady>().NowPlayer, FindObjectOfType<CheckPlayerAndReady>().ReadyPlayer);
    }

    [Command]
    void CmdAddNowUser()
    {
        FindObjectOfType<CheckPlayerAndReady>().NowPlayer++;
        RpcUpdateTextField(FindObjectOfType<CheckPlayerAndReady>().NowPlayer, FindObjectOfType<CheckPlayerAndReady>().ReadyPlayer);
    }

    [ClientRpc]
    void RpcUpdateTextField(int NowPlayer, int ReadyPlayer)
    {
        NowPlayerText.text = "Now Player : " + NowPlayer.ToString();
        ReadyPlayerText.text = "Ready Player : " + ReadyPlayer.ToString();
    }

}
