using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public string[] tagsDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // FindAnyObjectByType<SceneChanger>().ChangeSceneWithDelay(SceneManager.GetActiveScene().buildIndex);
            collision.transform.position = collision.GetComponent<PlayerMoving>()._spawnPos;
            HealthManager healthManager = collision.transform.GetComponent<HealthManager>();
            healthManager.AddHealth(healthManager._maxHealth);
        }
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
