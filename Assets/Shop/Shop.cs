using UnityEngine;

public class Shop : MonoBehaviour
{
    public SpawnPurchase Spawn;
    public PlayerInventory PlayerInventory;
    public GameObject PrinterPrefab;
    public GameObject FilamentPrefab;

    public int FilamentCost = 25;
    public int PrinterCost = 250;

    public void SpawnFilament()
    {
        if (PlayerInventory.Money < FilamentCost) return;
        
        Spawn.Spawn(FilamentPrefab);
        PlayerInventory.Money -= FilamentCost;
    }

    public void SpawnPrinter()
    {
        if (PlayerInventory.Money < PrinterCost) return;
        
        Spawn.Spawn(PrinterPrefab);
        PlayerInventory.Money -= PrinterCost;
    }

    public void SellItems()
    {
        foreach(var item in PlayerInventory.Items)
        {
            PlayerInventory.Items.Remove(item);
            PlayerInventory.Money += item.Value;
        }
    }
}
