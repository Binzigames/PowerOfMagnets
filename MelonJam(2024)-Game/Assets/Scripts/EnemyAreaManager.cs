using UnityEngine;

public class EnemyAreaManager : MonoBehaviour
{
    public int enemyNumber;
    public float respawnTimer;
    private float timer = 0;
    private bool spawner = false;
    private int enemyCounter = 0;

    public GameObject finish;
    public Transform pointToSpawn;
    public GameObject enemyPrefab;
    public GameObject leverToActivate;

    private void Update()
    {
        if (spawner == true && enemyNumber > enemyCounter)
        {
            timer += Time.deltaTime;
            if (timer >= respawnTimer)
            {
                timer = 0;
                enemyCounter++;
                Instantiate(enemyPrefab, pointToSpawn.position, pointToSpawn.rotation);
            }
        }
        if (enemyNumber <= enemyCounter)
        {
            spawner = false;
            leverToActivate.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            finish.SetActive(true);
            spawner = true;
        }
    }
}
