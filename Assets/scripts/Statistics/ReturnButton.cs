using UnityEngine;

public class ReturnButton : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        // Load the main menu scene
        Debug.Log("Return to Main Menu");
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
