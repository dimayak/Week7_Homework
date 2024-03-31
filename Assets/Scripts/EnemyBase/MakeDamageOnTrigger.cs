using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb)
        {
            PlayerHealth playerHealth = rb.GetComponent<PlayerHealth>();
            if (playerHealth)
            {
                playerHealth.TakeDamage(_damageValue);
            }
        }
    }
}
