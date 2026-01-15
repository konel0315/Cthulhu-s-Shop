using System;
using UnityEngine;

public class MVPBreadVisitor : ScriptedVisitor
{
    public override void Enter()
    {
        uiController.ShowVisitorUI();
        uiController.ShowBubbleUI();
        uiController.ShowDialogueUI();
    }

    public override void Play(Action onFinished)
    {
        uiController.SetVisitorPortrait(Resources.Load<Sprite>("Visitors/배고픈 행인"));
        uiController.SetVisitorDialogue("이봐, 빵 하나만 줘.\n사흘동안 아무것도 먹질 못했거든, 대신 이 낡은 구리 단검을 줄테니 빵과 바꾸자고.");
        uiController.SetVisitorBubbleTwoSprites(Resources.Load<Sprite>("UI/Items/빵"), Resources.Load<Sprite>("UI/Items/낡은구리단검"));
        
        
        onFinished?.Invoke();
    }

    public void OnAccept()
    {
        
    }

    public void OnReject()
    {
    }

    public override void Exit()
    {
        uiController.HideVisitorUI();
        uiController.HideBubbleUI();
        uiController.HideDialogueUI();
    }
}