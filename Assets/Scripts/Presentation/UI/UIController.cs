using System;

public class UIController
{
    public event Action OnPrepareConfirmed;
    public event Action OnNightConfirmed;
    public event Action OnNextDayConfirmed;

    private bool isPrepareUIVisible;
    public void ShowUIPrepareUI()=>isPrepareUIVisible=true;
    public void HideUIPrepareUI()=>isPrepareUIVisible=false;
    
    
    //밤 낮 선택 버튼 부분 생성 예정
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