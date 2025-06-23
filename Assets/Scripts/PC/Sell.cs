
using Assets.Code;
using Assets.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Orders : MonoBehaviour
{
    public Order CurrentOrder;
    public List<Order> AvailableOrders = new();
}

public class Sell : MonoBehaviour
{
    public PlayerInventory Inventory;
    public TextMeshProUGUI Text;
    public AudioSource AudioSource;

    public void OnEnable()
    {
        var items = Inventory.ItemCollection.Items.Where(e => e.Item.ItemType is ItemType.Print);
        Text.text = $"x{items.Count()} items for ${items.Sum(e => (e.Item as Print).Value)}";
    }

    public void SellItems()
    {
        var items = Inventory.ItemCollection.Items.Where(e => e.Item.ItemType is ItemType.Print);
        var sum = items.Sum(e => (e.Item as Print).Value);
        Inventory.Money += sum;
        foreach(var item in items)
        {
            Inventory.Remove(item);
        }
        AudioSource.Play();
        Text.text = $"Thank you!";
    }

}
