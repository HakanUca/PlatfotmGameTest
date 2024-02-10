using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Collectible : MonoBehaviour
{

    public TMP_Text timeText;
    public static int count = 0;

    // Add any variables you need for your collectible here
    // For example, you might have a variable for the points the collectible gives

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

    //This is the update method for the displaying for the collectible skull objects.
    //Also when the necessary conditions accepted the other scene can loaded.
    void Update()
    {
        if (timeText != null)
        {
            DisplayTime(count);
        }
        //This is the condition for the next level or game finish.
        if (count == 3)
        {
            SceneManager.LoadScene(1);

        }
    }


    // This is the displaying method for the score objects.
    void DisplayTime(int countScore)
    {
        timeText.text = string.Format("{0}", countScore);
    }
}