using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // REFERENCES
    public static PlayerManager Instance;

    // PLAYER DATA
    // Player
    public string PlayerName;
    public string SelectedCharacter; // "Boy" or "Girl"

    // Earnings and Profits
    public int Coins = 100;
    public int Profit = 0;
    public int DailyProfit = 0;

    // Bonuses
    public int SpeedBonus = 0;
    public int AccuracyBonus = 0;
    public int HonestyBonus = 0;
    public int DecorationsUnlocked = 0;

    // METHODS
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddCoins(int amount)
    {
        Coins += amount;
        GameManager.Instance.TotalCoinsCollected += amount;
    }
}
