//------------------------------------
//      HAKAN UCA
//  GITHUB:https://github.com/HakanUca
//------------------------------------


using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Singleton instance for easy access from other scripts
    private static CharacterMovement _instance;
    public static CharacterMovement Instance { get { return _instance; } }

    // Movement speed variables
    public float moveSpeed = 0f;
    public float extraSpeedFromApple = 5f;

    // Jumping variables
    public float jumpForce = 10f;
    public float extraJumpFromApple = 3f;

    // Rigidbody component for physics interactions
    private Rigidbody2D rb;

    // Jumping control variables
    private bool canJump = true;
    private float jumpCooldown = 1f;
    private float jumpTimer = 0f;

    // Power-up status variables
    private bool extraSpeedActive = false;
    private bool extraJumpActive = false;

    // Animator component for character animations
    public Animator animator;

    // Called when the script instance is being loaded
    private void Awake()
    {
        // Ensure only one instance of the class exists
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Called before the first frame update
    private void Start()
    {
        // Get the Rigidbody component attached to the character
        rb = GetComponent<Rigidbody2D>();
    }

    // Called once per frame
    private void Update()
    {
        // Read input for horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate current movement speed, considering power-up status
        float currentMoveSpeed = extraSpeedActive ? moveSpeed + extraSpeedFromApple : moveSpeed;

        // Apply horizontal movement to the character
        Vector2 movement = new Vector2(horizontalInput * currentMoveSpeed, rb.velocity.y);
        rb.velocity = movement;

        // Update animator parameter for character speed
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // Flip character sprite based on movement direction
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // Check for jump input and handle jumping mechanics
        if (canJump && Input.GetButtonDown("Jump"))
        {
            // Apply jump force, considering power-up status
            float currentJumpForce = extraJumpActive ? jumpForce + extraJumpFromApple : jumpForce;
            rb.velocity = new Vector2(rb.velocity.x, currentJumpForce);
            canJump = false;
            jumpTimer = jumpCooldown;
        }

        // Handle jump cooldown
        if (!canJump)
        {
            jumpTimer -= Time.deltaTime;
            if (jumpTimer <= 0f)
            {
                canJump = true;
            }
        }

        // Check for attack input
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Attack");
        }
    }

    // Called when the Collider2D enters a trigger zone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check for collision with speed power-up
        if (collision.gameObject.name == "Potion")
        {
            extraSpeedActive = true;
            Destroy(collision.gameObject);
        }
        // Check for collision with jump power-up
        if (collision.gameObject.name == "PotionJump")
        {
            extraJumpActive = true;
            Destroy(collision.gameObject);
        }
    }
}
