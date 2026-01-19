using UnityEngine;

public class DayPrepareFlow : IGameFlow
{ 
    // private readonly TimeController timeController;
    
    private readonly GameFlowManager gameFlowManager;
    private readonly InventoryController inventoryController;
    private readonly UIController uiController;

    public DayPrepareFlow(GameFlowManager gameFlowManager)
    {
        // timeController = gameFlowManager.timeController;
        
        this.gameFlowManager = gameFlowManager;
        uiController = gameFlowManager.uiController;
        inventoryController = gameFlowManager.inventoryController;
    }

    public void Enter() 
    {
        // timeController.Pause();

        /*Item 지급*/
        ItemSO gold = Resources.Load<ItemSO>("Data/Item/Gold");
        inventoryController.AddItem(gold, 3);
        ItemSO bread = Resources.Load<ItemSO>("Data/Item/Bread");
        inventoryController.AddItem(bread, 4);
        
        uiController.ShowUIPrepareUI();
        uiController.ShowUIDayBackgroundUI();
        uiController.OnPrepareConfirmed += OnConfirm;
    }

    public void Exit() 
    {
        // timeController.Resume();
        
        uiController.HideUIPrepareUI();
        uiController.OnPrepareConfirmed -= OnConfirm;
        
    }

    private void OnConfirm()
    {
        gameFlowManager.ChangeFlow(new DayOpen(gameFlowManager));
    }
}
