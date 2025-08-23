using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "SariSariStore/Item")]
public class ItemData : ScriptableObject
{
    // ATTRIBUTES: Item Data
    public string ItemName;
    public int Price;
    public Sprite Icon;
    public bool IsUnlocked;
}
