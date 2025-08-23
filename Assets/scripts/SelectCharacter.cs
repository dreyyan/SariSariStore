using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    // METHODS
    public void PickBoy()
    {
        PlayerManager.Instance.SelectedCharacter = "Boy";
        Debug.Log("Selected Boy");
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PickGirl()
    {
        PlayerManager.Instance.SelectedCharacter = "Girl";
        Debug.Log("Selected Girl");
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
