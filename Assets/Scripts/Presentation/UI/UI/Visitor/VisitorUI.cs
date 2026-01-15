using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VisitorUI : MonoBehaviour
{
    [Header("Roots")]
    [SerializeField] private GameObject visitorRoot;
    [SerializeField] private GameObject visitorBubble;
    [SerializeField] private GameObject visitorDialogue;
    
    [Header("Visitors")]
    [SerializeField] private Image  visitorPortrait;
    
    [Header("Dialogue")]
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Bubble")]
    [SerializeField] private Image  bubbleSingle;
    [SerializeField] private Image  bubbleLeft;
    [SerializeField] private Image  bubbleRight;
    
    private UIController uiController;

    public void Bind(UIController uiController)
    {
        this.uiController = uiController;

        // Show / Hide
        uiController.OnShowVisitorUI += ShowVisitor;
        uiController.OnHideVisitorUI += HideVisitor;

        uiController.OnShowDialogueUI += ShowDialogue;
        uiController.OnHideDialogueUI += HideDialogue;

        uiController.OnShowBubbleUI += ShowBubble;
        uiController.OnHideBubbleUI += HideBubble;

        // Content
        uiController.onSetVisitorDialogue += SetDialogue;
        uiController.onSetVisitorPortrait += SetPortrait;
        uiController.onSetVisitorBubble += SetSingleBubble;
        uiController.onSetVisitorBubbleTwoSprites += SetDoubleBubble;
    }

    private void OnDestroy()
    {
        if (uiController == null) return;

        uiController.OnShowVisitorUI -= ShowVisitor;
        uiController.OnHideVisitorUI -= HideVisitor;

        uiController.OnShowDialogueUI -= ShowDialogue;
        uiController.OnHideDialogueUI -= HideDialogue;

        uiController.OnShowBubbleUI -= ShowBubble;
        uiController.OnHideBubbleUI -= HideBubble;

        uiController.onSetVisitorDialogue -= SetDialogue;
        uiController.onSetVisitorPortrait -= SetPortrait;
        uiController.onSetVisitorBubble -= SetSingleBubble;
        uiController.onSetVisitorBubbleTwoSprites -= SetDoubleBubble;
    }

    // ===== Show / Hide =====

    private void ShowVisitor() => visitorRoot.SetActive(true);
    private void HideVisitor() => visitorRoot.SetActive(false);

    private void ShowDialogue() => visitorDialogue.SetActive(true);
    private void HideDialogue() => visitorDialogue.SetActive(false);

    private void ShowBubble() => visitorBubble.SetActive(true);
    private void HideBubble() => visitorBubble.SetActive(false);
    
    //====Set Content====
    
    private void SetPortrait(Sprite sprite)
    {
        visitorPortrait.sprite = sprite;
    }

    private void SetDialogue(string text)
    {
        dialogueText.text = text;
    }

    private void SetSingleBubble(Sprite sprite)
    {
        bubbleLeft.gameObject.SetActive(false);
        bubbleRight.gameObject.SetActive(false);
        bubbleSingle.gameObject.SetActive(true);
        
        bubbleSingle.sprite=sprite;
    }

    private void SetDoubleBubble(Sprite sprite, Sprite sprite2)
    {
        bubbleLeft.gameObject.SetActive(true);
        bubbleRight.gameObject.SetActive(true);
        bubbleSingle.gameObject.SetActive(false);
        
        bubbleLeft.sprite=sprite;
        bubbleRight.sprite=sprite2;
    }

}