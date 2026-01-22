using System;
using System.Dynamic;
using Unity.VisualScripting;

public abstract class ScriptedVisitor
{
    protected UIController uiController; 
    protected InventoryController inventoryController;
    protected HoldingAreaController holdingAreaController;
    public void Bind(UIController uiController, InventoryController inventory,HoldingAreaController holdingAreaController)
    {
        this.uiController = uiController;
        this.inventoryController = inventory;
        this.holdingAreaController = holdingAreaController;
    }

    public virtual void Enter()
    {
        uiController.ShowVisitorUI();
    }
    public virtual void OnTextUI()
    {
        
    }

    public virtual void OffTextUI()
    {
        
    }
    public abstract void Play(Action onFinished);
    
    public virtual void Exit()
    {
        uiController.HideVisitorUI();
    }

    public virtual bool CanAccept()
    {
        return true;
    }
}