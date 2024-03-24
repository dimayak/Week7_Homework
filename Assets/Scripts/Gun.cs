using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _bulletSpeed = 10.0f;
    [SerializeField] private float _shotPeriod = 0.2f;
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private GameObject _flash;
    private float _timer = 0.0f;
    private float _hideFlashTimer = 0.0f;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _shotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0.0f;

                GameObject bullet = Instantiate(_bulletPrefab, _spawn.position, _spawn.rotation);
                bullet.GetComponent<Rigidbody>().velocity = _spawn.forward * _bulletSpeed;

                _shotSound.Play();
                _flash.SetActive(true);
                _hideFlashTimer = 0.0f;
            }
        }

        _hideFlashTimer += Time.deltaTime;
        if (_hideFlashTimer >= 0.1f)
        {
            if (_flash.activeSelf)
            {
                _flash.SetActive(false);
            }
        }
    }


}
