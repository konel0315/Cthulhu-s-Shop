using System.Collections.Generic;
using UnityEngine;

public class HoldingUI : MonoBehaviour
{
    private HoldingAreaController _holdingAreaController;
    private DisplayController _displayController;

    [SerializeField] private HoldingSlotUI slot;

    public void Bind(HoldingAreaController holdingAreaController, DisplayController displayController)
    {
        _holdingAreaController = holdingAreaController;
        _displayController = displayController;

        slot.Bind(_holdingAreaController, _displayController);

        RefreshUI();
        _holdingAreaController.OnHoldingAreaChanged += RefreshUI;
    }

    private void RefreshUI()
    {
        if (_holdingAreaController == null) return;

        var item = _holdingAreaController.GetItem();
        if (item != null)
        {
            slot.SetSlot(item.item, item.quantity);
        }
        else
        {
            slot.ClearSlot();
        }
    }
}