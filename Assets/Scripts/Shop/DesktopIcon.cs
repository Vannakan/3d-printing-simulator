using UnityEngine;
using UnityEngine.EventSystems;

public class DesktopIcon : MonoBehaviour, IPointerClickHandler
{
    public GameObject Application;
    public GameObject BackButton;
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.SetActive(true);
        BackButton.SetActive(true);
        gameObject.SetActive(false);
    }
}
