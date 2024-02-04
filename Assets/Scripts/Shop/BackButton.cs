using UnityEngine;
using UnityEngine.EventSystems;

public class BackButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject Application;
    public GameObject DesktopIcon;
    public void OnPointerClick(PointerEventData eventData)
    {
        DesktopIcon.SetActive(true);
        Application.SetActive(false);
        gameObject.SetActive(false);
    }
}

