using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _pointer;
    [SerializeField] private Vector3 _minRotation, _maxRotation;
    [SerializeField] private float _minAngle, _maxAngle;
    [SerializeField] private float _rotationSpeed;

    void Update()
    {
        transform.position = _target.position;

        // Поворачиваем голову
        float targetAngle = 0.0f;
        // У Pointer два значения вращения по y - 90 и 270
        if (_pointer.rotation.eulerAngles.y == 270)
        {
            targetAngle = _maxAngle;
        }
        else
        {
            targetAngle = _minAngle;
        }
        float currentAngle = transform.rotation.eulerAngles.y;
        // Вращаем просто по Оси Y на угол от _minAngle до _maxAngle
        transform.rotation = Quaternion.Euler(0.0f, Mathf.LerpAngle(currentAngle, targetAngle, _rotationSpeed * Time.deltaTime), 0.0f);
    }
}
