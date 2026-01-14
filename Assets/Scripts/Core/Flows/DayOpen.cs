public class DayOpen : IGameFlow
{
    // private readonly TimeController timeController;
    
    private readonly GameFlowManager gameFlowManager;
    private readonly UIController uiController;
    private readonly InventoryController inventoryController;

    public DayOpen(GameFlowManager gameFlowManager)
    {
        // timeController = gameFlowManager.timeController;
        
        this.gameFlowManager = gameFlowManager;
        uiController = gameFlowManager.uiController;
        inventoryController = gameFlowManager.inventoryController;
    }

    public void Enter()
    {
        
        // timeController.StartDay();
        // timeController.OnDayTimeEnded +=OnConfirm;
        
        inventoryController.displayController.SetEditable(false);
        //uiController.ShowUIDayOpenUI();
        //VisitorController.StartDayCusmtomer();
    }

    public void Exit()
    {
        // timeController.OnDayTimeEnded -=OnConfirm;
        
        inventoryController.displayController.SetEditable(true);
        //uiController.HideUIDayOpenUI();
        //VisitorController.EndDayCusmtomer();
    }

    private void OnConfirm()
    {
        gameFlowManager.ChangeFlow(new DecisionNight (gameFlowManager));
    }
}