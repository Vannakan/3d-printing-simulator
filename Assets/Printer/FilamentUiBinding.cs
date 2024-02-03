using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FilamentUiBinding : MonoBehaviour
{
    public Printer Printer;
    public string Prefix;
    private float _lastVal;
    public TextMeshProUGUI TextMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        
        TextMeshPro.text = $"{Prefix} {Printer.TotalFilament}";
    }

    // Update is called once per frame
    void Update()
    {
        if(_lastVal != Printer.TotalFilament)
        {
            _lastVal = Printer.TotalFilament;
            TextMeshPro.text = $"{Prefix} {Printer.TotalFilament}";
        }
    }
}
