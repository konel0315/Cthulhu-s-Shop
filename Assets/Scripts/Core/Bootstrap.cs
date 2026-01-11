using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private GameManager gameManager;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        gameManager = new GameManager();
        GameFlowManager flowManager = new GameFlowManager();
            
        gameManager.SetFlowManager(flowManager);
        
        gameManager.RegisterUpdateable(flowManager.timeController);
        
        gameManager.StartGame();
    }
 
    private void Update()
    {
        gameManager.UpdateAll(Time.deltaTime);
    }
    
}
