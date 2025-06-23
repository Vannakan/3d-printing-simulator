using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Desktop : MonoBehaviour, IPointerClickHandler
{
    public List<DesktopApplication> Applications = new();
    public DesktopApplication CurrentApplication;
    public AudioSource ClickAudio;

    public GameObject DesktopIcons;

    // Need to be better with this as it doesnt account for distance (need an isoccupied flag really)
    public void OnPointerClick(PointerEventData eventData)
    {
        ClickAudio.Play();
    }

    public void ReturnToDesktop()
    {
        foreach (var application in Applications)
        {
            application.ShowDesktop();
        }

        DesktopIcons.SetActive(true);
    }

    public void SwitchTo(DesktopApplication application)
    {
        foreach(var app in Applications)
        {
            app.Shutdown();
        }

        application.StartApplication();
        DesktopIcons.SetActive(false);
    }
}
