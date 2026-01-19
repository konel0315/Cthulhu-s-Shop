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
    [SerializeField] private VisitorUI _visitorUI;
    [SerializeField] private HoldingUI _holdingUI;
    [SerializeField] private DecisionUI _decisionUI;
    [SerializeField] private DragItemUI _dragItemUI;
    [SerializeField] private AlchemyUI _alchemyUI;
    [SerializeField] private AlchemyInventoryUI _alchemyInventoryUI;

    public void Bind(GameFlowManager gameFlowManager)
    {
        // _clockUI.Bind(gameFlowManager.timeController);
        
        _prepareUI.Bind(gameFlowManager.uiController);
        _decisionNightUI.Bind(gameFlowManager.uiController);
        _dayBackgroundUI.Bind(gameFlowManager.uiController);
        _nightBackgroundUI.Bind(gameFlowManager.uiController);
        _inventoryUI.Bind(gameFlowManager.inventoryController,gameFlowManager.displayController);
        _displayUI.Bind(gameFlowManager.displayController);
        _visitorUI.Bind(gameFlowManager.uiController);
        _holdingUI.Bind(gameFlowManager.holdingAreaController, gameFlowManager.displayController,gameFlowManager.uiController);
        _decisionUI.Bind(gameFlowManager.uiController);
        _dragItemUI.Bind(gameFlowManager.holdingAreaController);
        _alchemyUI.Bind(gameFlowManager.alchemyController,gameFlowManager.inventoryController);
        _alchemyInventoryUI.Bind(gameFlowManager.inventoryController);
    }
}