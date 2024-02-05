using System.Collections.Generic;
using UnityEngine;

public class ShopApplication : MonoBehaviour
{
    public GameObject CurrentPage;
    public TestBasket TestBasket;
    public Checkout Checkout;

    private void OnEnable()
    {
        if(CurrentPage != null)
        { CurrentPage.SetActive(true); }
    }

    public void AddToBasket(int type, int amount)
    {
        TestBasket.AddItem((BasketItemType)type, amount);
    }

    public void CheckoutBasket()
    {
        Checkout.CheckoutBasket(TestBasket.BasketItems);
        TestBasket.BasketItems.Clear();
    }

    public void SwitchPage(GameObject gameObject)
    {
        if(CurrentPage != null)
            CurrentPage.SetActive(false);

        CurrentPage = gameObject;
        CurrentPage.SetActive(true);
    }
}
