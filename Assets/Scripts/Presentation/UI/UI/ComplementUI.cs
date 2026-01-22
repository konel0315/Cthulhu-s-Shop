using System;
using UnityEngine;
using UnityEngine.UI;

public class ComplementUI : MonoBehaviour
{
    private UIController uiController;
    [SerializeField] private GameObject root;
    [SerializeField] private Button ComplementButton;
    
    public void Bind(UIController uiController)
    {
        this.uiController = uiController;
        uiController.onShowUIComplementUI+=onShowUIComplementUI;
        uiController.onHideUIComplementUI+=onHideUIComplementUI;
        ComplementButton.onClick.AddListener(uiController.ComplementConfirmed);
    }
    
    private void onShowUIComplementUI()=>root.SetActive(true);
    private void onHideUIComplementUI()=>root.SetActive(false);
    
}