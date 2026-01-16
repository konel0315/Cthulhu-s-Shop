using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private GameManager gameManager;
    private GameFlowManager flowManager;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        gameManager = new GameManager();
        flowManager = new GameFlowManager();
            
        gameManager.SetFlowManager(flowManager);
        
        gameManager.RegisterUpdateable(flowManager.visitorController);

        UIInstaller uiInstaller = FindAnyObjectByType<UIInstaller>();
        uiInstaller.Bind(flowManager);
        
        gameManager.StartGame();
    }
 
    private void Update()
    {
        gameManager.UpdateAll(Time.deltaTime);
    }
    
}
