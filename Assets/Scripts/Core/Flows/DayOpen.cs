public class DayOpen : IGameFlow
{
    private readonly GameFlowManager gameFlowManager;
    // private readonly TimeController timeController;
    private readonly UIController uiController;

    public DayOpen(GameFlowManager gameFlowManager)
    {
        this.gameFlowManager = gameFlowManager;
        // timeController = gameFlowManager.timeController;
        uiController = gameFlowManager.uiController;
    }

    public void Enter()
    {
        // timeController.StartDay();
        // timeController.OnDayTimeEnded +=OnConfirm;
        //uiController.ShowUIDayOpenUI();
        //VisitorController.StartDayCusmtomer();
    }

    public void Exit()
    {
        // timeController.OnDayTimeEnded -=OnConfirm;
        //uiController.HideUIDayOpenUI();
        //VisitorController.EndDayCusmtomer();
    }

    private void OnConfirm()
    {
        gameFlowManager.ChangeFlow(new DecisionNight (gameFlowManager));
    }
}