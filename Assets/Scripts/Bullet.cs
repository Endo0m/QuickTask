using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private float _bounceForce = 20f;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // обращаемся к статическому флагу
        bool canBounce = BulletBouncePerk.IsBounceActive;

        if (canBounce && collision.gameObject.CompareTag("Wall"))
        {
            Vector3 reflectDir = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
            GetComponent<Rigidbody>().velocity = reflectDir * _bounceForce;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
