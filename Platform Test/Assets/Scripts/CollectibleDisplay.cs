//------------------------------------
//      HAKAN UCA
//  GITHUB:https://github.com/HakanUca
//------------------------------------

using UnityEngine;
using TMPro;

public class CollectibleDisplay : MonoBehaviour
{
    // Reference to the TextMeshPro text component to display the collectible count.
    public TMP_Text timeText;

    // Update is called once per frame
    void Update()
    {
        // Check if the TextMeshPro text component is assigned.
        if (timeText != null)
        {
            // Update the displayed time (collectible count).
            DisplayTime(Collectible.count);
        }
    }

    // Function to display the collectible count.
    void DisplayTime(int countScore)
    {
        // Set the text of the timeText component to the current collectible count.
        timeText.text = string.Format("{0}", countScore);
    }
}
