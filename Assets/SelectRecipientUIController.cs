using Assets.ScriptableObjects;
using Assets.Scripts.Screen_UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectRecipientUIController : MonoBehaviour
{
    public OrdersManager OrdersManager;
    public GameObject SelectRecipientUIEntryGO;
    public GameObject Panel;
    public GameObject Container;
    public PlayerState PlayerState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Container.SetActive(true);
            ToggleOn(null);
        }
    }

    public void ToggleOn(DeliveryBox box)
    {
        CreateRecipientEntryList(box);
    }

    public void ToggleOff()
    {
        // Destroy all entries
    }

    void CreateRecipientEntryList(DeliveryBox box)
    {
        foreach(var order in OrdersManager.CurrentContracts)
        {
            var go = Instantiate(SelectRecipientUIEntryGO, Panel.transform);
            go.SetActive(true);
            var entry = go.GetComponent<SelectRecipientUIEntryItem>();
            entry.OnButtonClicked += (obj, recipient) =>
            {
                box.Recipient = recipient;
            };

            entry.SetRecipient(order.Recipient);
        }
    }
}

