using UnityEngine;

public class Hen : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    private Transform _playerTransform;
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _accelerationTime = 1.0f;

    private void Start()
    {
        _playerTransform = FindFirstObjectByType<PlayerMove>().transform;
    }
    private void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _rigidBody.mass * (toPlayer * _speed - _rigidBody.velocity) / _accelerationTime;

        _rigidBody.AddForce(force);
    }
}
