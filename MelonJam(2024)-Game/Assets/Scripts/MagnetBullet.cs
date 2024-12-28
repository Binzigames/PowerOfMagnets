using UnityEngine;

public class MagnetBullet : MonoBehaviour
{
    private LightGun _lightGun;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent<PlayerMoving>(out PlayerMoving playerMoving))
        {
            _lightGun.CanShoot();
            Destroy(gameObject);
        }

        
    }

    public void SetLighGun(LightGun lightGun)
    {
        _lightGun = lightGun;
    }
}
