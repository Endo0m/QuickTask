using UnityEngine;

/// <summary>
/// Простое следование камеры за игроком с оффсетом и сглаживанием.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;        // Игрок
    [SerializeField] private Vector3 _offset = new Vector3(0, 10, -10); // Положение камеры относительно игрока
    [SerializeField] private float _smoothSpeed = 5f;  // Плавность

    private void LateUpdate()
    {
        if (_target == null) return;

        Vector3 desiredPosition = _target.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(_target); // Смотрим на игрока
    }
}
