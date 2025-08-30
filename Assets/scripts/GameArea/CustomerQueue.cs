using System.Collections.Generic;
using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
    public static CustomerQueue Instance;
    public List<Customer> Customers = new List<Customer>();
    public List<ItemData> Products = new List<ItemData>();
    public GameObject customerObject; // Reference to the single customer GameObject

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("Duplicate CustomerQueue found, destroying.");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Validate dependencies
        if (customerObject == null)
        {
            Debug.LogError("customerObject is not assigned in CustomerQueue!");
            return;
        }
        Customer displayCustomer = customerObject.GetComponent<Customer>();
        if (displayCustomer == null)
        {
            Debug.LogError($"Customer component missing on {customerObject.name}!");
            return;
        }
        if (Products.Count == 0)
        {
            Debug.LogError("No Products assigned in CustomerQueue! Customers will have empty orders.");
            return;
        }

        // Create 5 unique customer orders
        for (int i = 0; i < 5; i++)
        {
            GameObject tempGO = new GameObject($"CustomerData_{i}");
            tempGO.transform.SetParent(transform); // Organize under CustomerQueue
            Customer customer = tempGO.AddComponent<Customer>();
            customer.GenerateRandomOrder(Products);
            Customers.Add(customer);
            Debug.Log($"Created CustomerData_{i} with {customer.Orders.Count} orders.");
            foreach (var order in customer.Orders)
            {
                Debug.Log($"CustomerData_{i} wants {order.Quantity} x {order.Item.ItemName}");
            }
        }
        // Initialize display customer with first customer's orders
        if (Customers.Count > 0)
        {
            displayCustomer.Orders.Clear();
            displayCustomer.Orders.AddRange(Customers[0].Orders);
            Customers[0] = displayCustomer; // Replace first entry with display customer
        }
        Debug.Log($"CustomerQueue initialized with {Customers.Count} customers.");
    }

    public Customer GetNextCustomer()
    {
        Customer nextCustomer = Customers.Find(c => !c.IsServed);
        Debug.Log($"GetNextCustomer: {(nextCustomer != null ? $"Found customer with {nextCustomer.Orders.Count} orders" : "No unserved customers available.")}");
        if (nextCustomer == null)
        {
            Debug.Log($"Customers: {string.Join(", ", Customers.ConvertAll(c => $"{c.name} (Served: {c.IsServed})"))}");
        }
        return nextCustomer;
    }
}