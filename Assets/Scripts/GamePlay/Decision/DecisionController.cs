using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class DecisionController
{
    private readonly UIController uiController;
    private readonly HoldingAreaController holdingArea;
    private readonly VisitorController visitorController;

    public DecisionController(
        UIController uiController,
        HoldingAreaController holdingArea
        , VisitorController visitorController)
    {
        this.uiController = uiController;
        this.holdingArea = holdingArea;
        this.visitorController = visitorController;

        uiController.OnAcceptPressed += OnAcceptPressed;
        uiController.OnRejectPressed += OnRejectPressed;
        holdingArea.OnTakingEmptied += OnTakingEmptied;
    }

    private void OnTakingEmptied()
    {
        if (visitorController.CurrentVisitor == null)
            return;

        visitorController.WaitForSeconds(2.5f, () => { visitorController.EndCurrentVisitor(); });
    }

    private void OnAcceptPressed()
    {
        var visitor = visitorController.CurrentVisitor;

        if (visitor == null)
        {
            holdingArea.Accept();
            return;
        }

        if (!visitor.CanAccept())
            return;

        holdingArea.Accept();
        if (visitor is IChoosable acceptVisitor)
            acceptVisitor.OnAccept();

        visitorController.WaitForSeconds(2f,
            () =>
            {
                visitorController.ClearCurrentVisitor();
            });
    }

    private void OnRejectPressed()
    {
        if (holdingArea.HasGiving)
        {
            holdingArea.Reject();
            return;
        } //아이템이 있는지가 우선순위 1번

        var visitor = visitorController.CurrentVisitor;

        if (visitor == null) return;

        if (visitor is IChoosable acceptVisitor)
        {
            acceptVisitor.OnReject();
        }

        visitorController.WaitForSeconds(2.5f, () => { visitorController.EndCurrentVisitor(); });
    }
}