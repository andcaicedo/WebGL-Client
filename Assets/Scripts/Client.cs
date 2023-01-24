using System;
using NativeWebSocket;
using Newtonsoft.Json;
using UnityEngine;
using Random = UnityEngine.Random;

public class RequestCommand
{
    public string Command { get; set; }
    public string Arguments { get; set; }
}

public class Client : MonoBehaviour
{
    public WebSocket ws;
    
    public  String Host = "localhost";
    public  String Port1 = "3000";
    public String Port2 = "4000";
    public static string Behaviour = "ProxyBridge";
    public String GID;
    public static Client instance { get; private set; }
    public UGUIValidation ugui;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("Instance already exists, destroying object...");
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        ws = new WebSocket($"ws://{Host}:{Port1}/{Behaviour}");

        ugui = new UGUIValidation();
        
        GID = generateID();
        
        ws.OnOpen += () =>
        {
            Debug.Log($"Client Message: Connection open! with ID: {GID.ToString()}");
        };

        ws.OnError += (e) =>
        {
            Debug.Log("Error! " + e);
        };

        ws.OnClose += (e) =>
        {
            Debug.Log($"Client Message: Connection closed with ID: {GID}");
        };

        ws.OnMessage += (bytes) =>
        {
            var message = System.Text.Encoding.UTF8.GetString(bytes);            
            Debug.Log($"Client ID: {GID} Received Message {message}");
        };
    }
    
    private void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        ws.DispatchMessageQueue();
#endif
        if(ws == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ws.SendText("A key was pressed! getting the font from the button...");
            var font = ugui.GetFontFromObject();
            ws.SendText($"Font was found: {font}");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SendWebSocketMessage($"Connection Message from: {GID}");
        }

        if (Input.GetKeyDown((KeyCode.X)))
        {
            var requestCommand = new RequestCommand()
            {
                Arguments = ChooseColor(),
                Command = "SetColor"
            };
            var requestJSON = JsonConvert.SerializeObject(requestCommand);
            SendWebSocketMessage(requestJSON);
        }
    }

    public string ChooseColor()
    {
        string[] colorLists = new string[4]{"blue", "green", "red", "yellow"};
        
        return colorLists[Random.Range(0, 4)];
    }
    
    public string generateID()
    {
        return Guid.NewGuid().ToString("D");
    }

    public void ConnectToServer()
    {
        ws.Connect();
    }
    
    public void SendWebSocketMessage(String message)
    {
        ws.SendText(message);
    }

    public void DisconnectServer()
    {
        ws.Close();
    }
}
