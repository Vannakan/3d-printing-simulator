using UnityEngine;


public class DesktopApplication : MonoBehaviour
{
    public GameObject DesktopIcon;
    public GameObject App;
    public GameObject Back;
    public Application Type;

    public void ShowDesktop()
    {
     //   DesktopIcon.SetActive(true);
        App.SetActive(false);
        Back.SetActive(false);
    }

    public void StartApplication()
    {
     //   DesktopIcon.SetActive(false);
        App.SetActive(true);
        Back.SetActive(true);
    }

    public void Shutdown()
    {
       // DesktopIcon.SetActive(false);
        App.SetActive(false);
        Back.SetActive(false);
    }
}