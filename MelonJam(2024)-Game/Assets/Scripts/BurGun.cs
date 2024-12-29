using System.Collections;
using DG.Tweening;
using UnityEngine;

public class BurGun : MonoBehaviour
{
    [SerializeField] private GameObject _magnet;
    [SerializeField] private Transform _magnetEndPos;
    [SerializeField] private Transform _magnetSpawnPos;
    [SerializeField] private float _shootDelay = 1f;
    [SerializeField] private float _comeBackTime = 2f;

    void Start()
    {
        StartCoroutine(ShootMagnet());
    }

    void Update()
    {
        
    }

    public IEnumerator ShootMagnet()
    {
        yield return new WaitForSeconds(_shootDelay);
        GameObject spawnedMagnet = Instantiate(_magnet, _magnetSpawnPos.position, Quaternion.identity);
        spawnedMagnet.GetComponent<BurMagnetBullet>().SetBurGun(this);
        spawnedMagnet.transform.DOMove(_magnetEndPos.position, _comeBackTime / 2).onComplete += ()=> spawnedMagnet.transform.DOMove(transform.position, _comeBackTime / 2);
    }
}
