using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class PrinterUIController : MonoBehaviour
{

    public GameObject Panel;
    public GameObject ButtonPrefab;

    public List<string> Filaments = new List<string>() { "PLA", "ABS", "PETG", "PLA+" };
    // Start is called before the first frame update
    void Start()
    {
        foreach (var filament in Filaments)
        {
            GameObject button = Instantiate(ButtonPrefab);
            button.GetComponent<TextMeshProUGUI>().text = filament;
            button.transform.SetParent(Panel.transform);//Setting button parent
            button.transform.GetChild(0).GetComponent<Text>().text = "This is button text";//Changing text

        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
