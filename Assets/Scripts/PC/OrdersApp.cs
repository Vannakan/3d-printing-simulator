using Assets.Code;
using Assets.ScriptableObjects;
using AutoFixture;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

//public class ItemSpawnManager
//{
//    public
//}



public class SDCard : MonoBehaviour
{
    public List<PrintData> Items;
}

public class PrintApp : MonoBehaviour
{
    public PcTower PcTower; // Todo make this better

    public List<PrintData> PrintItems;

    public void AddToSd(PrintData data)
    {
        if(PcTower.SDCard != null)
        {
            PcTower.SDCard.Items.Add(data);
        }
    }

    public void RemoveFromSd(PrintData data)
    {
        if(PcTower.SDCard != null)
        {
            PcTower.SDCard.Items.Remove(data); 
        }
    }
}


public class OrdersMenuEntry : MonoBehaviour
{
    public Order Order;
}

public class OrdersApp : MonoBehaviour
{
    public GameObject OrderMenuEntryGO;
    public GameObject MultiList;
    public OrdersManager OrdersManager;

    public GameObject CurrentOrderPanel;
    public GameObject SelectOrderPanel;

    public List<OrdersMenuEntry> MenuEntries;

    // Start is called before the first frame update
    void Start()
    {
        ChooseScreen();
        var orders = OrdersManager.Orders;
        foreach (var order in orders)
        {
            var go = Instantiate(OrderMenuEntryGO, MultiList.transform);
            
            go.SetActive(true); // todo - put into prefab set as active and reference it that way
            var oe = go.GetComponent<OrdersAppMenuEntry>();
            oe.OrdersApp = this;
            oe.SetOrder(order);
        }
    }

    private void Awake()
    {
        
    }

    private void ChooseScreen()
    {
        if (OrdersManager.CurrentContract != null)
        {
            CurrentOrderPanel.SetActive(true);
            SelectOrderPanel.SetActive(false);
        }
        else
        {
            CurrentOrderPanel.SetActive(false);
            SelectOrderPanel.SetActive(true);
        }
    }

    private void OnEnable()
    {
        ChooseScreen();
    }

    public void CreateContract(Order order)
    {
        OrdersManager.CreateContract(order);
        ChooseScreen();
    }

    public void CancelContract()
    {
        OrdersManager.CancelContract();
        ChooseScreen();
    }

    public void CompleteContract()
    {
        OrdersManager.BeginDelivery();
        //OrdersManager.CompleteContract();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
