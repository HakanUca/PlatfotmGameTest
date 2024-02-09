using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float extraSpeedFromApple = 100f; // Extra speed gained from picking up an apple
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool canJump = true;
    private float jumpCooldown = 3f;
    private float jumpTimer = 0f;
    private bool extraSpeedActive = false;

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

        // Jumping
        if (canJump && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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
    }
}
