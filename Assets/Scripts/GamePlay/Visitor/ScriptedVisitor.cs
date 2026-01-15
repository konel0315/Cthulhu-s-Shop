using System;
using System.Dynamic;

public abstract class ScriptedVisitor
{
    protected UIController uiController; 
    
    public void Bind(UIController uiController) => this.uiController = uiController;

    public virtual void Enter()
    {
        uiController.ShowVisitorUI();
    }

    public abstract void Play(Action onFinished);
    
    public virtual void Exit()
    {
        uiController.HideVisitorUI();
    }

}