using UnityEngine;
using UnityEngine.UI;

public class DecisionUI : MonoBehaviour
{
    [SerializeField] private GameObject root;
    [SerializeField] private Button acceptButton;
    [SerializeField] private Button rejectButton;

    private UIController uiController;

    public void Bind(UIController uiController)
    {
        this.uiController = uiController;

        uiController.OnShowDecisionUI += Show;
        uiController.OnHideDecisionUI += Hide;

        acceptButton.onClick.AddListener(uiController.Accept);
        rejectButton.onClick.AddListener(uiController.Reject);
    }

    private void Show() => root.SetActive(true);
    private void Hide() => root.SetActive(false);
}