using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private int _maxHealth = 8;
    [SerializeField] private float _invulnerableTime = 1.0f;

    [SerializeField] private UnityEvent OnTakeDamage;
    [SerializeField] private AudioSource _addHealthSound;
    [SerializeField] private HealthUI _healthUI;

    private bool _invulnerable = false;
    private float _invulnerableTimer = 0.0f;

    private void Start()
    {
        _healthUI.Setup(_maxHealth);
        _healthUI.DisplayHeatlh(_health);
    }

    private void Update()
    {
        if (_invulnerable)
        {
            _invulnerableTimer += Time.deltaTime;
            if (_invulnerableTimer >= _invulnerableTime)
            {
                _invulnerable = false;
                _invulnerableTimer = 0.0f;
            }
        }
    }

    public void TakeDamage(int damageValue)
    {
        if (!_invulnerable)
        {
            _invulnerable = true;
            _health -= damageValue;

            OnTakeDamage.Invoke();
            _healthUI.DisplayHeatlh(_health);

            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
        }
    }

    public void AddHealth(int healthValue)
    {
        _health += healthValue;
        _healthUI.DisplayHeatlh(_health);
        _addHealthSound.Play();
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    private void Die()
    {
        Debug.Log("You lose");
    }
}
