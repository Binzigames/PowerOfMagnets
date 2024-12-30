using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public string[] tagsDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindAnyObjectByType<SceneChanger>().ChangeSceneWithDelay(SceneManager.GetActiveScene().buildIndex);
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
