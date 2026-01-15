using System;
using System.Net.Mime;
using UnityEngine;

public class UIController
{
    /*Prepare Class*/
    public event Action onShowUIPrepareUI;
    public event Action onHideUIPrepareUI;
    public event Action OnPrepareConfirmed;
    
    public void ShowUIPrepareUI()=>onShowUIPrepareUI?.Invoke();
    public void HideUIPrepareUI()=>onHideUIPrepareUI?.Invoke();
    
    public void PrepareConfirmed()
    {
        OnPrepareConfirmed?.Invoke();
    }
    
    /*Decision Class*/
    public event Action onShowUIDecisionNightUIShowUI;
    public event Action onHideUIDecisionNightUIShowUI;
    public event Action OnNightConfirmed;
    public event Action OnNextDayConfirmed;
    public void DecisionNightUIShowUI()=>onShowUIDecisionNightUIShowUI?.Invoke();
    public void DecisionNightUIHideUI()=>onHideUIDecisionNightUIShowUI?.Invoke();
    
    public void NightConfirmed()
    {
        OnNightConfirmed?.Invoke();
    }
    
    public void NextDayConfirmed()
    {
        OnNextDayConfirmed?.Invoke();
    }
    
    /*DayBackGround Class*/
    public event Action onShowUIDayBackgroundUI;
    public event Action onHideUIDayBackgroundUI;
    public void ShowUIDayBackgroundUI()=>onShowUIDayBackgroundUI?.Invoke();
    public void HideUIDayBackgroundUI()=>onHideUIDayBackgroundUI?.Invoke();
    
    /*NightBackGround Class*/
    public event Action onShowUINightBackgroundUI;
    public event Action onHideUINightBackgroundUI;
    public void ShowUINightBackgroundUI()=>onShowUINightBackgroundUI?.Invoke();
    public void HideUINightBackgroundUI()=>onHideUINightBackgroundUI?.Invoke();
    
    /*Decision Class*/
    public event Action OnAcceptPressed;
    public event Action OnRejectPressed;

    public event Action OnShowDecisionUI;
    public event Action OnHideDecisionUI;

    public void ShowDecisionUI() => OnShowDecisionUI?.Invoke();
    public void HideDecisionUI() => OnHideDecisionUI?.Invoke();

    public void Accept() => OnAcceptPressed?.Invoke();
    public void Reject() => OnRejectPressed?.Invoke();
    
    /*Visitor Class*/
    public event Action OnShowVisitorUI;
    public event Action OnHideVisitorUI;
    public event Action OnShowDialogueUI;
    public event Action OnHideDialogueUI;
    public event Action OnShowBubbleUI;
    public event Action OnHideBubbleUI;
    public event Action<string> onSetVisitorDialogue;
    public event Action<Sprite> onSetVisitorPortrait;
    public event Action<Sprite,Sprite> onSetVisitorBubbleTwoSprites;
    public event Action<Sprite> onSetVisitorBubble;
    
    public void ShowVisitorUI()=>OnShowVisitorUI?.Invoke();
    public void HideVisitorUI()=>OnHideVisitorUI?.Invoke();
    public void ShowDialogueUI()=>OnShowDialogueUI?.Invoke();
    public void HideDialogueUI()=>OnHideDialogueUI?.Invoke();
    public void ShowBubbleUI()=>OnShowBubbleUI?.Invoke();
    public void HideBubbleUI()=>OnHideBubbleUI?.Invoke();
    public void SetVisitorDialogue(string text) => onSetVisitorDialogue?.Invoke(text);
    public void SetVisitorPortrait(Sprite sprite) => onSetVisitorPortrait?.Invoke(sprite);
    public void SetVisitorBubbleTwoSprites(Sprite spriteLeft,Sprite spriteRight) => onSetVisitorBubbleTwoSprites?.Invoke(spriteLeft,spriteRight);
    public void SetVisitorBubble(Sprite sprite)=> onSetVisitorBubble?.Invoke(sprite);
    
    

}