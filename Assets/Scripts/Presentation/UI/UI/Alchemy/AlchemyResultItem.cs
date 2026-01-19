using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlchemyResultItem : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;

    public void SetItem(GameItem item)
    {
        icon.sprite = item.itemData.icon;
        icon.raycastTarget = true;
        
        quantityText.text = item.Quantity > 1 ? item.Quantity.ToString() : "";
    }

    public void Clear()
    {
        icon.sprite = Resources.Load<Sprite>("UI/투명");
        icon.raycastTarget = false;
        
        quantityText.text = "";
    }
}