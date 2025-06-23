using Assets.Code;
using Assets.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

// Todo: rename this to inventory
public class StorageContainerItem 
{
    public Item Item;
    public int Stack;
}

public class StorageContainer : MonoBehaviour
{
    public List<Item> Items;
    public List<InventoryItem> InventoryItems; //todo rename to Items
}
