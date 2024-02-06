using UnityEngine;

public class Shop : MonoBehaviour
{
    public SpawnPurchase Spawn;
    public GameManager GameManager;
    public GameObject PrinterPrefab;
    public GameObject FilamentPrefab;
    private PlayerStats _playerStats;
    private PlayerInventory _playerInventory;

    public int FilamentCost = 25;
    public int PrinterCost = 250;

    public void LateUpdate()
    {
        do
        {
            _playerStats = GameManager.Player.GetComponent<PlayerController>().PlayerStats;
            _playerInventory = GameManager.Player.GetComponent<PlayerController>().PlayerInventory;
        } while (false);

    }

    public void SpawnFilament()
    {
        if (_playerStats.Money < FilamentCost) return;

        Spawn.Spawn(FilamentPrefab);
        _playerStats.Money -= FilamentCost;
    }

    public void SpawnPrinter()
    {
        if (_playerStats.Money < PrinterCost) return;

        Spawn.Spawn(PrinterPrefab);
        _playerStats.Money -= PrinterCost;
    }

    public void SellItems()
    {
        foreach (var item in _playerInventory.Items)
        {
            _playerInventory.Items.Remove(item);
            _playerStats.Money += item.Value;
        }
    }
}
