using UnityEngine;

public class Product : MonoBehaviour
{
    public ItemData itemData; // assign in Inspector
    public int quantity = 1;

    public void OnClickProduct()
    {
        Debug.Log("Clicked product: " + gameObject.name);

        if (TransactionManager.Instance == null)
        {
            Debug.LogError("TransactionManager.Instance is null!");
            return;
        }
        if (itemData == null)
        {
            Debug.LogError("itemData is null on " + gameObject.name + " (Product script attached here)");
            return;
        }

        TransactionManager.Instance.AddItem(itemData, quantity);
        Debug.Log($"Added {quantity} x {itemData.ItemName} to basket.");
    }

}