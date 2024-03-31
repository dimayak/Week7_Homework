using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _speed = 1.0f;

    void Start()
    {
        Transform playerTransform = FindFirstObjectByType<PlayerMove>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;

        _rigidBody.velocity = toPlayer * _speed;
    }
}
