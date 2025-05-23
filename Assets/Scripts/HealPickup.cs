// HealPickup.cs
using UnityEngine;

public class HealPickup : MonoBehaviour
{
    [SerializeField] private float _healAmount = 30f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null && health.Heal(_healAmount))
            {
                Destroy(gameObject); // ”ничтожаем аптечку, если было восстановление
            }
        }
    }
}
