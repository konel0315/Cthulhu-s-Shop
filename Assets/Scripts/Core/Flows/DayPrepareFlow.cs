public class DayPrepareFlow : IGameFlow
{ 
    private readonly GameFlowManager gameFlowManager;
    private readonly TimeController timeController;
    private readonly DisplayController displayController;
    private readonly UIController uiController;

    public DayPrepareFlow(GameFlowManager gameFlowManager)
    {
        this.gameFlowManager = gameFlowManager;
        timeController = gameFlowManager.timeController;
        displayController = gameFlowManager.displayController;
        uiController = gameFlowManager.uiController;
    }

    public void Enter() 
    {
        timeController.Pause();
        //displayController.SetInteractable(true);
        //uiController.ShowUIPrepareUI();
        //uiController.OnpPrepareConfirmed += OnConfirm;
    }

    public void Exit() 
    {
        timeController.Resume();
        //uiController.OnpPrepareConfirmed -= OnConfirm;
        //displayController.SetInteractable(false);
        //uiController.HideUIPrepareUI();
        
    }

    private void OnConfirm()
    {
        gameFlowManager.ChangeFlow(new DayOpen(gameFlowManager));
    }
}
