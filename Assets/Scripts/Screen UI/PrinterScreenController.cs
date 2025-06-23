using Assets.Scripts.World_UI.Printer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class PrinterScreenController : MonoBehaviour
{
    public PrintMenuSelectListScreen CurrentScreen;

    public PrinterMenuScreen Current;

    public void SwitchScreen(PrintMenuSelectListScreen newScreen)
    {
        CurrentScreen.gameObject.SetActive(false);
        CurrentScreen = newScreen;
        CurrentScreen.gameObject.SetActive(true);
        CurrentScreen.Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentScreen.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Log(string str)
    {
        Debug.Log(str);
    }

    public void Up()
    {
        CurrentScreen.Up();
    }

    public void Down()
    {
        CurrentScreen.Down();
    }

    public void Select()
    {
        CurrentScreen.Select();
    }
}
