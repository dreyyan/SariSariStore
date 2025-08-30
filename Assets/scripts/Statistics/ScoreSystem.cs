[System.Serializable]
public class ScoreSystem
{
    // ATTRIBUTES: Score Data
    public int BaseProfit;
    public int SpeedBonus;
    public int AccuracyBonus;
    public int HonestyBonus;

    public int FinalScore => BaseProfit + SpeedBonus + AccuracyBonus + HonestyBonus;
}
