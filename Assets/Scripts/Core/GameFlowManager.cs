using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager
{
    private IGameFlow currentGameFlow;

    public TimeController timeController { get; private set;}
    public DisplayController displayController { get; private set;}
    public UIController uiController { get; private set;}

    public GameFlowManager()
    {
        timeController = new TimeController();
        displayController = new DisplayController();
        uiController = new UIController();
    }

    public void ExcuteFlow()
    {
        ChangeFlow(new DayPrepareFlow(this));
    }

    public void ChangeFlow(IGameFlow gameflow)
    {
        currentGameFlow?.Exit();
        currentGameFlow=gameflow;
        currentGameFlow.Enter();
    }
}
