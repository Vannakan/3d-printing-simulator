using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform orientation;
    private float xRotation;
    private float yRotation;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * 300;
        var mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * 300;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

       
   
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
