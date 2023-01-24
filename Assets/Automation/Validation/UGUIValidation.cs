using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UGUIValidation
{
    public GameObject ButtonToValidate;
    
    public String GetFontFromObject()
    {
        ButtonToValidate = GameObject.Find("Menu/Start/ConnectButton/Text (TMP)");
        String font = ButtonToValidate.GetComponent<TextMeshProUGUI>().font.ToString();
        Console.WriteLine($"Font found: {font}");
        return font;
    }
    
}
