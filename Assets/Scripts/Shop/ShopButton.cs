using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public GameObject NextMenu;
    public void GotoNext()
    {
        NextMenu.SetActive(true);
        transform.transform.parent.gameObject.SetActive(false);
    }
}
