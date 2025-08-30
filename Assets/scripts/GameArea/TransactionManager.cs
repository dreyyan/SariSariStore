using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class TransactionManager : MonoBehaviour
{
    public static TransactionManager Instance;
    public TMP_Text moneyToReturnText;
    public TMP_Text customerOrderText;
    public Customer CurrentCustomer;
    public List<ItemData> AllProducts;
    public Sprite customerSprite;
    public GameObject customerObject;

    public int receivedMoney = 0;
    public int moneyToReturn = 0;
    public List<ItemOrder> CurrentItems = new List<ItemOrder>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("Duplicate TransactionManager found, destroying.");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (customerObject == null)
        {
            Debug.LogError("customerObject is not assigned in TransactionManager!");
            return;
        }
        CurrentCustomer = customerObject.GetComponent<Customer>();
        if (CurrentCustomer == null)
        {
            Debug.LogError("Customer component missing on customerObject!");
            return;
        }
        if (customerSprite == null)
        {
            Debug.LogWarning("customerSprite is not assigned in TransactionManager! Using default sprite.");
        }
        SpawnCustomer();
    }

    public void AddItem(ItemData item, int quantity = 1)
    {
        if (item == null)
        {
            Debug.LogWarning("Attempted to add null item!");
            return;
        }
        var existingOrder = CurrentItems.Find(order => order.Item == item);
        if (existingOrder != null)
        {
            existingOrder.Quantity += quantity;
        }
        else
        {
            CurrentItems.Add(new ItemOrder { Item = item, Quantity = quantity });
        }
        Debug.Log($"Added {quantity} x {item.ItemName} to basket.");
    }

    public void GiveToCustomer(Customer customer)
    {
        if (customer == null)
        {
            Debug.LogWarning("No customer to give items to!");
            return;
        }
        if (customer.Orders.Count == 0)
        {
            Debug.LogWarning("Customer has no orders! Skipping transaction.");
            customer.IsServed = true;
            EndTransaction();
            return;
        }
        if (customer.FulfillOrder(CurrentItems))
        {
            int total = CalculateTotal();
            int[] possibleBills = { 20, 50, 100, 200, 500, 1000 };
            int selectedBill = possibleBills.FirstOrDefault(bill => bill >= total);
            if (selectedBill == 0)
            {
                selectedBill = ((total / 1000) + 1) * 1000;
            }
            ReceiveMoney(selectedBill);
            moneyToReturn = selectedBill - total;
            UpdateMoneyToReturnDisplay();
            customer.IsServed = true;
            Debug.Log($"Customer served! Paid ₱{selectedBill}, change: ₱{moneyToReturn}");
        }
        else
        {
            Debug.Log("Customer order is not complete!");
        }
    }

    public void SpawnCustomer()
    {
        if (CustomerQueue.Instance == null)
        {
            Debug.LogError("CustomerQueue.Instance is null! Ensure CustomerQueue is in the scene.");
            return;
        }
        if (customerObject == null || CurrentCustomer == null)
        {
            Debug.LogError("customerObject or CurrentCustomer is not assigned!");
            return;
        }
        Customer nextCustomer = CustomerQueue.Instance.GetNextCustomer();
        if (nextCustomer != null)
        {
            CurrentCustomer.Orders.Clear();
            CurrentCustomer.Orders.AddRange(nextCustomer.Orders);
            CurrentCustomer.IsServed = false;
            CurrentCustomer.SetSprite(customerSprite);
            UpdateCustomerOrderDisplay();
            StartTransaction();
            Debug.Log($"Assigned customer with {CurrentCustomer.Orders.Count} orders to {customerObject.name}.");
        }
        else
        {
            CurrentCustomer.SetSprite(CurrentCustomer.defaultSprite);
            CurrentCustomer.Orders.Clear();
            CurrentCustomer.IsServed = false;
            if (customerOrderText != null)
            {
                customerOrderText.text = "No customers remaining!";
            }
            Debug.Log("No more customers in queue! Game Over?");
        }
    }

    public void ClearDesk()
    {
        CurrentItems.Clear();
    }

    public void RemoveItem(ItemData item)
    {
        if (item == null) return;
        CurrentItems.RemoveAll(order => order.Item == item);
    }

    public void RemoveItemQuantity(ItemData item, int quantity)
    {
        if (item == null) return;
        var order = CurrentItems.Find(o => o.Item == item);
        if (order != null)
        {
            order.Quantity -= quantity;
            if (order.Quantity <= 0)
                CurrentItems.Remove(order);
        }
    }

    public void UpdateMoneyToReturnDisplay()
    {
        if (moneyToReturnText != null)
        {
            moneyToReturnText.text = $"₱ {moneyToReturn:N0}";
        }
        else
        {
            Debug.LogWarning("moneyToReturnText is not assigned!");
        }
    }

    public void UpdateCustomerOrderDisplay()
    {
        if (customerOrderText == null)
        {
            Debug.LogWarning("customerOrderText is not assigned!");
            return;
        }
        if (CurrentCustomer == null || CurrentCustomer.Orders.Count == 0)
        {
            customerOrderText.text = "";
            return;
        }
        string orderText = "Customer Order:\n";
        foreach (var order in CurrentCustomer.Orders)
        {
            orderText += $"{order.Item.ItemName}: {order.Quantity}\n";
        }
        customerOrderText.text = orderText;
    }

    public void StartTransaction()
    {
        receivedMoney = 0;
        moneyToReturn = 0;
        UpdateMoneyToReturnDisplay();
    }

    public void EndTransaction()
    {
        ClearDesk();
        receivedMoney = 0;
        moneyToReturn = 0;
        UpdateMoneyToReturnDisplay();
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayPurchaseCompleteSound();
        }
        else
        {
            Debug.LogWarning("AudioManager.Instance is null!");
        }
        SpawnCustomer();
    }

    public void ReceiveMoney(int amount)
    {
        receivedMoney += amount;
        UpdateMoneyToReturnDisplay();
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMoneyPressSound();
        }
        else
        {
            Debug.LogWarning("AudioManager.Instance is null!");
        }
    }

    public void ReturnMoney(int amount)
    {
        if (moneyToReturn <= 0)
        {
            Debug.LogWarning("No change to return! Transaction not active.");
            return;
        }
        moneyToReturn -= amount;
        UpdateMoneyToReturnDisplay();
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMoneyPressSound();
        }
        else
        {
            Debug.LogWarning("AudioManager.Instance is null!");
        }
        if (moneyToReturn <= 0)
        {
            Debug.Log("Change fully returned!");
            EndTransaction();
        }
    }

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