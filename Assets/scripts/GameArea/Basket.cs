using UnityEngine;

public class Basket : MonoBehaviour
{
    public void OnClickBasket()
    {
        if (TransactionManager.Instance != null && TransactionManager.Instance.CurrentCustomer != null)
        {
            TransactionManager.Instance.GiveToCustomer(TransactionManager.Instance.CurrentCustomer);
        }
        else
        {
            Debug.LogWarning("No customer or TransactionManager instance found!");
        }
    }
}