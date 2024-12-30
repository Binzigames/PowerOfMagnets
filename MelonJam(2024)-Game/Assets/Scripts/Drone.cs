using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private bool _canMove = false;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!_canMove)
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y);
            return;
        }

        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), 0) * _speed;
        direction.y = _rb.velocity.y;
        _animator.SetFloat("WalkSpeed", direction.magnitude);
        _rb.velocity = direction;

        if (direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }

        // if (Input.GetKeyDown())
    }

    public void SetCanMove(bool canMove)
    {
        _canMove = canMove;
    }
}
