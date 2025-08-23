using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    // REFERENCES
    public static StoreManager Instance;

    // ATTRIBUTES: Store Data
    public List<ItemData> AvailableItems;
    public int DailyProfitGoal;
    public int TotalDecorations;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}
