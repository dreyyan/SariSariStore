using System.Collections.Generic;
using UnityEngine;

public class DeskManager : MonoBehaviour
{
    public static DeskManager Instance;

    // Items currently placed on the counter
    public List<ItemOrder> CurrentItems = new List<ItemOrder>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Add an item to the desk
    public void AddItem(ItemData item, int quantity = 1)
    {
        CurrentItems.Add(new ItemOrder { Item = item, Quantity = quantity });
    }

    // Clear desk after transaction ends
    public void ClearDesk()
    {
        CurrentItems.Clear();
    }

    // Calculate total price of items
    public int CalculateTotal()
    {
        int total = 0;
        foreach (var order in CurrentItems)
        {
            total += order.Item.Price * order.Quantity;
        }
        return total;
    }
}
