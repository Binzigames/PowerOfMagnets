using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ ������
    public GameObject specialObject; // ��'���, �� �'��������� ���� �������� ��� ������
    public GameObject triggerObject; // ��'��� �������
    public int enemyCount = 10; // ʳ������ ������ ��� ������

    private int enemiesDefeated = 0;
    private bool playerInCollider = false; // �������� �� �������� ������ � ������
    private bool spawningStarted = false; // ��������, �� ��������� ����� ������
    private GameObject[] spawnedEnemies;

    void Start()
    {
        specialObject.SetActive(false); // ��������� ��'��� �� �������
        if (triggerObject != null)
        {
            triggerObject.SetActive(true); // �������� ��������� ��'���
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
            // ������ ����� ��������
            GameOver();
        }
    }

    void SpawnAllEnemies()
    {
        Vector2 spawnPosition = transform.position; // ������������ ����� ������
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
