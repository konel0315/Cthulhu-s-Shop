using System;
using System.Dynamic;
using Unity.VisualScripting;

public abstract class ScriptedVisitor
{
    protected UIController uiController; 
    protected InventoryController inventoryController;

    public void Bind(UIController uiController, InventoryController inventory)
    {
        this.uiController = uiController;
        this.inventoryController = inventory;
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

    public virtual bool CanAccept(HoldingAreaController holdingAreaController)
    {
        return true;
    }
}