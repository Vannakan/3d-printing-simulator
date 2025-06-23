using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    public WheelCollider BackLeft;
    public WheelCollider BackRight;
    public WheelCollider FrontLeft;
    public WheelCollider FrontRight;
    public Rigidbody RigidBody;
    public float BrakeForce;
    public OrdersManager OrdersManager;

    public event EventHandler OnTriggerEntered;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"{RigidBody.velocity}");
        //if(RigidBody.velocity.z > 1)
        //{
        //    BackLeft.motorTorque = 0;
        //    BackRight.motorTorque = 0;
        //}
    }

    IEnumerator Stop(IEnumerator nextCoroutine = null)
    {
        BackLeft.motorTorque = 0;
        BackLeft.brakeTorque = BrakeForce;
        BackRight.motorTorque = 0;
        BackRight.brakeTorque = BrakeForce;

        while(RigidBody.velocity.z > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }

        BackLeft.motorTorque = 0;
        BackLeft.brakeTorque = 0;
        BackRight.motorTorque = 0;
        BackRight.brakeTorque = 0;

        if (nextCoroutine != null)
        {

            StartCoroutine(nextCoroutine);
            yield break;
        }
        yield break;
    }

    IEnumerator Test(string t)
    {
        Debug.Log(t);
        
        
        yield return new WaitForSeconds(3);
        BackLeft.motorTorque = 100;
        BackRight.motorTorque= 100;
       // OrdersManager.CompleteContract();
         
        yield break;
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TruckTrigger")
        {
            Debug.Log("Hello");
            OnTriggerEntered?.Invoke(this, new());
            StartCoroutine(Stop(Test("Hi")));
        }else if(other.tag == "TruckDestroy")
        {
            Debug.Log("Goodbye");
            Destroy(gameObject);
        }
    }
}
