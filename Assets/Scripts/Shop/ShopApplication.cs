using System.Collections.Generic;
using UnityEngine;


public class Basket
{
    private List<ShopItem> _items = new List<ShopItem>();
}
public enum ItemType
{
    Printer,
    Filament,
    Upgrade, 
    Prop
}
public class ShopItem
{
    public ItemType ItemType;
}

public class ShopApplication : MonoBehaviour
{
    public GameObject CurrentPage;
    public Basket Basket;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToBasket(ShopItem item)
    {

    }

    public void SwitchPage(GameObject gameObject)
    {
        if(CurrentPage != null)
            CurrentPage.SetActive(false);

        CurrentPage = gameObject;
        CurrentPage.SetActive(true);
    }
}
