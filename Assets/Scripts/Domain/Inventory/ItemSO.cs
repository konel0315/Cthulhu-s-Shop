using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemSO : ScriptableObject
{
    public string Name;
    public int baseValue;
    public bool canDisplay;
    public Sprite icon;
}