using UnityEngine;

public class TakingUI : MonoBehaviour
{
    [SerializeField] private TakingSlotUI slot;

    private HoldingAreaController holdingAreaController;

    public void Bind(HoldingAreaController controller)
    {
        holdingAreaController = controller;
        slot.Bind(controller);
        holdingAreaController.OnHoldingAreaChanged += RefreshUI;
        RefreshUI();
    }

    private void RefreshUI()
    {
        if (holdingAreaController == null) return;

        var taking = holdingAreaController.GetTaking();
        if (taking != null)
        {
            slot.SetSlot(new GameItem(taking.item,taking.quantity));
        }
        else
        {
            slot.ClearSlot();
        }
    }
}