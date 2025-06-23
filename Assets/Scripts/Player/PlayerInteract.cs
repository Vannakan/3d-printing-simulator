using Assets.Code;
using Assets.ScriptableObjects;
using PrinterBehaviour;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;



//public enum InteractMode
//{
//    All,
//    None,
//    Carrying, //Interacting with an existing prop in the world
//    Placement, //Introducing a new prop on the scene from toolbar
//    Occupied,
//    PC,
//    PCNoLock
//}



// We should probably have the following architecture

// PlayerInteract - Handles all interacts with "Interactable" layer
// PlayerCarry - Handles all  interacts with the "Carryable" layer
// And then something in the middle balancing while ones are active (can be both) and prevents them clashing over each other

// i.e. PlayerController?
//public class PlayerCore : MonoBehaviour
//{
//    InteractMode InteractMode;
//    PlayerCarry PlayerCarry;
//    PlayerInteract PlayerInteract;
//}


//public class PlayerPickup : MonoBehaviour
//{
//    public int PickupProgress = 0;
//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.F))
//        {
//            PickupProgress++;
//            if(PickupProgress >= 100)
//            {
//                // Pickup the item
//                // Call core to deactivate this behaviour?
//            }
//        }
//    }
//}

// Player core should have things that are shared between these scripts
// Like rotation for placing items etc

public class PlayerInteract : MonoBehaviour
{
    public PlayerState PlayerState;

    public PlayerInventory Inventory;
    public PlayerInventoryUI PlayerInventoryUI;
    public GameObject Cam;
    public int InteractDistance;
    public InteractMode InteractMode;

    public GameObject PrinterPrefab;

    private void Start()
    {
        InitializeActionMap();
    }

    private void OnDrawGizmos()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, .1f);
    }

    public Dictionary<(string, ItemType), Action<GameObject>> ActionMap = new();

    void InitializeActionMap()
    {
        ActionMap.Add(("DeliveryBox", ItemType.Print), HandleDeliveryBoxAndPrintInteract);
        ActionMap.Add(("PrinterNode", ItemType.Printer), HandlePrinterNodeAndPrinterInteract);
        ActionMap.Add(("Printer", ItemType.Filament), HandlePrinterAndFilamentInteract);
    }

    void HandleDeliveryBoxAndPrintInteract(GameObject obj)
    {
        var box = obj.GetComponent<DeliveryBox>();
        box.Add();

        Inventory.Remove(Inventory.CurrentEquippedItem);
 //       Debug.Log("DeliveryBoxAndPrintInteract");
    }

    void HandlePrinterNodeAndPrinterInteract(GameObject obj)
    {
        var prefab = PrefabManager.Instance.PrefabMap["Printer"];
        var printer = Instantiate(prefab);
        printer.transform.position = obj.transform.position;

        Inventory.Remove(Inventory.CurrentEquippedItem);

 //       Debug.Log("Created Printer");
    }

    void HandlePrinterAndFilamentInteract(GameObject obj)
    {
        var printer = obj.transform.gameObject.GetComponentInParent<PrintBehaviour>();
    
        printer.SetFilament((Inventory.CurrentEquippedItem.Item as Filament));
        Inventory.Remove(Inventory.CurrentEquippedItem);

   //     Debug.Log("Added Filament");
    }

    private void HandleStorageContainer(GameObject hit)
    {
        var container = hit.GetComponent<StorageContainer>();
        if (container is null)
        {
            Debug.Log("Container is null when expected not null");
            return;
        }

        //Open up inventory UI
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        int interactable = LayerMask.GetMask("Interactable");

        if (!Input.GetKeyUp(KeyCode.F)) return;

        if (Physics.Raycast(ray, out var hit, InteractDistance, interactable))
        {
            // todo we noeed code to identify if we're in this state, if we press F stop whatever we';re doing
            if (hit.transform.gameObject.tag is "StorageContainer" or "DeliveryBox") // todo - rewrite delivery box
            {
                // We need the ability to switch the players "mode" i.e. if they're in "Interact" mode then they cannot move and the mouse is active
                var storageContainer = hit.transform.gameObject.GetComponent<StorageContainer>();
                if (storageContainer is null)
                {
                    Debug.Log("Storage container is null when expected not null");
                    return;
                }

                PlayerInventoryUI.StorageContainer = storageContainer; //todo think of cleanup
                PlayerInventoryUI.Toggle(mode: PlayerInventoryUIMode.Multi);
                return;
            }

            if (Inventory.CurrentEquippedItem?.Item == null) return;
            
            var tuple = (hit.transform.gameObject.tag, Inventory.CurrentEquippedItem.Item.ItemType);

            Debug.Log(tuple.ItemType);


            if (ActionMap.ContainsKey(tuple))
            {
                var action = ActionMap[tuple];
                action(hit.transform.gameObject);
            }

            Debug.Log("PlayerInteract has interacted with a Interactable");
        }
    }
}
