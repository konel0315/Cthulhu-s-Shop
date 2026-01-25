using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AlchemyResultItem : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler,IDraggableSlot
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;
    public GameItem currentItem { get; private set; }
    public SlotSourceType SourceType => SlotSourceType.AlchemyResult;
    public void SetItem(GameItem item)
    {
        currentItem = item;
        icon.sprite = item.itemData.icon;
        icon.raycastTarget = true;
        
        quantityText.text = item.Quantity > 1 ? item.Quantity.ToString() : "";
    }

    public void Clear()
    {
        currentItem = null;
        icon.sprite = Resources.Load<Sprite>("UI/투명");
        icon.raycastTarget = false;
        
        quantityText.text = "";
    }
    public void RefreshSlot()
    {
        if (currentItem != null)
            SetItem(currentItem);
        else
            Clear();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (currentItem == null) return;
        DragItemUI.Instance.BeginDrag(currentItem.itemData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        DragItemUI.Instance.UpdatePosition(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragItemUI.Instance.EndDrag();
    }
}