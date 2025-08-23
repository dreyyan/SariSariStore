using UnityEngine;
using UnityEngine.EventSystems;

public class NewMonoBehaviourScript : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioSource audioSource;   // Reference to AudioSource
    public AudioClip hoverSound;      // Your WAV file
    public AudioClip clickSound;      // Sound for click

    // Called when the pointer enters (hover)
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Code to execute when the pointer enters the UI element
        Debug.Log("Pointer Entered");
        if (audioSource != null && hoverSound != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }
    }

    // Called when the button is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Button Clicked");
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
