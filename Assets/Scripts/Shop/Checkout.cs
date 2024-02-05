using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Checkout : MonoBehaviour
{
    public PlayerInventory PlayerInventory;

    public void CheckoutBasket(List<BasketItem> items)
    {
        if (PlayerInventory.Money >= items.Sum(e => e.Value))
        {
            foreach (var item in items)
            {
                PlayerInventory.Money -= item.Value;
                PlayerInventory.Items.Add(new Item() //This is a code smell, just use one type 
                {
                    Name = item.Type.ToString(),
                    Value = item.Value,
                    Type = item.Type
                });
            }
        }

    }
}
