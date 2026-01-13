using UnityEngine;

public class NightPrepare : IGameFlow
{
    private readonly GameFlowManager gameFlowManager;
    // private readonly TimeController timeController;
    private readonly UIController uiController;

    public NightPrepare(GameFlowManager gameFlowManager)
    {
        this.gameFlowManager = gameFlowManager;
        // timeController = gameFlowManager.timeController;
        uiController = gameFlowManager.uiController;
    }

    public void Enter()
    {
        // timeController.Pause();
        //displayController.SetInteractable(true);
        uiController.ShowUIPrepareUI();
        uiController.ShowUINightBackgroundUI();
        uiController.OnPrepareConfirmed += OnConfirm;
    }

    public void Exit()
    {
        // timeController.Resume();
        //displayController.SetInteractable(false);
        uiController.HideUIPrepareUI();
        //uiController.HideUINightBackgroundUI();
    }
    private void OnConfirm()
    {
        gameFlowManager.ChangeFlow(new NightOpen(gameFlowManager));
    }
}