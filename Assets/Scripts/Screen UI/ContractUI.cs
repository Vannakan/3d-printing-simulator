using Assets.Code;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class ContractUI : MonoBehaviour
{
    public OrdersManager OrdersManager;
    public TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Poll());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator Poll()
    {
        while (true)
        {
            var text = OrdersManager.CurrentContract?.Order != null
                ? $"{WellKnownColours.GetColourName(OrdersManager.CurrentContract.Order.Color)} {OrdersManager.CurrentContract.Order.PrintModel.Name} x{OrdersManager.CurrentContract.Remaining}"
                : "None";
            Text.text = text;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
