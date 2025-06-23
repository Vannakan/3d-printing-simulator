using System.Collections;
using TMPro;
using UnityEngine;

public class CurrentOrderPanel : MonoBehaviour
{
    public OrdersManager OrdersManager;
    public TextMeshProUGUI ItemText;
    public TextMeshProUGUI RemainingText;

    private IEnumerator PollContract()
    {
        while (true)
        {
            if(OrdersManager.CurrentContract != null)
            {
                ItemText.text = OrdersManager.CurrentContract.Order.PrintModel.Name;
                RemainingText.text = $"{OrdersManager.CurrentContract.Order.Amount}";
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void CompleteOrder()
    {

    }

    private void OnEnable()
    {
        StartCoroutine(PollContract());   
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
