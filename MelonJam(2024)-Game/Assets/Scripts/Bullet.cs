using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime;
    public int ground;
    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HealthManager healthManager = collision.transform.GetComponent<HealthManager>();
            healthManager.TakeDamage(1);
            Destroy(gameObject);
            Debug.Log("Player damage");
        }
        if (collision.gameObject.layer == ground)
        {
            Destroy(gameObject);
        }
    }
}
