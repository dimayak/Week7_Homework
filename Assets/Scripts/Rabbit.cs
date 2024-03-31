using UnityEngine;

public class Rabbit : MonoBehaviour
{
    [SerializeField] private float _attackPeriod = 7.0f;
    [SerializeField] private Animator _animator;

    private float _timer = 0.0f;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _attackPeriod)
        {
            _timer = 0.0f;
            _animator.SetTrigger("Attack");
        }
    }
}
