using Assets.Code;
using UnityEngine;
using UnityEngine.UI;

public class ToolbarItem : MonoBehaviour
{
    public GameObject Border;
    public GameObject Image;

    public InventoryItem InventoryItem;

    public void Start()
    {
        SetAlpha();
    }

    public void SetInventoryItem(InventoryItem inventoryItem)
    {
        if(inventoryItem == null)
        {
            InventoryItem = null;
            ClearImage();
            return;
        }

        InventoryItem = inventoryItem;
        SetImage(InventoryItem.Item.Sprite);
    }

    public void SetAlpha()
    {
        var image = Image.GetComponent<Image>();
        image.color = Color.clear;
    }
    public void SetImage(Sprite sprite)
    {
        var image = Image.GetComponent<Image>();
        image.sprite = sprite;
        image.color = Color.white;
    }

    public void SetBorderColour(Color color)
    {
        var image = Border.GetComponent<Image>();
        image.color = color;    
    }

    public void ClearImage()
    {
        var image = Image.GetComponent<Image>();
        image.sprite = null;
        image.color = Color.clear;
    }
}
