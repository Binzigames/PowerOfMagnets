using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private UnityEvent _onDeath;
    public int _maxHealth { get; private set; }

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
            
            if (TryGetComponent<Animator>(out Animator animator))
            {
                animator.SetTrigger("death");
            }

            if (TryGetComponent<PlayerMoving>(out PlayerMoving playerMovement))
            {
                playerMovement.SetCanMove(false);
                Transition._instance.PlayTransition(true);
                SceneChanger._instance.ChangeSceneWithDelay(SceneManager.GetActiveScene().buildIndex);
            }

            Destroy(gameObject, 1f);
        }
    }

    public void AddHealth(int health)
    {
        _health = Math.Clamp(_health + health, 0, _maxHealth);
    }

    public int GetHealth()
    {
        return _health;
    }
}
