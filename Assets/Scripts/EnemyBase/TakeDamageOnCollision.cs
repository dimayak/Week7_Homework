using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private bool _dieOnAnyCollision = false;
    private void OnCollisionEnter(Collision other)
    {
        Rigidbody rb = other.rigidbody;
        if (rb)
        {
            Bullet bullet = rb.GetComponent<Bullet>();
            if (bullet)
            {
                _enemyHealth.TakeDamage(1);
            }
        }

        if (_dieOnAnyCollision)
        {
            Destroy(gameObject);
        }
    }
}
