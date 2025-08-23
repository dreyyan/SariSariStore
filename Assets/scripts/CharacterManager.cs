using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    // REFERENCES
    public static CharacterManager Instance;

    // ATTRIBUTES: Character Data
    public string SelectedCharacter; // "Boy" or "Girl"

    // METHODS
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // survives across scenes
        }
        else
        {
            Destroy(gameObject); // avoid duplicates
        }
    }
}
