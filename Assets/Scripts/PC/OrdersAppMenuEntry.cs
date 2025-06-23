using Assets.Code;
using TMPro;
using UnityEngine;

public class OrdersAppMenuEntry : MonoBehaviour
{
    public Order Order;
    public TextMeshProUGUI ItemText;
    public TextMeshProUGUI QuantityText;
    public OrdersApp OrdersApp;

    public void SetOrder(Order order)
    {
        Order = order;
        ItemText.text = order.PrintModel.Name;
        QuantityText.text = $"{order.Amount}";
    }

    public void AcceptOrder()
    {
        OrdersApp.CreateContract(Order);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
