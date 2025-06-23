using Assets.Code;
using Assets.ScriptableObjects;
using Assets.Scripts.GameManager;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<Color> FilamentColors;

    public ShopDatabase ShopDatabase;

    public SpawnPurchase Spawn;
    public PlayerInventory PlayerInventory;

    public GameObject PickupPrefab;

    public AudioSource AudioSource;

    public GameObject ShopMenuEntryGO;
    // Buy screen
    public GameObject ItemsPanel;
    // Checkout screen
    public GameObject CheckoutPanel;
    public GameObject CheckoutButton;

    public DeliveryManager DeliveryManager;

    public DebugSettings DebugSettings;
    public List<Item> Basket = new();


    private void Start()
    {
        foreach (var item in ShopDatabase.Items)
        {
            var so = Instantiate(item);
            var entry = Instantiate(ShopMenuEntryGO, ItemsPanel.transform);
            entry.GetComponent<ShopMenuEntryItem>().Initialize(this, so);
        }
    }

    public void ToggleCheckoutPanel()
    {
        foreach (Transform item in CheckoutPanel.transform)
        {
            Destroy(item.gameObject);
        }

        ItemsPanel.SetActive(false);
        CheckoutPanel.SetActive(true);
        CheckoutButton.SetActive(true);

        foreach (var item in Basket)
        {
            var so = Instantiate(item);
            var entry = Instantiate(ShopMenuEntryGO, CheckoutPanel.transform);
            entry.GetComponent<ShopMenuEntryItem>().Initialize(this, so);
        }
    }

    public void Checkout()
    {
        ItemsPanel.SetActive(true);
        CheckoutPanel.SetActive(false);
        CheckoutButton.SetActive(false);

        foreach (Transform item in CheckoutPanel.transform)
        {
            Destroy(item.gameObject);
        }

        ScheduleDelivery(Basket);
        Basket = new();

    }

    public void BuyItem(Item item)
    {
        //if(!DebugSettings.InstantDelivery)
        //{
        //    ScheduleDelivery(item);
        //} else
        //{
        //    Spawn.Spawn(PickupPrefab, (gameObject) => { gameObject.GetComponent<Pickup>().Item = item; });
        //}

        Basket.Add(item);

        AudioSource.Play();
    }

    private void ScheduleDelivery(Item item)
    {
        var deliveryInfo = new DropOffDeliveryInfo()
        {
            Time = (int)TimeOfDayController.Instance.TimeOfDay + 3,
            Items = new List<Item>() { item }
        };
        DeliveryManager.DropOffDeliveries.Add(deliveryInfo);

        ToastNotificationManager.Instance.Create("Scheduled delivery");
    }

    private void ScheduleDelivery(List<Item> items)
    {
        var deliveryInfo = new DropOffDeliveryInfo()
        {
            Time = (int)TimeOfDayController.Instance.TimeOfDay + 3,
            Items = items
        };
        DeliveryManager.DropOffDeliveries.Add(deliveryInfo);

        ToastNotificationManager.Instance.Create("Scheduled delivery");
    }

}
