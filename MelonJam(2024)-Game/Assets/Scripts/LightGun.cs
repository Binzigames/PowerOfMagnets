using UnityEngine;

public class LightGun : MonoBehaviour
{
    [SerializeField] private float _shootMagentSpeed = 10f;

    [Space]
    [SerializeField] private GameObject _shootMagnet;
    [SerializeField] private Transform _shootPos;
    private bool _canShoot = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (!_canShoot)
            return;

        GameObject spawnedMagnet = Instantiate(_shootMagnet, _shootPos.position, Quaternion.identity);
        MagnetBullet magnetBullet = spawnedMagnet.GetComponent<MagnetBullet>();
        Rigidbody2D spawnedMagnetRb = spawnedMagnet.GetComponent<Rigidbody2D>();

        Vector2 shootDirection = -(transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized;
        spawnedMagnetRb.AddForce(shootDirection * _shootMagentSpeed, ForceMode2D.Impulse);

        magnetBullet.SetLighGun(this);

        _canShoot = false;
    }

    public void CanShoot()
    {
        _canShoot = true;
    }
}
