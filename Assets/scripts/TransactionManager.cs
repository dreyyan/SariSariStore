using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TransactionManager : MonoBehaviour
{
    // REFERENCES
    public static TransactionManager Instance;
    public TMP_Text moneyToReturnText;

    // ATTRIBUTES
    public int receivedMoney = 0;
    public int moneyToReturn = 0;

    // Items currently placed on the counter
    public List<ItemOrder> CurrentItems = new List<ItemOrder>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // keep it alive between scenes
        }
        else
        {
            Destroy(gameObject); // prevent duplicates
        }
    }

    /* METHODS: Items */
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

    public void RemoveItem(ItemData item)
    {
        CurrentItems.RemoveAll(order => order.Item == item);
    }

    public void RemoveItemQuantity(ItemData item, int quantity)
    {
        var order = CurrentItems.Find(o => o.Item == item);
        if (order != null)
        {
            order.Quantity -= quantity;
            if (order.Quantity <= 0)
                CurrentItems.Remove(order);
        }
    }

    /* METHODS: Transactions */
    public void UpdateMoneyToReturnDisplay()
    {
        moneyToReturnText.text = $"₱{moneyToReturn:N0}";
    }

    public void StartTransaction()
    {
        receivedMoney = 0;
        moneyToReturn = 0;
        UpdateMoneyToReturnDisplay();
    }

    public void EndTransaction()
    {
        // Update player's coins and profit
        //PlayerManager.Instance.AddCoins(receivedMoney - moneyToReturn);
        //PlayerManager.Instance.Profit += receivedMoney - moneyToReturn;
        //PlayerManager.Instance.DailyProfit += receivedMoney - moneyToReturn;

        // Clear desk for next customer
        ClearDesk();
        receivedMoney = 0;
        moneyToReturn = 0;
        UpdateMoneyToReturnDisplay();
        AudioManager.Instance.PlayPurchaseCompleteSound();
    }

    public void ReceiveMoney(int amount)
    {
        receivedMoney += amount;
        UpdateMoneyToReturnDisplay();
        AudioManager.Instance.PlayMoneyPressSound();
    }

    public void ReturnMoney(int amount)
    {
        moneyToReturn += amount;
        UpdateMoneyToReturnDisplay();
        AudioManager.Instance.PlayMoneyPressSound();
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
