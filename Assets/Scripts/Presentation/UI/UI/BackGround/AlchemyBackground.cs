using Unity.VisualScripting;
using UnityEngine;

public class AlchemyBackground : MonoBehaviour
{
    [SerializeField] private GameObject root;
    private UIController uiController;
    
    public void Bind(UIController uiController)
    {
        this.uiController = uiController;
        uiController.onShowUIAlchemyBackgroundUI+=onShowUIAlchemyBackgroundUI;
        uiController.onHideUIAlchemyBackgroundUI+=onHideUIAlchemyBackgroundUI;
    }
    
    
    
    private void onShowUIAlchemyBackgroundUI()=>root.SetActive(true);
    private void onHideUIAlchemyBackgroundUI()=>root.SetActive(false);
}