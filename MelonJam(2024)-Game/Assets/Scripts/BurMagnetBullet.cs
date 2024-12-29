using UnityEngine;

public class BurMagnetBullet : MonoBehaviour
{
    private BurGun _burGun;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent<PlayerMoving>(out PlayerMoving playerMovement))
        {
            HealthManager healthManager = other.transform.GetComponent<HealthManager>();
            healthManager.TakeDamage(1);
            _burGun.StartCoroutine(_burGun.ShootMagnet());
            Destroy(gameObject);
        }
        else if (other.transform.TryGetComponent<BurGun>(out BurGun burGun))
        {
            _burGun.StartCoroutine(_burGun.ShootMagnet());
            Destroy(gameObject);
        }
    }

    public void SetBurGun(BurGun burGun)
    {
        _burGun = burGun;
    }
}
