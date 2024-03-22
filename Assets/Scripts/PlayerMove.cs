using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private bool _grounded;

    private void FixedUpdate()
    {
        _rigidBody.AddForce(Input.GetAxis("Horizontal") * _moveSpeed, 0, 0, ForceMode.VelocityChange);
        _rigidBody.AddForce(-_rigidBody.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);
    }
}
