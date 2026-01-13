using UnityEngine;

public class DecisionNight : IGameFlow
{
    private readonly GameFlowManager gameFlowManager;
    // private readonly TimeController timeController;
    private readonly DisplayController displayController;
    private readonly UIController uiController;

    public DecisionNight(GameFlowManager gameFlowManager)
    {
        this.gameFlowManager = gameFlowManager;
        // timeController = gameFlowManager.timeController;
        displayController = gameFlowManager.displayController;
        uiController = gameFlowManager.uiController;
    }

    public void Enter()
    {
        // timeController.Pause();
        uiController.DecisionNightUIShowUI();
        uiController.OnNightConfirmed += OnNightConfirmed;
        uiController.OnNextDayConfirmed += OnNextDayConfirmed;
    }

    public void Exit()
    {
        // timeController.Resume();
        uiController.DecisionNightUIHideUI();
        uiController.OnNightConfirmed -= OnNightConfirmed;
        uiController.OnNextDayConfirmed -= OnNextDayConfirmed;
    }
    private void OnNightConfirmed()
    {
        gameFlowManager.ChangeFlow(new NightPrepare(gameFlowManager));
    }
    private void OnNextDayConfirmed()
    {
        gameFlowManager.ChangeFlow(new SettleTheDay(gameFlowManager));
    }
}