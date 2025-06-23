using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    public GameObject Target;

    // Update is called once per frame
   // void Update() 

    private void FixedUpdate() => transform.position = cameraPosition.position;


    public void MoveToTarget()
    {

    }

    public void MoveToOriginalPosition()
    {

    }
}
