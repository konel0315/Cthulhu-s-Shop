using Unity.VisualScripting;
using UnityEngine;

public class NightBackgroundUI : MonoBehaviour
{
    [SerializeField] private GameObject root;
    private UIController uiController;
    
    public void Bind(UIController uiController)
    {
        this.uiController = uiController;
        uiController.onShowUINightBackgroundUI+=onShowUINightBackgroundUI;
        uiController.onHideUINightBackgroundUI+=onHideUINightBackgroundUI;
    }
    
    
    
    private void onShowUINightBackgroundUI()=>root.SetActive(true);
    private void onHideUINightBackgroundUI()=>root.SetActive(false);
}