using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject _magnet;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnMagnetPos;
    [SerializeField] private List<Transform> _spawnEnemiesPos;
    [SerializeField] private float _throwMagnetsSpeed = 10f;
    [SerializeField] private float _delayAttackTime = 5f;
    private HealthManager _healthManager;
    private int _attackType = 0;
    private PlayerMoving _playerMoving;

    void Start()
    {
        _healthManager = GetComponent<HealthManager>();
        _playerMoving = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoving>();

        _healthManager._onDeathEvent += ()=> {
            SceneChanger._instance.ChangeSceneWithDelay(7);
            Transition._instance.PlayTransition(true);
        };

        StartCoroutine(AttackDelay());
    }

    void Update()
    {
        if (_healthManager.GetHealth() <= 3)
        {

        }
    }

    void Attack()
    {
        if (_attackType == 0)
        {
            _attackType = 1;
            GameObject spawnedMagnet = Instantiate(_magnet, _spawnMagnetPos.position, Quaternion.identity);
            Vector2 direction = -(transform.position - _playerMoving.transform.position).normalized;
            spawnedMagnet.GetComponent<Rigidbody2D>().AddForce(direction * _throwMagnetsSpeed, ForceMode2D.Impulse);
        }
        else if (_attackType == 1)
        {
            _attackType = 0;
            int randomCountOfEnemies = Random.Range(0, 3);
            for (int i = 0; i < randomCountOfEnemies; i++)
            {
                int randomPos = Random.Range(0, 1);
                Instantiate(_enemy, _spawnEnemiesPos[randomPos].position, Quaternion.identity);
            }
        }

        StartCoroutine(AttackDelay());
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(_delayAttackTime);
        Attack();
    }
}
