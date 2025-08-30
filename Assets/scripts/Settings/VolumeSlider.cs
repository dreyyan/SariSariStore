using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class VolumeSlider : MonoBehaviour, IPointerUpHandler
{
    public Slider volumeSlider;
    public TextMeshProUGUI volumeText;
    public AudioSource audioSource;
    public AudioClip sfxPreview;

    void Start()
    {
        // Load saved volume (default 0.5f if none)
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        volumeSlider.value = savedVolume * 100f; // slider is 0-100
        UpdateText(savedVolume);

        // Update volume while dragging
        volumeSlider.onValueChanged.AddListener(UpdateValue);
    }

    void UpdateValue(float sliderValue)
    {
        // Scale slider (0-100) to 0-1 for AudioSource
        float scaledValue = sliderValue / 100f;

        // Update text
        UpdateText(scaledValue);

        // Save volume
        PlayerPrefs.SetFloat("Volume", scaledValue);

        // Apply volume
        if (audioSource != null)
            audioSource.volume = scaledValue;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Play SFX once at current volume
        if (sfxPreview != null && audioSource != null)
        {
            float scaledValue = volumeSlider.value / 100f;
            audioSource.PlayOneShot(sfxPreview, scaledValue);
        }
    }

    void UpdateText(float value)
    {
        volumeText.text = (value * 100f).ToString("F0") + " %";
    }
}