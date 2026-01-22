using UnityEngine;
using UnityEngine.Serialization;

public class UIInstaller : MonoBehaviour
{
    [Header("UIs")]
    [SerializeField] private PrepareUI _prepareUI;
    [SerializeField] private ComplementUI _complementUI;
    // [SerializeField] private ClockUI _clockUI;
    [SerializeField] private DecisionNightUI _decisionNightUI;
    [SerializeField] private DayBackgroundUI _dayBackgroundUI;
    [SerializeField] private AlchemyBackground _alchemyBackground;
    
    [SerializeField] private NightBackgroundUI _nightBackgroundUI;
    [SerializeField] private InventoryUI _inventoryUI;
    [SerializeField] private DisplayUI _displayUI;
    [SerializeField] private VisitorUI _visitorUI;
    [SerializeField] private GivingUI _givingUI;
    [SerializeField] private TakingUI _takingUI;
    [SerializeField] private DecisionUI _decisionUI;
    [SerializeField] private DragItemUI _dragItemUI;
    [SerializeField] private AlchemyUI _alchemyUI;
    [SerializeField] private AlchemyInventoryUI _alchemyInventoryUI;
    

    public void Bind(GameFlowManager gameFlowManager)
    {
        // _clockUI.Bind(gameFlowManager.timeController);
        
        _prepareUI.Bind(gameFlowManager.uiController);
        _complementUI.Bind(gameFlowManager.uiController);
        _decisionNightUI.Bind(gameFlowManager.uiController);
        _dayBackgroundUI.Bind(gameFlowManager.uiController);
        _nightBackgroundUI.Bind(gameFlowManager.uiController);
        _alchemyBackground.Bind(gameFlowManager.uiController);
        _inventoryUI.Bind(gameFlowManager.inventoryController,gameFlowManager.displayController,gameFlowManager.holdingAreaController);
        _displayUI.Bind(gameFlowManager.displayController);
        _visitorUI.Bind(gameFlowManager.uiController);
        _givingUI.Bind(gameFlowManager.holdingAreaController, gameFlowManager.displayController,gameFlowManager.uiController);
        _takingUI.Bind(gameFlowManager.holdingAreaController);
        _decisionUI.Bind(gameFlowManager.uiController);
        _dragItemUI.Bind(gameFlowManager.holdingAreaController);
        _alchemyUI.Bind(gameFlowManager.alchemyController,gameFlowManager.inventoryController);
        _alchemyInventoryUI.Bind(gameFlowManager.inventoryController);
    }
}