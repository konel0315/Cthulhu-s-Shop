using UnityEngine;

public class UIInstaller : MonoBehaviour
{
    [Header("UIs")]
    [SerializeField] private PrepareUI _prepareUI;
    // [SerializeField] private ClockUI _clockUI;
    [SerializeField] private DecisionNightUI _decisionNightUI;
    [SerializeField] private DayBackgroundUI _dayBackgroundUI;
    [SerializeField] private NightBackgroundUI _nightBackgroundUI;
    [SerializeField] private InventoryUI _inventoryUI;
    [SerializeField] private DisplayUI _displayUI;

    public void Bind(GameFlowManager gameFlowManager)
    {
        _prepareUI.Bind(gameFlowManager.uiController);
        // _clockUI.Bind(gameFlowManager.timeController);
        _decisionNightUI.Bind(gameFlowManager.uiController);
        _dayBackgroundUI.Bind(gameFlowManager.uiController);
        _nightBackgroundUI.Bind(gameFlowManager.uiController);
        _inventoryUI.Bind(gameFlowManager.inventoryController);
        _displayUI.Bind(gameFlowManager.inventoryController.displayController);
    }
}