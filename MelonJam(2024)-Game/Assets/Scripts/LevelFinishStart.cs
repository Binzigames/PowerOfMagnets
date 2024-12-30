using UnityEngine;

public class LevelFinishStart : MonoBehaviour
{
    public int nextSceneIndex;
    public float delayChanging;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindAnyObjectByType<SceneChanger>().ChangeSceneWithDelay(nextSceneIndex);
        }
    }
}
