using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // GAME DATA
    public int CurrentDay = 1;
    public int CurrentWeek = 1;

    // STATISTICS
    public int TotalCoinsCollected = 0;
    public int TotalDaysPlayed = 0;

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
