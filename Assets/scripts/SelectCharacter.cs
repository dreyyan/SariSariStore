using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class CharacterSelectUI : MonoBehaviour
{
    
    public TMP_Text detailsText;     // Text to show character details
    public Button continueButton;  // Button to go to next scene
    public Button boyButton;
    public Button girlButton;

    private string selectedCharacter;

    void Start()
    {
        continueButton.gameObject.SetActive(false); // Hide continue button at start

        // Add listeners
        boyButton.onClick.AddListener(OnBoyClicked);
        girlButton.onClick.AddListener(OnGirlClicked);
        continueButton.onClick.AddListener(OnContinueClicked);
    }

    void OnBoyClicked()
    {
        selectedCharacter = "Boy";
        detailsText.text = "Juan Dela Cruz \n\"Tapos na po sir~\" \n\n\n\n CHARACTER DETAILS===============.";
        continueButton.gameObject.SetActive(true); // Show Continue button
    }

    void OnGirlClicked()
    {
        selectedCharacter = "Girl";
        detailsText.text = "Juania Dela Cruz \n\"Ganyan ba dapat sinasabe madaem~\" \n\n\n\n CHARACTER DETAILS===============.";
        continueButton.gameObject.SetActive(true); // Show Continue button
    }

    void OnContinueClicked()
    {
        PlayerPrefs.SetString("SelectedCharacter", selectedCharacter); // Save selection
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
