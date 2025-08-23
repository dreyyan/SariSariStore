using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public TextMeshProUGUI volumeText;

    void Start()
    {
        // Load saved volume (default 5.0f if none)
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        volumeSlider.value = savedVolume;

        // Set initial text
        UpdateValue(savedVolume);

        // Add listener to slider
        volumeSlider.onValueChanged.AddListener(UpdateValue);
    }

    // Update is called once per frame
    void UpdateValue(float value)
    {
        // Update text
        volumeText.text = value.ToString("F0") + "%";

        // Save value
        PlayerPrefs.SetFloat("Volume", value);
    }
}
