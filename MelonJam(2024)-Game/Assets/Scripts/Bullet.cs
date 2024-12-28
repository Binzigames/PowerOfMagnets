using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Player damage");
        }
        if (collision.gameObject.layer == 3) //ground
        {
            Destroy(gameObject);
        }
    }
}
