using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTest : MonoBehaviour
{
    public WheelCollider Collider;
    public GameObject WheelMesh;
    public int Speed;
    // Start is called before the first frame update
    void Start()
    {
        Collider.motorTorque = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        Collider.GetWorldPose(out var position, out var rotation);
       WheelMesh.transform.position = position;
        WheelMesh.transform.rotation = rotation;
       // WheelMesh.<MeshRenderer>().transform.rotation = rotation;

      //  WheelMesh.transform.rotation = new Quaternion(rotation.x, WheelMesh.transform.rotation.y, WheelMesh.transform.rotation.z, WheelMesh.transform.rotation.w);
        //transform.Rotate(0,Collider.rpm / 60 * 360 * Time.deltaTime, 0);
    }
}
