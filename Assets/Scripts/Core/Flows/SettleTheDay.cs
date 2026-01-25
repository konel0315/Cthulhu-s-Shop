public class SettleTheDay : IGameFlow
{
    // private readonly TimeController timeController;
    
    private readonly GameFlowManager gameFlowManager;
    private readonly UIController uiController;

    public SettleTheDay(GameFlowManager gameFlowManager)
    {
        // timeController = gameFlowManager.timeController;
        
        this.gameFlowManager = gameFlowManager;
        uiController = gameFlowManager.uiController;
    }

    public void Enter()
    {
        uiController.ShowUIAlchemyBackgroundUI();
        uiController.ShowUIComplementUI();
        uiController.OnComplementConfirmed+=OnConfirm;
    }

    public void Exit()
    {
        uiController.HideUIAlchemyBackgroundUI();
        uiController.HideUIComplementUI();
        uiController.OnComplementConfirmed -= OnConfirm;
    }

    private void OnConfirm()
    {
        gameFlowManager.ChangeFlow(new DayPrepareFlow(gameFlowManager));
    }
}