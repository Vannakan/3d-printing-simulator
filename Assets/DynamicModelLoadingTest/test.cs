using Dummiesman;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class test : MonoBehaviour
{
    public string T;
    // Start is called before the first frame update
    void Start()
    {
        using var stream = new FileStream("C:\\Users\\jacko\\OneDrive\\Documents\\Chevrolet_Camaro_SS_Low.obj", FileMode.Open, FileAccess.Read);
        //var textStream = new MemoryStream(Encoding.UTF8.GetBytes("C:\\Users\\jacko\\OneDrive\\Documents\\sdcard.obj"));
        var model = new OBJLoader().Load(stream);
        model.transform.parent = transform;
        model.transform.localPosition = Vector3.zero;
        model.transform.localScale = new Vector3(.25f, .25f, .25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
