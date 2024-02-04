using UnityEngine;

public class AddToCart : MonoBehaviour
{
    public int Amount;
    ItemType ItemType;

    public ShopApplication ShopApplication;

    public void Add()
    {
        ShopApplication.AddToBasket(new ShopItem() { ItemType = ItemType });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
