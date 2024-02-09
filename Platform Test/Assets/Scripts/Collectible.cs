using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Collectible : MonoBehaviour
{

    public TMP_Text timeText;

    // Add any variables you need for your collectible here
    // For example, you might have a variable for the points the collectible gives

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
            Destroy(gameObject);
            count++;
        }

    }
    void Update()
    {
        if (timeText != null)
        {
            DisplayTime(count);
        }
        if (count == 3)
        {
            SceneManager.LoadScene(1);

        }
    }

    void DisplayTime(int countScore)
    {
        timeText.text = string.Format("{0}", countScore);
    }
}