using System;

public class DecisionController
{
    private readonly UIController uiController;
    private readonly HoldingAreaController holdingArea;
    

    public DecisionController(
        UIController uiController,
        HoldingAreaController holdingArea)
    {
        this.uiController = uiController;
        this.holdingArea = holdingArea;

        uiController.OnAcceptPressed += OnAcceptPressed;
        uiController.OnRejectPressed += OnRejectPressed;
    }
    
    private void OnAcceptPressed()
    {
        if (holdingArea.HasItem)
        {
                holdingArea.Accept();
        }
    }

    private void OnRejectPressed()
    {

        if (holdingArea.HasItem)
            holdingArea.Reject();

    }
}