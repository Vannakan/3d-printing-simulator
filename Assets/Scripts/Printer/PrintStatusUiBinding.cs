using TMPro;
using UnityEngine;

public class PrintStatusUiBinding : MonoBehaviour
{
    public Printer Printer;
    public TextMeshProUGUI TextMeshPro;
    public string Prefix;

    private string _lastVal;

    void Start()
    {
        TextMeshPro.text = $"{Prefix} {Printer.PrintStatus}";
    }

    void Update()
    {
        if (_lastVal == Printer.PrintStatus) return;
        
        _lastVal = Printer.PrintStatus;
        TextMeshPro.text = $"{Prefix} {Printer.PrintStatus}";
    }
}
