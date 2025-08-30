using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomerOrder
{
    public ItemData Item;
    public int Quantity;
}

public class Customer : MonoBehaviour
{
    [Header("Customer State")]
    public List<CustomerOrder> Orders = new List<CustomerOrder>();
    public bool IsServed = false;

    [Header("Visuals")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    public Sprite defaultSprite;

    public void SetSprite(Sprite newSprite)
    {
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
            Debug.Log($"[{name}] Sprite set to: {newSprite.name}");
        }
        else
        {
            Debug.LogWarning($"[{name}] SpriteRenderer: {spriteRenderer}, NewSprite: {newSprite}");
            if (spriteRenderer != null && defaultSprite != null)
            {
                spriteRenderer.sprite = defaultSprite;
            }
        }
    }

    public void GenerateRandomOrder(List<ItemData> products)
    {
        if (products == null || products.Count == 0)
        {
            Debug.LogWarning($"[{name}] No products provided for order generation!");
            return;
        }
        Orders.Clear();
        int numberOfItems = Random.Range(1, 4);
        for (int i = 0; i < numberOfItems; i++)
        {
            ItemData randomItem = products[Random.Range(0, products.Count)];
            if (randomItem == null) continue;
            if (Orders.Exists(o => o.Item == randomItem)) continue;
            int quantity = Random.Range(1, 4);
            Orders.Add(new CustomerOrder { Item = randomItem, Quantity = quantity });
        }
        Debug.Log($"[{name}] Generated order with {Orders.Count} items.");
    }

    public bool FulfillOrder(List<ItemOrder> basket)
    {
        foreach (var order in Orders)
        {
            var basketItem = basket.Find(b => b.Item == order.Item);
            if (basketItem == null || basketItem.Quantity < order.Quantity)
                return false;
        }
        return true;
    }
}