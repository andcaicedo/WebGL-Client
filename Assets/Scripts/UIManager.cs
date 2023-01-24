using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }
    
    public GameObject startMenu;
    private void Awake()
    {
        // singleton implementation
        if (instance != null && instance!= this)
        {
            Debug.Log("Instance already exists, destroying object...");
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void Connect()
    {
        Client.instance.ConnectToServer();
    }

    public void Disconnect()
    {
        Client.instance.DisconnectServer();
    }

    public void Testing()
    {
        Debug.Log("Test button pressed!");
    }
}
