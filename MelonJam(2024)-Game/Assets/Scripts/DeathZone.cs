using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public string[] tagsDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < tagsDestroy.Length; i++)
        {
            if (collision.tag == tagsDestroy[i])
            {
                Destroy(collision.gameObject);
                break;
            }
        }
    }
}
