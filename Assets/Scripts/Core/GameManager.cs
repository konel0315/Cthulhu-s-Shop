using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private GameFlowManager gameFlowManager;

    private List<IUpdatable> updateables = new List<IUpdatable>();

    public void RegisterUpdateable(IUpdatable updateable)
    {
        updateables.Add(updateable);
    }

    public void UpdateAll(float deltaTime)
    {
        foreach (var updateable in updateables)
            updateable.Update(deltaTime);
    }

    public void SetFlowManager(GameFlowManager manager)
    {
        gameFlowManager = manager;
    }
    
    public void StartGame()
    {
        gameFlowManager.ExcuteFlow();
    }
    
    
}
