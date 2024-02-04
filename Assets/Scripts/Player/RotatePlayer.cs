using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public Transform Orientation;

    void Update()
    {
        Orientation.rotation = transform.rotation;
    }
}
