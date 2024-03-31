using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxMoveSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private bool _grounded;
    [SerializeField] private Transform _colliderTransform;
    [SerializeField] private float _sitSpeed = 5.0f;

    private Vector3 _sitScale = new Vector3(1.0f, 0.5f, 1.0f);


    private void Update()
    {
        // Sit
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || !_grounded)
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, _sitScale, Time.deltaTime * _sitSpeed);
        }
        else
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, Vector3.one, Time.deltaTime * _sitSpeed);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_grounded)
            {
                _rigidBody.AddForce(0, _jumpSpeed, 0, ForceMode.VelocityChange);
            }
        }
    }

    private void FixedUpdate()
    {
        float speedMultiplier = 1.0f;
        float hor = Input.GetAxis("Horizontal");

        // Controlling character in air is more difficult
        if (!_grounded)
        {
            speedMultiplier = 0.2f;

            // Limit speed
            if (hor > 0.0f && _rigidBody.velocity.x > _maxMoveSpeed)
            {
                speedMultiplier = 0.0f;
            }
            if (hor < 0.0f && _rigidBody.velocity.x < -_maxMoveSpeed)
            {
                speedMultiplier = 0.0f;
            }
        }

        // Move

        float forceX = hor * _moveSpeed * speedMultiplier;
        _rigidBody.AddForce(forceX, 0, 0, ForceMode.VelocityChange);

        // Drag horizontal
        if (_grounded)
        {
            _rigidBody.AddForce(-_rigidBody.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        float angle = Vector3.Angle(other.contacts[0].normal, Vector3.up);
        if (angle < 45.0f)
        {
            _grounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        _grounded = false;
    }
}
