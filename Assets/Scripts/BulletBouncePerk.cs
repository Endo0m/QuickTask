// BulletBouncePerk.cs
using UnityEngine;

public class BulletBouncePerk : MonoBehaviour
{
    public static bool IsBounceActive { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsBounceActive = true;
            Debug.Log("Перк: отскок пуль активирован");
            Destroy(gameObject);
        }
    }
}
