using System.Collections.Generic;

public class NightOpen : IGameFlow
{
    // private readonly TimeController timeController;
    
    private readonly GameFlowManager gameFlowManager;
    private readonly UIController uiController;
    private readonly VisitorController visitorController;
    private readonly DisplayController displayController;
    public NightOpen(GameFlowManager gameFlowManager)
    {
        // timeController = gameFlowManager.timeController;
        
        this.gameFlowManager = gameFlowManager;
        uiController = gameFlowManager.uiController;
        visitorController = gameFlowManager.visitorController;
        displayController = gameFlowManager.displayController;
    }

    public void Enter()
    {
        // timeController.StartNight();
        // timeController.OnDayTimeEnded +=OnConfirm;
        
        displayController.SetEditable(false);
        visitorController.SetVisitors(new List<ScriptedVisitor>
        {
            new MVPBreadVisitor()
        });
        visitorController.StartNextVisitor(OnConfirm);
    }

    public void Exit()
    {
        // timeController.OnDayTimeEnded -=OnConfirm;
        
        displayController.SetEditable(true);
    }
    private void OnConfirm()
    {
        gameFlowManager.ChangeFlow(new SettleTheDay(gameFlowManager));
    }
}