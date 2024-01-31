using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 _moveDirection;
    public Transform Orientation;
    private float moveSpeed = 3f;
    public Rigidbody Rigidbody;

    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        _moveDirection = Orientation.forward * vertical + Orientation.right * horizontal;

        var normalized = _moveDirection.normalized;
        Rigidbody.velocity = normalized * moveSpeed;
        //Rigidbody.AddForce(normalized * moveSpeed, ForceMode.Force);

       // transform.position += _moveDirection.normalized * moveSpeed * Time.deltaTime;
    }
}
