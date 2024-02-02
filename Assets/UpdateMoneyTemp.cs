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
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerInventory.Money != _lastVal)
        {
            _lastVal = PlayerInventory.Money;
            Text.text = $"Money: ${_lastVal}";
        }
    }
}
