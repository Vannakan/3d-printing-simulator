using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LoadModelApp : MonoBehaviour
{
    public TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        var test = Directory.GetFiles("C:\\Users\\jacko\\OneDrive\\Documents").Where(e => e.Contains(".obj"));
        foreach(var file in test)
        {
            var obj = Instantiate(Text, transform);
            obj.text = file;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
