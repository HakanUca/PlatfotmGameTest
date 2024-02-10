using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Singleton instance
    private static CharacterMovement _instance;
    public static CharacterMovement Instance { get { return _instance; } }

    // Your existing variables...
    public float moveSpeed = 0f;
    public float extraSpeedFromApple = 5f;
    public float jumpForce = 10f;
    public float extraJumpFromApple = 3f;

    private Rigidbody2D rb;
    private bool canJump = true;
    private float jumpCooldown = 3f;
    private float jumpTimer = 0f;
    private bool extraSpeedActive = false;
    private bool extraJumpActive = false;

    public Animator animator;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject); // Destroy duplicate instances
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Move the character horizontally
        float horizontalInput = Input.GetAxis("Horizontal");

        // Apply extra speed if it's active
        float currentMoveSpeed = extraSpeedActive ? moveSpeed + extraSpeedFromApple : moveSpeed;

        Vector2 movement = new Vector2(horizontalInput * currentMoveSpeed, rb.velocity.y);
        rb.velocity = movement;

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // Flip character sprite if moving left
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Flip horizontally
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Facing right, revert scale
        }

        // Jumping
        if (canJump && Input.GetButtonDown("Jump"))
        {
            float currentJumpForce = extraJumpActive ? jumpForce + extraJumpFromApple : jumpForce;

            rb.velocity = new Vector2(rb.velocity.x, currentJumpForce);
            canJump = false;
            jumpTimer = jumpCooldown;
        }

        // Jump cooldown
        if (!canJump)
        {
            jumpTimer -= Time.deltaTime;
            if (jumpTimer <= 0f)
            {
                canJump = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object is an apple
        if (collision.gameObject.name == "Potion")
        {
            // Apply extra speed from the apple
            extraSpeedActive = true;
            Destroy(collision.gameObject); // Destroy the apple object
            // You can also add some visual/audio feedback here
        }
        // Check if the collided object is an apple
        if (collision.gameObject.name == "PotionJump")
        {
            // Apply extra speed from the apple
            extraJumpActive = true;
            Destroy(collision.gameObject); // Destroy the apple object
            // You can also add some visual/audio feedback here
        }
    }
}
