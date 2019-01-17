using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MultiRaceLobby : NetworkManager
{
    [SerializeField]
    InputField ipInputField;
    [SerializeField]
    InputField portInputField;

    bool isServer;
    bool isClient;

    public void OpenServer()
    {
        networkPort = int.Parse(portInputField.text);
        StartServer();
    }

    public void OpenHost()
    {
        networkPort = int.Parse(portInputField.text);
        StartHost();
    }

    public void ConnectClientToServer()
    {
        networkAddress = ipInputField.text;
        networkPort = int.Parse(portInputField.text);
        StartClient();
    }

    public void Disconnect()
    {
        if (isServer && isClient)
        {
            StopHost();
        }
        else if (isServer)
        {
            StopServer();
        }
        else if (isClient)
        {
            StopClient();
        }
        isServer = isClient = false;
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        isServer = true;
        // testLog.text += ("\n[Server]Start Server");
    }

    public override void OnStartHost()
    {
        base.OnStartHost();
        // testLog.text += ("\n[Host]Start Host");
    }

    public override void OnStartClient(NetworkClient client)
    {
        base.OnStartClient(client);
        isClient = true;
        isServer = false;
        //  testLog.text += ("\n[Client]Start Client");
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        // testLog.text += ("\n[Client]Connect Server Sucess.");
    }

    public override void OnServerConnect(NetworkConnection conn)
    {
        base.OnServerConnect(conn);
        //  testLog.text += ("\n[Server]Connected Client.");
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        base.OnServerDisconnect(conn);
        // testLog.text += ("\n[Server]Client Disconnect.");
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);
        // testLog.text += ("\n[Client]Client Disconnect.");
    }

    public override void OnStopServer()
    {
        base.OnStopServer();
        // testLog.text += ("\n[Server]Server Stop.");
    }

    public override void OnStopHost()
    {
        base.OnStopHost();
        // testLog.text += ("\n[Host]Host Stop.");
    }

    public override void OnStopClient()
    {
        base.OnStopClient();
        //  testLog.text += ("\n[Client]Client Stop.");
    }

}