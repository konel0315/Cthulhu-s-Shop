public class NightOpen : IGameFlow
{
    private readonly GameFlowManager gameFlowManager;
    // private readonly TimeController timeController;
    private readonly UIController uiController;

    public NightOpen(GameFlowManager gameFlowManager)
    {
        this.gameFlowManager = gameFlowManager;
        // timeController = gameFlowManager.timeController;
        uiController = gameFlowManager.uiController;
    }

    public void Enter()
    {
        // timeController.StartNight();
        // timeController.OnDayTimeEnded +=OnConfirm;
        //VisitorController.StartDayCusmtomer();
    }

    public void Exit()
    {
        // timeController.OnDayTimeEnded -=OnConfirm;
        //VisitorController.EndDayCusmtomer();
    }
    private void OnConfirm()
    {
        gameFlowManager.ChangeFlow(new SettleTheDay(gameFlowManager));
    }
}