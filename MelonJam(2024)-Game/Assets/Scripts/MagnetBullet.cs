using UnityEngine;

public class MagnetBullet : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    private LightGun _lightGun;
    private bool _damaged = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!_damaged)
        {
            if (other.transform.TryGetComponent<GunEnemy>(out GunEnemy gunEnemy))
            {
                HealthManager healthManager = other.transform.GetComponent<HealthManager>();
                healthManager.TakeDamage(_damage);

                _damaged = true;
            }
        }

        if (other.transform.TryGetComponent<PlayerMoving>(out PlayerMoving playerMoving))
        {
            _lightGun.CanShoot();
            Destroy(gameObject);
        }  

        if (other.transform.TryGetComponent<Drone>(out Drone drone))
        {
            other.transform.GetChild(0).GetComponent<LightGun>().CanShoot();
            Destroy(gameObject);
        }

    }

    public void SetLighGun(LightGun lightGun)
    {
        _lightGun = lightGun;
    }
}
