using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private UnityEvent _onDeath;
    private int _maxHealth;

    void Start()
    {
        _maxHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        _health = Math.Clamp(_health - damage, 0, _maxHealth);

        if (_health == 0)
        {
            _onDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
