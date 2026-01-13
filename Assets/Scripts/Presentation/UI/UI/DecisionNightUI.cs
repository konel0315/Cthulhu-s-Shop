using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DecisionNightUI : MonoBehaviour
{
    [SerializeField] private GameObject root;
    [SerializeField] private GameObject Wood;
    [SerializeField] private Button NextDayButton;
    [SerializeField] private Button NightButton;
    
    private UIController uiController;

    public void Bind(UIController uiController)
    {   
        this.uiController = uiController;
        uiController.onShowUIDecisionNightUIShowUI += onShowUIDecisionNightUIShowUI;
        uiController.onHideUIDecisionNightUIShowUI += onHideUIDecisionNightUIShowUI;
        NextDayButton.onClick.AddListener(uiController.NextDayConfirmed);
        NightButton.onClick.AddListener(uiController.NightConfirmed);
    }
    
    private void onShowUIDecisionNightUIShowUI()=>root.SetActive(true);
    private void onHideUIDecisionNightUIShowUI()=>root.SetActive(false);
    
    
    
    
    
    private void OnEnable()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(Wood.transform.DOLocalRotate(new Vector3(0,0,0), 2.5f)
            .SetEase(Ease.OutBounce));

    }
    private void OnDisable()
    {
        Wood.transform.rotation = Quaternion.Euler(0,0,-90);
    }
    
    
}