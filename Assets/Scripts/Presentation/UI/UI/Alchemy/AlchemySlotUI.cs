using UnityEngine;
using UnityEngine.UI;

public class AlchemySlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;

    public void SetItem(GameItem item)
    {
        icon.sprite = item.itemData.icon;
        gameObject.SetActive(true);
    }

    public void Clear()
    {
        icon.sprite = Resources.Load<Sprite>("UI/투명");
        gameObject.SetActive(false);
    }
}