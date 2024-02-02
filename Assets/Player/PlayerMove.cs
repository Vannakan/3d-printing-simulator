using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform Orientation;
    public Rigidbody Rigidbody;

    public float MoveSpeed;

    private Vector3 _moveDirection;

    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        _moveDirection = Orientation.forward * vertical + Orientation.right * horizontal;
        Rigidbody.velocity = _moveDirection.normalized * MoveSpeed;
    }
}
