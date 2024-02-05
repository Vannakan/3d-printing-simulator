using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public enum BasketItemType
{
    Printer,
    Filament,
    Upgrade,
    Prop
}
public class BasketItem
{
    public BasketItemType Type;
    public int Value;
}

public class TestBasket : MonoBehaviour
{
    public List<BasketItem> BasketItems = new List<BasketItem>();
    public TextMeshProUGUI TotalText;

    public void AddItem(BasketItemType item, int amount)
    {
        for(var i = 0; i < amount; i++)
        {
            BasketItems.Add(GetBasketItem(item));
        }
        TotalText.text = $"Basket ({BasketItems.Count})";
    }

    private BasketItem GetBasketItem(BasketItemType item) => item switch
    {
        BasketItemType.Printer => new BasketItem() { Type = item, Value = 275},
        BasketItemType.Filament => new BasketItem() { Type = item, Value = 25 },
        BasketItemType.Prop => new BasketItem() { Type = item, Value = 400 }
    };
}
