using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This needs to be something different.. maybe this is the truck controller.. controls the lifecycle of a truck
public class TruckFactory : MonoBehaviour
{
    public GameObject TruckPrefab;
    public GameObject? CurrentTruck;

    public TruckController SpawnTruck()
    {
        if (CurrentTruck == null)
            CurrentTruck = Instantiate(TruckPrefab, gameObject.transform);

        CurrentTruck.transform.SetParent(null);

        return CurrentTruck.GetComponent<TruckController>();    
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
