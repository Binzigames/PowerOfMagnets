using System;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class LightGun : MonoBehaviour
{
    [SerializeField] private float _shootMagnetSpeed = 10f;
    [SerializeField] private float _currentShootSpeed = 0f;

    [Space]
    [SerializeField] private GameObject _shootMagnet;
    [SerializeField] private Transform _shootPos;
    [SerializeField] private GameObject _fillShootPowerBar;
    private bool _canShoot = true;

    void Start()
    {
        StartCoroutine(GunLevitation());
    }

    void Update()
    {
        if(_canShoot)
        {
            if (Input.GetMouseButton(0))
            {
                _currentShootSpeed = Math.Clamp(_currentShootSpeed + Time.deltaTime * 30f, 0f, _shootMagnetSpeed);
                _fillShootPowerBar.transform.localScale = new Vector3(Math.Clamp(_currentShootSpeed / _shootMagnetSpeed, 0f, 1.6f), 1f, 1f);
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (_currentShootSpeed == _shootMagnetSpeed)
                {
                    Shoot();
                }

                _fillShootPowerBar.transform.localScale = new Vector3(0f, 1f, 1f);
                _currentShootSpeed = 0f;
            }
        }
    }

    void Shoot()
    {
        if (!_canShoot)
            return;

        Camera.main.transform.DOShakeRotation(0.5f, 0.5f);

        GameObject spawnedMagnet = Instantiate(_shootMagnet, _shootPos.position, Quaternion.identity);
        MagnetBullet magnetBullet = spawnedMagnet.GetComponent<MagnetBullet>();
        Rigidbody2D spawnedMagnetRb = spawnedMagnet.GetComponent<Rigidbody2D>();

        Vector2 shootDirection = -(transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized;
        spawnedMagnetRb.AddForce(shootDirection * _shootMagnetSpeed, ForceMode2D.Impulse);

        magnetBullet.SetLighGun(this);

        _canShoot = false;
    }

    public void CanShoot()
    {
        _canShoot = true;
    }

    IEnumerator GunLevitation()
    {
        transform.DOLocalMoveY(transform.localPosition.y + 0.15f, 1f);
        yield return new WaitForSeconds(1f);
        transform.DOLocalMoveY(transform.localPosition.y - 0.15f, 1f);
        yield return new WaitForSeconds(1f);
        StartCoroutine(GunLevitation());
    }
}
