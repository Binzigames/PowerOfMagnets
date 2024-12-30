using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб ворога
    public GameObject specialObject; // Об'єкт, що з'являється після знищення всіх ворогів
    public GameObject triggerObject; // Об'єкт тригера
    public int enemyCount = 10; // Кількість ворогів для спавну

    private int enemiesDefeated = 0;
    private bool playerInCollider = false; // Перевірка на наявність гравця у тригері
    private bool spawningStarted = false; // Перевірка, чи розпочато спавн ворогів
    private GameObject[] spawnedEnemies;

    void Start()
    {
        specialObject.SetActive(false); // Приховуємо об'єкт на початку
        if (triggerObject != null)
        {
            triggerObject.SetActive(true); // Активуємо тригерний об'єкт
        }
        spawnedEnemies = new GameObject[enemyCount];
    }

    void Update()
    {
        if (playerInCollider && !spawningStarted)
        {
            spawningStarted = true;
            Debug.Log("Player entered trigger, spawning all enemies.");
            SpawnAllEnemies();
        }

        if (spawningStarted && AllEnemiesDefeated())
        {
            Debug.Log("All enemies defeated. Game over!");
            // Додаємо логіку програшу
            GameOver();
        }
    }

    void SpawnAllEnemies()
    {
        Vector2 spawnPosition = transform.position; // Встановлюємо точку спавну
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            spawnedEnemies[i] = enemy;
        }
    }

    bool AllEnemiesDefeated()
    {
        foreach (GameObject enemy in spawnedEnemies)
        {
            if (enemy != null) return false;
        }
        return true;
    }

    void GameOver()
    {
        Debug.Log("Game Over logic executed.");
        specialObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger.");
            playerInCollider = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger.");
            playerInCollider = false;
        }
    }
}
