public class SettleTheDay : IGameFlow
{
    private readonly GameFlowManager gameFlowManager;
    // private readonly TimeController timeController;
    private readonly DisplayController displayController;
    private readonly UIController uiController;

    public SettleTheDay(GameFlowManager gameFlowManager)
    {
        this.gameFlowManager = gameFlowManager;
        // timeController = gameFlowManager.timeController;
        displayController = gameFlowManager.displayController;
        uiController = gameFlowManager.uiController;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }

    private void OnConfirm()
    {
        gameFlowManager.ChangeFlow(new DayOpen(gameFlowManager));
    }
}