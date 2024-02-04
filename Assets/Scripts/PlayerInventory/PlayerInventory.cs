using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string Name { get; set; }
    public int Value { get; set; }
}

public class PlayerInventory : MonoBehaviour
{
    public List<Item> Items = new List<Item>();
    public int Money;
}
