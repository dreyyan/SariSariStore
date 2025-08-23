using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // METHODS
    public void PlayGame()
    {
        // Load the game scene
        Debug.Log("Play Game");
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionsMenu()
    {
        // Open the settings menu
        Debug.Log("Open Settings");
        UnityEngine.SceneManagement.SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame()
    {
        // Quit the application
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
