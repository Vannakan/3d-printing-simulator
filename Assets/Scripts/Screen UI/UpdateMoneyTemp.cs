using System.Collections;
using TMPro;
using UnityEngine;

public class UpdateMoneyTemp : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public PlayerInventory PlayerInventory;
    private int _lastVal;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateMoney());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator UpdateMoney()
    {
        while (true)
        {
            _lastVal = PlayerInventory.Money;
            Text.text = $"{_lastVal}";
            yield return new WaitForSeconds(0.2f);
        }
    }
}
