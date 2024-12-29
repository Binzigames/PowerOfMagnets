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
    [SerializeField] private LayerMask jumpLayer;
    [SerializeField] private LayerMask stairsLayer;
    [SerializeField] private float radiusJumping;
    [SerializeField] private Transform feetPos;
    private bool isGrounded;
    private bool isStairs;

    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Jumping();
        Stairs();
    }

    private void FixedUpdate()
    {
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
        if (isStairs == true && isUnlockMoving == true && Input.GetKey(jumpKey))
        {
            rb.velocity = Vector2.up * stairsForce;
        }
    }
}
