//------------------------------------
//      HAKAN UCA
//  GITHUB:https://github.com/HakanUca
//------------------------------------



using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    // Static variable to keep track of the total number of collectibles collected
    public static int count = 0;

    // Triggered when the collectible collider overlaps with another collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the player character
        CharacterMovement playerCharacter = other.GetComponent<CharacterMovement>();

        // If the collider belongs to the player character
        if (playerCharacter != null)
        {
            // Destroy the collectible object
            Destroy(gameObject);
            // Increment the count of collected collectibles
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the count of collected collectibles equals the desired number
        if (count == 3)
        {
            // Load the next scene when the desired number of collectibles is reached
            SceneManager.LoadScene(2);
        }
    }
}
