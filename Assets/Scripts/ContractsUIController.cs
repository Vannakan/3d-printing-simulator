using Assets.Code;
using Assets.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// todo decide wtf tod ow ith orders

//how do we represent CustomerOrders and StoreOrders
//CustomerOrdersController
//StoreOrdersController
public class ContractsUIPanelEntry : MonoBehaviour 
{
    public TextMeshProUGUI AmountText;
    public TextMeshProUGUI RecipientText;
    public TextMeshProUGUI PrintModelText;
    public TextMeshProUGUI ColourText;
    public Image FavouriteIcon;

    private Contract _contract;
    public Contract Contract { get => _contract;  set => SetOrder(value); }

    private void SetOrder(Contract contract)
    {
        var order = contract.Order;
        AmountText.text = order.Amount.ToString();
        RecipientText.text = contract.Recipient.ToString();
        PrintModelText.text = order.PrintModel.name;
        ColourText.text = WellKnownColours.GetColourName(order.Color);
        _contract = contract;
    }
}


public class ContractsUIController : MonoBehaviour
{
    public OrdersManager OrdersManager;
    public GameObject Container;
    public PlayerState PlayerState;

    public GameObject OrderUIPanelEntryGO;

    public int FavouriteOrderId;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //private void OnEnable()
    //{
    //    //destroy all entrries
        //recreate from orders manager

    //    foreach(Transform entry in Container.transform)
    //    {
    //        Destroy(entry);
    //    }

    //    foreach(var contract in OrdersManager.CurrentContracts)
    //    {
    //        var entry = Instantiate(OrderUIPanelEntryGO, Container.transform);
    //        entry.GetComponent<ContractsUIPanelEntry>().Contract = contract;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            Container.SetActive(!Container.activeInHierarchy);
            HandlePlayerModeChange(Container.activeInHierarchy);
        }
    }

    private void HandlePlayerModeChange(bool panelActive)
    {
        if (panelActive)
            PlayerState.PlayerMode = Assets.Scripts.Player.PlayerMode.Interact;
        else
            PlayerState.PlayerMode = Assets.Scripts.Player.PlayerMode.Walk;
    }
}
