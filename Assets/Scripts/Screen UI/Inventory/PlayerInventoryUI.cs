using Assets.Code;
using Assets.ScriptableObjects;
using Assets.Scripts.Screen_UI;
using Assets.Scripts.Screen_UI.Inventory;
using System;
using UnityEngine;
public enum PlayerInventoryUIMode
{
    Single,
    Multi
}
public class PlayerInventoryUI : MonoBehaviour // PlayerInventoryUIController
{
    public PlayerInventoryUIMode Mode;
    public PlayerInventory Inventory;
    public GameObject PlayerInventoryUIContainer;
    public PlayerInventoryUIPanel PlayerInventoryUIPanel;
    public StorageContainer StorageContainer; // think of a betterw ay of handling this all
    public MultiInventoryController MultiInventoryPanel;
    public PlayerState PlayerState;
    public GameObject ItemInfoPanel;

    public void ToggleMulti()
    {
        if (PlayerInventoryUIContainer.activeInHierarchy)
            ToggleSingleInventory();
        
        MultiInventoryPanel.gameObject.SetActive(!MultiInventoryPanel.gameObject.activeInHierarchy);
        MultiInventoryPanel.Initialize();

        HandlePlayerModeChange(MultiInventoryPanel.gameObject.activeInHierarchy);

        if (!MultiInventoryPanel.isActiveAndEnabled)
        {
            ItemInfoPanel.SetActive(false);
        }
    }

    public void ToggleSingleInventory()
    {
        // todo: make sure multi is toggled off
        if (MultiInventoryPanel.gameObject.activeInHierarchy)
            ToggleMulti();

        PlayerInventoryUIContainer.SetActive(!PlayerInventoryUIContainer.activeInHierarchy);
        if (PlayerInventoryUIContainer.activeInHierarchy)
            PlayerInventoryUIPanel.RenderPlayerInventoryItems(Inventory.ItemCollection.Items);


        HandlePlayerModeChange(PlayerInventoryUIPanel.gameObject.activeInHierarchy);
    }

    public void Toggle(PlayerInventoryUIMode mode = PlayerInventoryUIMode.Single)
    {
        if(mode == PlayerInventoryUIMode.Single)
        {
            ToggleSingleInventory();
        }else if (mode == PlayerInventoryUIMode.Multi)
        {
            ToggleMulti();
        }else
        {
            throw new Exception("PLAYERINVENTORYUI");
        }
    }

    private void HandlePlayerModeChange(bool panelActive)
    {
        if (panelActive)
            PlayerState.PlayerMode = Assets.Scripts.Player.PlayerMode.Interact;
        else
            PlayerState.PlayerMode = Assets.Scripts.Player.PlayerMode.Walk;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerInventoryUIPanel.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            Toggle();
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            Toggle(PlayerInventoryUIMode.Multi);
        }
    }
}