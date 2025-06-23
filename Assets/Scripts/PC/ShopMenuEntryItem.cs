using Assets.Code;
using Assets.ScriptableObjects;
using TMPro;
using UnityEngine;

public class ShopMenuEntryItem : MonoBehaviour
{
    public Shop Shop;
    public Item Item;
    public TextMeshProUGUI Text;

    public void BuyItem()
    {
         Shop.BuyItem(Item);
    }

    public void Initialize(Shop shop, Item item)
    {
        Shop = shop;
        Text.text = item.Name;
        Item = item;
    }
}
