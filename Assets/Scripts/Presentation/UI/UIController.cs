using System;

public class UIController
{
    public event Action OnPrepareConfirmed;
    public event Action OnNightConfirmed;
    public event Action OnNextDayConfirmed;
    public event Action onShowUIPrepareUI;
    public event Action onHideUIPrepareUI;
    public event Action onShowUIDecisionNightUIShowUI;
    public event Action onHideUIDecisionNightUIShowUI;
    public event Action onShowUIDayBackgroundUI;
    public event Action onHideUIDayBackgroundUI;
    public event Action onShowUINightBackgroundUI;
    public event Action onHideUINightBackgroundUI;
    
    
    public void ShowUIPrepareUI()=>onShowUIPrepareUI?.Invoke();
    public void HideUIPrepareUI()=>onHideUIPrepareUI?.Invoke();
    
    public void DecisionNightUIShowUI()=>onShowUIDecisionNightUIShowUI?.Invoke();
    public void DecisionNightUIHideUI()=>onHideUIDecisionNightUIShowUI?.Invoke();
    
    public void ShowUIDayBackgroundUI()=>onShowUIDayBackgroundUI?.Invoke();
    public void HideUIDayBackgroundUI()=>onHideUIDayBackgroundUI?.Invoke();
    
    public void ShowUINightBackgroundUI()=>onShowUINightBackgroundUI?.Invoke();
    public void HideUINightBackgroundUI()=>onHideUINightBackgroundUI?.Invoke();
    
    public void PrepareConfirmed()
    {
        OnPrepareConfirmed?.Invoke();
    }
    public void NightConfirmed()
    {
        OnNightConfirmed?.Invoke();
    }
    public void NextDayConfirmed()
    {
        OnNextDayConfirmed?.Invoke();
    }
    
}