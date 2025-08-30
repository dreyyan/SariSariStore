using UnityEngine;

public class MoneyButton : MonoBehaviour
{
    public int billAmount; // Set in Inspector (e.g., 20, 50, 100, etc.)

    public void OnClickMoney()
    {
        TransactionManager.Instance.ReturnMoney(billAmount);
    }
}
