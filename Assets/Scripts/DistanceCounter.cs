using UnityEngine;
using TMPro; // Ensure you have TextMeshPro imported if you're using it.

public class DistanceCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText; // UI Text to display the distance.
    private float startZPosition; // Stores the initial Z position of the player.

    private void Start()
    {
        // Record the starting Z position of the player.
        startZPosition = transform.position.z;

        // Ensure the text is initialized.
        if (distanceText != null)
        {
            distanceText.text = "Distance: 0m";
        }
    }

    private void Update()
    {
        // Calculate the distance by subtracting the starting Z position from the current Z position.
        float distance = transform.position.z - startZPosition;

        // Update the UI text.
        if (distanceText != null)
        {
            distanceText.text = $"Distance: {Mathf.FloorToInt(distance)}m";
        }
    }
}
