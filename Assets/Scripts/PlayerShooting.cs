// PlayerShooting.cs
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    [Header("Ќастройки")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _bulletSpeed = 20f;
    [SerializeField] private float _fireRate = 0.25f;

    [Header("UI")]
    [SerializeField] private Button _shootButton;

    [Header("—сылки")]
    [SerializeField] private PlayerAnimator _playerAnimator;

    private bool _isShooting;
    private float _nextFireTime;

    private void Awake()
    {
        if (_shootButton != null)
        {
            // по нажатию (тап) Ч одиночный выстрел
            _shootButton.onClick.AddListener(FireBullet);

            // по зажатию Ч очередь
            var trigger = _shootButton.gameObject.AddComponent<UnityEngine.EventSystems.EventTrigger>();

            var entryDown = new UnityEngine.EventSystems.EventTrigger.Entry
            {
                eventID = UnityEngine.EventSystems.EventTriggerType.PointerDown
            };
            entryDown.callback.AddListener(_ => StartShooting());
            trigger.triggers.Add(entryDown);

            var entryUp = new UnityEngine.EventSystems.EventTrigger.Entry
            {
                eventID = UnityEngine.EventSystems.EventTriggerType.PointerUp
            };
            entryUp.callback.AddListener(_ => StopShooting());
            trigger.triggers.Add(entryUp);
        }
        else
        {
            Debug.LogError(" нопка стрельбы не назначена!");
        }
    }


    private void Update()
    {
        if (_isShooting && Time.time >= _nextFireTime)
        {
            FireBullet();
            _nextFireTime = Time.time + _fireRate;
        }

        _playerAnimator.SetShooting(_isShooting);
    }


    public void StartShooting()
    {
        _isShooting = true;
    }

    public void StopShooting()
    {
        _isShooting = false;
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * _bulletSpeed;
    }

}
