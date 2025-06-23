using System;
using UnityEngine;

// Todo - need to think about how we can pass better item data between ui/inventory etc
// e.g.
// If we have red filament, it'd be cool to render red filament
// if we have a printer that has 3 upgrades, it'd be cool if it rendered the upgrades in hand space
public class Hands : MonoBehaviour
{
    public GameObject EquippedItemContainer;

    public Toolbar Toolbar;
    public PlayerInventory PlayerInventory;

    private GameObject? current;
    // Start is called before the first frame update
    void Start()
    {
        //This should just subscribe to a PlayerEquipped OnCurrentItemCha
        Toolbar.OnToolbarChanged += (_, __) =>
        {
            try
            {
                foreach (Transform transform in EquippedItemContainer.transform)
                {
                    Destroy(transform.gameObject);
                }

                var inventoryItem = Toolbar.CurrentItem.InventoryItem;
                //var inventoryItem = PlayerInventory.CurrentEquippedItem;
                if (inventoryItem != null)
                {
                    Instantiate(inventoryItem.Item.WorldObject, EquippedItemContainer.transform);
                }
            } catch (Exception e)
            {
                // lazy as fuck
            }
        };
    }

    public void SetCurrent(GameObject newObject)
    {
        current?.SetActive(false);
        current = newObject;
        current.SetActive(true);
    }
}
