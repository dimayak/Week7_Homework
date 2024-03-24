using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _pointer;
    [Header("Head rotation")]
    [SerializeField] private float _minAngle;
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _rotationSpeed;

    void Update()
    {
        transform.position = _target.position;

        // Поворачиваем голову
        float targetAngle = _minAngle;
        // У Pointer два значения вращения по y - 90 и 270
        if (_pointer.rotation.eulerAngles.y == 270)
        {
            targetAngle = _maxAngle;
        }
        float currentAngle = transform.rotation.eulerAngles.y;
        // Вращаем просто по Оси Y на угол от _minAngle до _maxAngle
        transform.rotation = Quaternion.Euler(0.0f, Mathf.LerpAngle(currentAngle, targetAngle, _rotationSpeed * Time.deltaTime), 0.0f);
    }
}
