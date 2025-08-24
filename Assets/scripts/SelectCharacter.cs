using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SelectCharacter : MonoBehaviour
{
    
    public TMP_Text characterName;
    public TMP_Text characterDescription;
    public TMP_Text characterQuote;
    public Button continueButton;  // Button to go to next scene
    public Button boyButton;
    public Button girlButton;

    private string selectedCharacter;

    public void Start()
    {
        continueButton.gameObject.SetActive(false); // Hide continue button at start

        // Add listeners
        boyButton.onClick.AddListener(OnBoyClicked);
        girlButton.onClick.AddListener(OnGirlClicked);
        continueButton.onClick.AddListener(OnContinueClicked);
    }

    public void OnBoyClicked()
    {
        selectedCharacter = "Boy";
        characterName.text = "Juan Dela Cruz";
        characterDescription.text = "* Short black hair, brown eyes\r\n* Wears a T-shirt, shorts, and sneakers\r\n* Slim and energetic";
        characterQuote.text = "\"Tapos na po sir~\"";
        continueButton.gameObject.SetActive(true); // Show Continue button
    }

    public void OnGirlClicked()
    {
        selectedCharacter = "Girl";
        characterName.text = "Juania Dela Cruz";
        characterDescription.text = "* Long brown hair, brown eyes\r\n* Wears a casual dress or T-shirt and skirt\r\n* Petite and cheerful";
        characterQuote.text = "\"Ganyan ba dapat sinasabe madaem~\"";
        continueButton.gameObject.SetActive(true); // Show Continue button
    }

    public void OnContinueClicked()
    {
        PlayerPrefs.SetString("SelectedCharacter", selectedCharacter); // Save selection
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
