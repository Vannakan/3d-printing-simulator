using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class DrawRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));

        int layer_mask = LayerMask.GetMask("Interactable");

        if (Physics.Raycast(ray, out hit, 200, layer_mask))
        {
            //Debug.Log("hi");

            if (Input.GetKeyUp(KeyCode.E))
            {
                var test = hit.transform.gameObject.GetComponent<Spawner>();
                test.Spawn();
            }
        }

    }
}
