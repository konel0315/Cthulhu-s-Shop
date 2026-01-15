using Unity.VisualScripting;
using UnityEngine;

public class DayBackgroundUI : MonoBehaviour
{
    [SerializeField] private GameObject root;
    private UIController uiController;
    
    public void Bind(UIController uiController)
    {
        this.uiController = uiController;
        uiController.onShowUIDayBackgroundUI+=onShowUIDayBackgroundUI;
        uiController.onHideUIDayBackgroundUI+=onHideUIDayBackgroundUI;
    }
    
    
    
    private void onShowUIDayBackgroundUI()=>root.SetActive(true);
    private void onHideUIDayBackgroundUI()=>root.SetActive(false);
}