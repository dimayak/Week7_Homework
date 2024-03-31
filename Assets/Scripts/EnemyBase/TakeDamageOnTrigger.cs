using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb)
        {
            Bullet bullet = rb.GetComponent<Bullet>();
            if (bullet)
            {
                _enemyHealth.TakeDamage(1);
            }
        }
    }
}
