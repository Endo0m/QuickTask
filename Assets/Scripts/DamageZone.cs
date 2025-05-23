using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private float _damage = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(_damage);
            }
        }
    }
}
