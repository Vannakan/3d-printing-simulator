using Assets.Code;
using Assets.ScriptableObjects;
using System;
using UnityEngine;

//probably rename to player equipment
public class PlayerInventory : MonoBehaviour
{
    public int MaxSize;
    public int Money;

    public event EventHandler<InventoryItem> InventoryChanged;
    public event EventHandler<int> MoneyChanged;
    public event EventHandler EquippedItemChanged;
    public event EventHandler<InventoryItem> InventoryItemAdded;
    public event EventHandler<InventoryItem> InventoryItemRemoved;

    // The plan might be to add X number of empty inventory items, swapping and ordering in the inventory would be a lot easier
    public ItemCollection ItemCollection = new();
    public InventoryItem CurrentEquippedItem { get; private set; }

    public void SetEquippedItem(InventoryItem item)
    {
        //if item exists in inventory
        CurrentEquippedItem = item;
        EquippedItemChanged?.Invoke(this, new());
    }

    public void Add(InventoryItem item)
    {
        ItemCollection.Add(item);
        InventoryItemAdded?.Invoke(this, item);
        InventoryChanged?.Invoke(this, item);
        EquippedItemChanged?.Invoke(this, new());
    }
    public void Add(Item item)
    {
        //todo : check if it exists and handle accordingly
        var inventoryItem = new InventoryItem(item);
        ItemCollection.Add(inventoryItem);
        InventoryItemAdded?.Invoke(this, inventoryItem);
        InventoryChanged?.Invoke(this, inventoryItem);
        EquippedItemChanged?.Invoke(this, new());
    }

    public void Remove(InventoryItem inventoryItem)
    {
        ItemCollection.Remove(inventoryItem);
        // todo only emit events if its successful
        InventoryItemRemoved?.Invoke(this, inventoryItem);
        InventoryChanged?.Invoke(this, inventoryItem);
        EquippedItemChanged?.Invoke(this, new());
    }
}
