using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform orientation;
    private float xRotation;
    private float yRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
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
