using Assets.Code;
using Assets.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

// tODO RENAME TO TOOLBARCONTROLLER
public class Toolbar : MonoBehaviour
{
    public Sprite PrinterSprite;
    public Sprite PrintSprite;
    public Sprite SpoolSprite;
    public Sprite TableSprite;

    public PlayerInventory PlayerInventory;

    public List<ToolbarItem> ToolbarItems = new();
    public ToolbarItem CurrentItem;

    public EventHandler OnToolbarChanged;

    private Dictionary<ItemType, Sprite> SpriteMap = new Dictionary<ItemType, Sprite>();


    public int Index;

    public Dictionary<int, KeyCode> Keys = new();


    public List<InventoryItem> ToolbarInventoryItems = new();
    public GameObject ToolbarItemPrefab;
    public int ToolbarItemCount;

    // logic for calculating free toolbars
    // logic for adding item to free toolbar on inventory change

    
    public void AddItemToToolbar(InventoryItem item)
    {
        //add logic to check whether item is in players inventory?
    }

    
    public void Start()
    {
        SpriteMap.Add(ItemType.Print, PrintSprite);
        SpriteMap.Add(ItemType.Printer, PrinterSprite);
        SpriteMap.Add(ItemType.Filament, SpoolSprite);
        SpriteMap.Add(ItemType.Prop, TableSprite);

        for (int i = 0; i < ToolbarItemCount; i++)
        {
            var toolbarItem = Instantiate(ToolbarItemPrefab, transform);
            ToolbarItems.Add(toolbarItem.GetComponent<ToolbarItem>());

            KeyCode keyCode;
            if(i == 0)
                keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), $"Alpha{1}");
            else
                keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), $"Alpha{i+1}");

            Keys.Add(i, keyCode);
        }

        SetCurrentItem(0);

        PlayerInventory.InventoryItemAdded += (_, item) =>
       {
        //   if (ToolbarItems.Any(e => e.InventoryItem == item)) return;
            foreach (var toolbarItem in ToolbarItems)
            {
                if (toolbarItem.InventoryItem is null || toolbarItem.InventoryItem.Item is null)
                {
                    toolbarItem.SetInventoryItem(item);
                    OnToolbarChanged?.Invoke(this, new());
                   break;
                }
            }
        };


        PlayerInventory.InventoryItemRemoved += (_, item) =>
        {
            foreach (var toolbarItem in ToolbarItems)
            {
                if (toolbarItem.InventoryItem == null) continue;
                if (item.Id == toolbarItem.InventoryItem.Id)
                {
                    toolbarItem.SetInventoryItem(null);
                    OnToolbarChanged?.Invoke(this, new());
                }
            }
        };

        //PlayerInventory.InventoryChanged += (_, item) =>
        //{
        //    foreach (var toolbarItem in ToolbarItems)
        //    {
        //        if (toolbarItem.InventoryItem == null) continue;

        //        if (item.Id == toolbarItem.InventoryItem.Id)
        //        {
        //            toolbarItem.SetInventoryItem(null);
        //            OnToolbarChanged?.Invoke(this, new());
        //        }
        //    }
        //};

    }


    public void SetCurrentItem(int index)
    {
        if (ToolbarItems.Count < index) return;

        if (CurrentItem is not null)
            CurrentItem.SetBorderColour(Color.white);

        CurrentItem = ToolbarItems[index];
        Index = index;

        PlayerInventory.SetEquippedItem(CurrentItem.InventoryItem);

        CurrentItem.SetBorderColour(Color.green);
    }


    // Put this logic back into a PlayerEquipped component
    public void Update()
    {
        if (Input.mouseScrollDelta.y > 0 && Index + 1 < ToolbarItems.Count)
        {
            SetCurrentItem(Index + 1);
            if (PlayerInventory.ItemCollection.Items.Count > 0)
                OnToolbarChanged?.Invoke(this, new());

        }
        else if (Input.mouseScrollDelta.y < 0 && Index - 1 >= 0)
        {
            SetCurrentItem(Index - 1);
            if (PlayerInventory.ItemCollection.Items.Count > 0)
                OnToolbarChanged?.Invoke(this, new());
        }

        if (!Input.anyKeyDown) return;

        foreach ((int index, KeyCode key) in Keys)
        {
            if(Input.GetKeyDown(key))
            {
                SetCurrentItem(index);
                OnToolbarChanged?.Invoke(this, new());
            }    
        }

    }
}
