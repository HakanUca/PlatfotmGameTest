using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    public static int count = 0;

    // This function is called when the player collects the object
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that triggered the collision has a CharacterMovement component
        CharacterMovement playerCharacter = other.GetComponent<CharacterMovement>();

        if (playerCharacter != null)
        {
            // Add your collectible logic here
            // For example, you might increase the player's score, play a sound effect, etc.

            // Once collected, destroy the collectible object
            // Also increase the collected skull objects count.
            Destroy(gameObject);
            count++;
        }
    }

    //This is the condition for the next level or game finish.
    void Update()
    {
        if (count == 3)
        {
            SceneManager.LoadScene(1);
        }
    }
}
