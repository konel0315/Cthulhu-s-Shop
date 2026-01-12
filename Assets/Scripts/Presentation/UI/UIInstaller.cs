using UnityEngine;

public class UIInstaller : MonoBehaviour
{
    [Header("UIs")]
    [SerializeField] private PrepareUI _prepareUI;
    [SerializeField] private ClockUI _clockUI;

    public void Bind(GameFlowManager gameFlowManager)
    {
        _prepareUI.Bind(gameFlowManager.uiController);
        _clockUI.Bind(gameFlowManager.timeController);
    }
}