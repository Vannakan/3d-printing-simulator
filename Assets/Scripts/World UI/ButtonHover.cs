using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image Image;
    public void OnPointerEnter(PointerEventData eventData)
    {
      //  Debug.Log("Hello");
        var test = Image.GetComponent<Image>();
        test.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Goodbye");
        var test = Image.GetComponent<Image>();
        test.color = Color.white;
    }
}
