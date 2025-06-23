using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryBoxDropOffController : MonoBehaviour
{
    // Todo type to DeliveryBox
    public List<GameObject> Contents;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DeliveryBox")
        {

        }
    }
}
