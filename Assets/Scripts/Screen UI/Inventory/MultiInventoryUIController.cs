using Assets.Code;
using Assets.Scripts.Screen_UI.Inventory;
using UnityEngine;

public class MultiInventoryController : MonoBehaviour
{
    public PlayerInventoryUI PlayerInventoryController; // todo: replace/rename to InventoryUIController - its mediating all of this shit

    public InventoryUIPanel PlayerInventoryUIPanel;
    public InventoryUIPanel StorageInventoryUIPanel;

    public void Initialize()
    {
        PlayerInventoryUIPanel.Initialize();
        PlayerInventoryUIPanel.RenderInventoryItems(PlayerInventoryController.Inventory.ItemCollection.Items);
        StorageInventoryUIPanel.Initialize();
        StorageInventoryUIPanel.RenderInventoryItems(PlayerInventoryController.StorageContainer.InventoryItems);
    }

    public void Swap(InventoryItem item, InventoryUIPanel a, InventoryUIPanel b )
    {
        if (a == PlayerInventoryUIPanel)
        {
            PlayerInventoryController.Inventory.Add(item);
            PlayerInventoryController.StorageContainer.InventoryItems.Remove(item);
        }
        else
        {
            PlayerInventoryController.Inventory.Remove(item);
            PlayerInventoryController.StorageContainer.InventoryItems.Add(item);
        }
    }

}
