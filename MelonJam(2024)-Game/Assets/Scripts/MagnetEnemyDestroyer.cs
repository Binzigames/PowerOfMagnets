using UnityEngine;

public class MagnetEnemyDestroyer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent<GunEnemy>(out GunEnemy gunEnemy))
        {
            if (gunEnemy.TryGetComponent<HealthManager>(out HealthManager healthManager))
            {
                healthManager.TakeDamage(healthManager._maxHealth);
            }
        }
    }
}
