using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public class VisitorController : IUpdatable
{
    private Queue<ScriptedVisitor> visitorQueue = new();
    private ScriptedVisitor currentVisitor;
    
    private bool waitingForDelay = false;
    private float delayTime = 0f;
    private Action onDelayFinished = null;

    private UIController uiController;
    private InventoryController inventoryController;
    
    public ScriptedVisitor CurrentVisitor => currentVisitor;
    
    

    public VisitorController(UIController uiController, InventoryController inventoryController)
    {
        this.uiController = uiController;
        this.inventoryController = inventoryController;
    }

    public void SetVisitors(IEnumerable<ScriptedVisitor> visitors)
    {
        visitorQueue.Clear();
        foreach (var visitor in visitors)
        {
            visitor.Bind(uiController,inventoryController);
            visitorQueue.Enqueue(visitor);
        }
    }
    
    public void StartNextVisitor(Action onAllVisitorsFinished = null)
    {
        if (visitorQueue.Count == 0)
        {
            currentVisitor = null;
            onAllVisitorsFinished?.Invoke();
            return;
        }

        currentVisitor = visitorQueue.Dequeue();
        currentVisitor.Enter();
        WaitForSeconds(1f, () =>
        {
                currentVisitor.Play(OnVisitorFinished);
        });
    }

    public void WaitForSeconds(float seconds, Action onFinished)
    {
        waitingForDelay = true;
        delayTime = seconds;
        onDelayFinished = onFinished;
    }

    public void Update(float deltaTime)
    {
        if (waitingForDelay)
        {
            delayTime -= deltaTime;
            if (delayTime <= 0f)
            {
                waitingForDelay = false;
                onDelayFinished?.Invoke();
                onDelayFinished = null;
            }
        }
    }

    private void OnVisitorFinished()
    {
        
    }
    
    public void EndCurrentVisitor()
    {
        if (currentVisitor == null) return;

        currentVisitor.Exit();
        currentVisitor = null;

        StartNextVisitor();
    }
}