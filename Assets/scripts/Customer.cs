using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Customer
{
    // ATTRIBUTES: Customer Data
    public string CustomerName;
    public List<ItemOrder> Orders;
    public int PaymentGiven;
    public bool IsPaymentShort;
}

[System.Serializable]
public class ItemOrder
{
    // ATTRIBUTES: Item Order Data
    public ItemData Item;
    public int Quantity;
}