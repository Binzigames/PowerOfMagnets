using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public bool isUnlockMoving;
    public float speed;
    public float jumpForce;

    private Rigidbody2D Rigidbody2D;
    private float moveInput;

    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private LayerMask JumpLayer;
    [SerializeField] private float RadiusJumping;
    [SerializeField] private Transform feetPos;
    private bool isGrounded;

    private Animator animator;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Jumping();
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
                transform.eulerAngles = new Vector3(0, 0, 0);
                animator.SetBool("isRunning", true);
            }
            else if (moveInput < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                animator.SetBool("isRunning", true);
            }
            Rigidbody2D.velocity = new Vector2(moveInput * speed, Rigidbody2D.velocity.y);
        }

        if (moveInput == 0 || isUnlockMoving == false)
        {
            animator.SetBool("isRunning", false);
        }

    }

    private void Jumping()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, RadiusJumping, JumpLayer);
        if ((isGrounded == true) && (isUnlockMoving == true) && (Input.GetKeyDown(jumpKey)))
        {
            Rigidbody2D.velocity = Vector2.up * jumpForce;
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
}
