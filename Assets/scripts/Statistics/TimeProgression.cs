using UnityEngine;
using UnityEngine.UI;

public class TimeProgression : MonoBehaviour
{
    public Image timeProgressBar; // Reference to the UI Image component for the progress bar
    public float dayDuration = 120f; // Duration of a full day in seconds
    private float elapsedTime = 0f; // Time elapsed since the start of the day

    void Update()
    {
        // Increment elapsed time
        elapsedTime += Time.deltaTime;

        // Calculate the fill amount (0 to 1)
        float fillAmount = Mathf.Clamp01(elapsedTime / dayDuration);

        // Update the progress bar
        timeProgressBar.fillAmount = fillAmount;

        // Optional: Reset the timer after a full day
        if (elapsedTime >= dayDuration)
        {
            elapsedTime = 0f; // Reset elapsed time for the next day
        }
    }
}