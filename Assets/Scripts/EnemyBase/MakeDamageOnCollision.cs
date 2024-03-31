using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;
    private void OnCollisionEnter(Collision other)
    {
        Rigidbody rigidbody = other.rigidbody;
        if (rigidbody)
        {
            PlayerHealth playerHealth = rigidbody.GetComponent<PlayerHealth>();
            if (playerHealth)
            {
                playerHealth.TakeDamage(_damageValue);
            }
        }
    }
}
