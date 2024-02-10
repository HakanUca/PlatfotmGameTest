using UnityEngine;
using TMPro;

public class CollectibleDisplay : MonoBehaviour
{
    public TMP_Text timeText;

    // Update is called once per frame
    void Update()
    {
        if (timeText != null)
        {
            DisplayTime(Collectible.count);
        }
    }

    // This is the displaying method for the score objects.
    void DisplayTime(int countScore)
    {
        timeText.text = string.Format("{0}", countScore);
    }
}
