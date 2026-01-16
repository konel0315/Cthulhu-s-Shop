using System.Collections.Generic;
using UnityEngine;

public class HoldingUI : MonoBehaviour
{
    [SerializeField] private GameObject root;
    [SerializeField] private HoldingSlotUI slot;
    
    private HoldingAreaController _holdingAreaController;
    private DisplayController _displayController;
    private UIController _uiController;

    public void Bind(HoldingAreaController holdingAreaController, DisplayController displayController, UIController uiController)
    {
        _holdingAreaController = holdingAreaController;
        _displayController = displayController;
        _uiController = uiController;
        slot.Bind(_holdingAreaController, _displayController,root);

        RefreshUI();
        _holdingAreaController.OnHoldingAreaChanged += RefreshUI;
        _uiController.onShowHoldingUI += ShowHoldingUI;
        _uiController.onHideHoldingUI += HideHoldingUI;

        root.SetActive(false);
    }


    private void ShowHoldingUI()
    {
        root.SetActive(true);
    }
    
    private void HideHoldingUI()
    {
        root.SetActive(false);
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