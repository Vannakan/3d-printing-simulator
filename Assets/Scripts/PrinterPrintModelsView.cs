using Assets.Scripts.World_UI.Printer;
using PrinterBehaviour;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//todo: make this inherit from PrintMenuSelectListScreen
public class PrinterPrintModelsView : PrintMenuSelectListScreen
{
    public PrintBehaviour Printer;
    public GameObject PrintMenuSelectListItemGO;
    //public PrintMenuSelectListScreen ThisIsUgly;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Initialize()
    {
        if (isInitialized) return;

        foreach (var model in Printer.PrintModels)
        {
            var go = Instantiate(PrintMenuSelectListItemGO, transform);
            go.SetActive(true); //temp
            go.GetComponentInChildren<TextMeshProUGUI>().text = model.Name;
            UnityAction test = new(() => Printer.SetPrintModel(model));

            go.GetComponentInChildren<Button>().onClick.AddListener(test);
        }
        base.Initialize();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
