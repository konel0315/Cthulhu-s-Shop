using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager
{
    private IGameFlow currentGameFlow;

    // public TimeController timeController { get; private set;}
    public UIController uiController { get; private set;}
    public InventoryController inventoryController { get; private set;}
    public VisitorController visitorController { get; private set;}
    public DisplayController displayController { get; private set;}
    public HoldingAreaController holdingAreaController { get; private set;}
    public DecisionController decisionController { get; private set;}
    public AlchemyController alchemyController { get; private set;}
    public GameFlowManager()
    {
        // timeController = new TimeController();
        
        uiController = new UIController();
        inventoryController = new InventoryController();
        displayController = new DisplayController(inventoryController);
        holdingAreaController = new HoldingAreaController(inventoryController, displayController);
        visitorController = new VisitorController(uiController,inventoryController,holdingAreaController);
        decisionController = new DecisionController(uiController, holdingAreaController,visitorController);
        alchemyController = new AlchemyController(inventoryController);
    }

    public void ExcuteFlow()
    {
        ChangeFlow(new DayPrepareFlow(this));
    }

    public void ChangeFlow(IGameFlow gameflow)
    {
        currentGameFlow?.Exit();
        currentGameFlow=gameflow;
        currentGameFlow.Enter();
    }
}
