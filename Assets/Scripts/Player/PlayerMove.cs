using UnityEditor.SceneManagement;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private GameObject _player;
    private Transform _orientation;

    public float MoveSpeed = 5f;
    public float MouseSensitivity = 500f;

    private float _xRotation = 0f;

    private void Start()
    {
        _player = this.gameObject;
        _rigidbody = GetComponent<Rigidbody>();
        _orientation = GameObject.Find("Main Camera").transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {

            float mouseX = Input.GetAxisRaw("Mouse X") * MouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxisRaw("Mouse Y") * MouseSensitivity * Time.deltaTime;

            _player.transform.Rotate(Vector3.up * mouseX);

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
            _orientation.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        }
    }

    private void FixedUpdate()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;
        _rigidbody.velocity = moveDirection.normalized * MoveSpeed;

    }

}
