using Assets.Code;
using Assets.ScriptableObjects;
using Assets.Scripts.GameManager;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeliveryInfo
{
    int Id;
    public int Day;
    public int Time;
}

public class PickupDeliveryInfo : DeliveryInfo
{
    public string Recipient;
}

public class DropOffDeliveryInfo : DeliveryInfo
{
    public List<Item> Items;
}


public class DeliveryManager : MonoBehaviour
{
    public StorageContainer DropOffStorageContainer;
    public StorageContainer PickUpStorageContainer;
    public List<DropOffDeliveryInfo> DropOffDeliveries = new();
    public List<PickupDeliveryInfo> PickupDeliveries = new();
    public TruckFactory TruckFactory;

    // Start is called before the first frame update
    void Start()
    {
        TimeOfDayController.Instance.OnTimeChanged += OnTimeChanged;
    }

    void PollDropOffDeliveries(int time)
    {
        var delivery = DropOffDeliveries.FirstOrDefault(e => e.Time <= time);
        if (delivery is not null)
        {
            DropOffDeliveries.Remove(delivery);
            var truck = TruckFactory.SpawnTruck();
            truck.OnTriggerEntered += (obj, e) =>
            {
                Debug.Log("ENTERED");

                DropOffStorageContainer.InventoryItems.AddRange(delivery.Items.Select(e => new InventoryItem(e)));
            };
        }
    }

    void PollPickUpDeliveries(int time)
    {
        var delivery = PickupDeliveries.FirstOrDefault(e => e.Time <= time);
        if (delivery is not null)
        {
            PickupDeliveries.Remove(delivery);
            var truck = TruckFactory.SpawnTruck();
            truck.OnTriggerEntered += (obj, e) =>
            {
                Debug.Log("ENTERED");

              //  DropOffStorageContainer.InventoryItems.AddRange(delivery.Items.Select(e => new InventoryItem(e)));
            };
        }
    }
    void OnTimeChanged(float time)
    {
        var converted = TimeHelper.ConvertToTwelveHour((int)time);
        PollDropOffDeliveries(converted);
        PollPickUpDeliveries(converted);
    }
}
