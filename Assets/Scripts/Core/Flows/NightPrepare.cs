using UnityEngine;

public class NightPrepare : IGameFlow
{
    // private readonly TimeController timeController;
    
    private readonly GameFlowManager gameFlowManager;
    private readonly UIController uiController;

    public NightPrepare(GameFlowManager gameFlowManager)
    {
        // timeController = gameFlowManager.timeController;
        
        this.gameFlowManager = gameFlowManager;
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