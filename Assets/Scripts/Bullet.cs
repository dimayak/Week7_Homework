using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;

    private void Start()
    {
        Destroy(gameObject, 4.0f);
    }

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(_effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
