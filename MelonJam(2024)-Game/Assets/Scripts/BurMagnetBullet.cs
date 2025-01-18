using UnityEngine;

public class BurMagnetBullet : MonoBehaviour
{
    private BurGun _burGun;

    void Start()
    {
        // Optional initialization
    }

    void Update()
    {
        // Optional per-frame logic
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMoving>(out PlayerMoving playerMovement))
        {
            if (other.TryGetComponent<HealthManager>(out HealthManager healthManager))
            {
                healthManager.TakeDamage(1);
            }
            TriggerMagnetEffect();
        }
        else if (other.TryGetComponent<BurGun>(out BurGun burGun))
        {
            TriggerMagnetEffect();
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }

    private void TriggerMagnetEffect()
    {
        if (_burGun != null)
        {
            _burGun.StartCoroutine(_burGun.ShootMagnet());
        }
        else
        {
            Debug.LogWarning("BurGun is not set for the bullet!");
        }
        Destroy(gameObject);
    }

    public void SetBurGun(BurGun burGun)
    {
        _burGun = burGun;
    }
}
