using Assets.Code;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeliveryBox : MonoBehaviour
{
    public int Capacity;
    public int Current;

    public int ContractId;
    public string CurrentItemName = "None";
    public OrdersManager OrderManager;
    public MeshRenderer ClosedBox;
    public MeshRenderer OpenBox;

    public TextMeshProUGUI VolumeText;
    public TextMeshProUGUI ItemTypeText;

    public string Recipient;

    private IEnumerator PollVolume()
    {
        while (true)
        {
            VolumeText.text = $"{Current}/{Capacity}";
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator PollItemType()
    {
        while (true)
        {
            ItemTypeText.text = CurrentItemName;
            yield return new WaitForSeconds(0.2f);
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        OrderManager.OrderAdded += HandleNewOrder;
        StartCoroutine(PollVolume());
        StartCoroutine(PollItemType());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleDeliveryBoxStateChanged()
    {
        if (Current >= Capacity)
        {
            ClosedBox.gameObject.SetActive(true);
            OpenBox.gameObject.SetActive(false);
        //    OrderManager.CompleteContract();
        }
        else
        {
            ClosedBox.gameObject.SetActive(false);
            OpenBox.gameObject.SetActive(true);
        }
    }

    public void HandleNewOrder(object src, Order order)
    {
        Current = 0;
        Capacity = order.Amount;
        CurrentItemName = order.Text;
        HandleDeliveryBoxStateChanged();
    }

    public bool Add()
    {
        if(Current >= Capacity) 
            return false;

        Debug.Log("Added to the box");

        Current++;
        HandleDeliveryBoxStateChanged();
        return true;
    }
}
