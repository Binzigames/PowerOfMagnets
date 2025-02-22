using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public bool isUnlockMoving;
    public float speed;
    public float jumpForce;
    public float stairsForce;

    private Rigidbody2D rb;
    private float moveInput;

    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private KeyCode downStairsKey;
    [SerializeField] private LayerMask jumpLayer;
    [SerializeField] private LayerMask stairsLayer;
    [SerializeField] private float radiusJumping;
    [SerializeField] private Transform feetPos;
    private bool isGrounded;
    private bool isStairs;
    private float defaultGravityScale;

    public bool _canMove { get; private set;}

    private Animator animator;

    public Vector2 _spawnPos { get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        defaultGravityScale = rb.gravityScale;

        _spawnPos = transform.position;
        _canMove = true;
    }

    private void Update()
    {
        if (!_canMove)
        {
            rb.velocity = new Vector3(0, rb.velocity.y);  
            return;
        }

        Jumping();
        Stairs();
    }

    private void FixedUpdate()
    {
        if (!_canMove)
            return;

        Walking();
    }

    private void Walking()
    {
        moveInput = Input.GetAxis("Horizontal");
        if (isUnlockMoving == true)
        {
            if (moveInput > 0)
            {
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
                animator.SetBool("isRunning", true);
            }
            else if (moveInput < 0)
            {
                transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
                animator.SetBool("isRunning", true);
            }
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }

        if (moveInput == 0 || isUnlockMoving == false)
        {
            animator.SetBool("isRunning", false);
        }

    }

    private void Jumping()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, radiusJumping, jumpLayer);
        if ((isGrounded == true) && (isUnlockMoving == true) && (Input.GetKeyDown(jumpKey)))
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("isJumping", true);
        }
        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }
        if (isGrounded == false)
        {
            animator.SetBool("isJumping", true);
        }
    }

    private void Stairs()
    {
        isStairs = Physics2D.OverlapCircle(feetPos.position, radiusJumping, stairsLayer);
        if (isStairs == true && isUnlockMoving == true)
        {
            rb.gravityScale = 0;

            if (Input.GetKey(jumpKey))
            {
                rb.velocity = Vector2.up * stairsForce;
            }

            else if (Input.GetKey(downStairsKey))
            {
                rb.velocity = Vector2.down * stairsForce;
            }

            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
        else
        {
            rb.gravityScale = defaultGravityScale;
        }
    }

    public void SetCanMove(bool canMove)
    {
        _canMove = canMove;
    }
}
