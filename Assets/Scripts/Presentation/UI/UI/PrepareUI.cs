using System;
using UnityEngine;
using UnityEngine.UI;

public class PrepareUI : MonoBehaviour
{
    private UIController uiController;
    [SerializeField] private GameObject root;
    [SerializeField] private Button prepareButton;
    
    public void Bind(UIController uiController)
    {
        this.uiController = uiController;
        uiController.onShowUIPrepareUI+=onShowUIPrepareUI;
        uiController.onHideUIPrepareUI+=onHideUIPrepareUI;
        prepareButton.onClick.AddListener(uiController.PrepareConfirmed);
    }
    
    private void onShowUIPrepareUI()=>root.SetActive(true);
    private void onHideUIPrepareUI()=>root.SetActive(false);
    
}