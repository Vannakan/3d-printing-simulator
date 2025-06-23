using PrinterBehaviour;
using System.Collections;
using TMPro;
using UnityEngine;

public class PrintStatusUiBinding : MonoBehaviour
{
    public PrintBehaviour Printer;
    public TextMeshProUGUI TextMeshPro;
    public string Prefix;

    void Start()
    {
        StartCoroutine(SetStatus());
    }

    IEnumerator SetStatus()
    {
        while (true)
        {
            TextMeshPro.text = $"{Prefix} {Printer.PrintStatus2}";
            yield return new WaitForSeconds(0.2f);
        }
    }
}
