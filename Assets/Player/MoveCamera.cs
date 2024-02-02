using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    public GameObject Target;

    // Update is called once per frame
    void Update() => transform.position = cameraPosition.position;


    public void MoveToTarget()
    {

    }

    public void MoveToOriginalPosition()
    {

    }
}
