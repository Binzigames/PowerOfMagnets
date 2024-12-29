using UnityEngine;

public class GunEnemy : MonoBehaviour
{
    [Header("Bullet Settings")]
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed;
    public float shootInterval;

    [Header("Player Detection")]
    public Vector2 detectionRange;
    public Vector2 shootingRange;
    public LayerMask playerLayer;

    [Header("Movement Settings")]
    public float moveSpeed;
    public Transform groundCheck; // Точка перевірки наявності землі
    public Transform wallCheck; // Точка перевірки наявності стіни
    public float groundCheckRadius; // Радіус перевірки
    public float wallCheckRadius;
    public LayerMask obstacleLayer;

    [Header("Patrol")]
    public float patrolSpeed;
    public Transform pointOne;
    public Transform pointTwo;
    public float deltaPoint;
    public float maxTimeOnPoint;
    public float minTimeOnPoint;
    private float point;
    private float timeOnPoint;

    private float patrolTimer = 0;
    private float shootTimer = 0;
    private Transform player;
    private Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        point = pointOne.position.x;
        timeOnPoint = maxTimeOnPoint;
    }

    private void Update()
    {
        if (player != null && IsPlayerInRange(detectionRange))
        {
            patrolTimer = 0;

            if (transform.position.x < player.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (transform.position.x >= player.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            if (IsPlayerInRange(shootingRange) == false)
            {
                if (!HasObstacleInFront())
                {
                    MoveTowardsPlayer();
                }
                else
                {
                    StopMovement();
                }
            }
            else if (IsPlayerInRange(shootingRange) == true)
            {
                StopMovement();
            }

            //Стрільба
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootInterval)
            {
                shootTimer = 0;
                Shoot();
            }
        }
        else
        {
            Patrol();
            shootTimer = 0;
        }
    }

    private bool IsPlayerInRange(Vector2 range)
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, range, 0, playerLayer);
        return hit != null;
    }

    private bool HasObstacleInFront()
    {
        bool wallInFront = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, obstacleLayer);

        bool groundInFront = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, obstacleLayer);

        return wallInFront || !groundInFront;
    }

    private void MoveTowardsPlayer()
    {
        float direction = transform.rotation.eulerAngles.y == 0 ? 1 : -1;

        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    private void StopMovement()
    {
        rb.velocity = Vector2.zero;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = shootPoint.right * bulletSpeed;
        }
    }

    private void Patrol()
    {
        if (Mathf.Abs(transform.position.x - point) < 0.1f)
        {
            rb.velocity = Vector2.zero;
            patrolTimer += Time.deltaTime;
            if (patrolTimer >= timeOnPoint)
            {
                patrolTimer = 0;
                timeOnPoint = Random.Range(minTimeOnPoint, maxTimeOnPoint);

                float pointBefore = point;
                do
                {
                    point = Random.Range(pointOne.position.x, pointTwo.position.x);
                } while (Mathf.Abs(Mathf.InverseLerp(pointOne.position.x, pointTwo.position.x, point) - Mathf.InverseLerp(pointOne.position.x, pointTwo.position.x, pointBefore)) < deltaPoint);
            }
        }
        else
        {
            if (transform.position.x > point)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                rb.velocity = new Vector2(-patrolSpeed, rb.velocity.y);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                rb.velocity = new Vector2(patrolSpeed, rb.velocity.y);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, detectionRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, shootingRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(wallCheck.position, wallCheckRadius);
    }
}
