using System;
using UnityEngine;

public class MVPBreadVisitor : ScriptedVisitor,IChoosable
{
    public override void Enter()
    {
        uiController.ShowVisitorUI();
        uiController.SetVisitorPortrait(Resources.Load<Sprite>("Visitors/배고픈 행인"));
    }

    public override void OnTextUI()
    {
        uiController.ShowDialogueUI();
        uiController.ShowBubbleUI();
    }

    public override void OffTextUI()
    {
        uiController.HideDialogueUI();
        uiController.HideBubbleUI();
    }

    public override void Play(Action onFinished)
    {
        OnTextUI();
        uiController.SetVisitorDialogue("이봐, 빵 하나만 줘.\n사흘동안 아무것도 먹질 못했거든, 대신 이 낡은 구리 단검을 줄테니 빵과 바꾸자고.");
        uiController.SetVisitorBubbleTwoSprites(Resources.Load<Sprite>("UI/Items/빵"), Resources.Load<Sprite>("UI/Items/낡은구리단검"));
        
        uiController.ShowHoldingUI();
        onFinished?.Invoke();
    }

    public override bool CanAccept()
    {
        if(holdingAreaController.IsItem("빵",1)) return true;
        return  false;
    }

    public void OnAccept()
    {
        //uiController.SetVisitorPortrait(Resources.Load<Sprite>("Visitors/감사한 행인"));
        ItemSO Old_Copper_Dagger = Resources.Load<ItemSO>("Data/Item/Old_Copper_Dagger");
        holdingAreaController.CreateTaking(Old_Copper_Dagger,1);
        uiController.SetVisitorDialogue("돌아가는 길에 뺏기지나 말아야 할텐데...");
        uiController.HideBubbleUI();
    }

    public void OnReject()
    {
        uiController.SetVisitorDialogue("(부랑자는 바닥에 침을 뱉고는 사라졌다)");
        uiController.HideBubbleUI();
    }

    public override void Exit()
    {
        OffTextUI();
        uiController.HideVisitorUI();
    }
}