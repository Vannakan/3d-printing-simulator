using UnityEngine;

public class AddToCart : MonoBehaviour
{
    public int Amount;
    public BasketItemType ItemType;

    public void SetAmount(int amount) => Amount = amount + 1;
    public ShopApplication ShopApplication;

    public void Add()
    {
        ShopApplication.AddToBasket((int)ItemType, Amount);
    }
}
