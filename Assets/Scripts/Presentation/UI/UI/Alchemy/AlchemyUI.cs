using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AlchemyUI : MonoBehaviour,
    IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IDropHandler
{
    [SerializeField] private GameObject lightObj;
    [SerializeField] private Button ReturnButton;
    [SerializeField] private GameObject CoverSheet;
    
    [SerializeField] private List<AlchemySlotUI> slots;
    [SerializeField] private AlchemyResultItem slotItem;
    

    [SerializeField] private GameObject cartoon_1;
    [SerializeField] private GameObject cartoon_2;
    [SerializeField] private GameObject cartoon_3;

    private AlchemyController alchemyController;
    private InventoryController inventoryController;

    private bool isPressed;
    
    public void Bind(AlchemyController controller, InventoryController inventoryController)
    {
        alchemyController = controller;
        this.inventoryController = inventoryController;
        alchemyController.OnAlchemyChanged += RefreshSlots;
        RefreshSlots();
        ReturnButton.onClick.AddListener(alchemyController.ReturnItem);
        CoverSheet.SetActive(false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        var itemData = DragItemUI.Instance.GetDraggingItem();
        if (itemData == null) return;
        if (alchemyController.IsCrafted())
            return;
        
        if (!alchemyController.CanAddItem())
            return;
        
        inventoryController.RemoveItem(itemData, 1);
        
        alchemyController.AddItem(itemData);
    }

    private void RefreshSlots()
    {
        var items = alchemyController.Items;

        for (int i = 0; i < slots.Count; i++)
        {
            if (i < items.Count)
                slots[i].SetItem(items[i]);
            else
                slots[i].Clear();
        }

        if (alchemyController.IsCrafted())
        {
            slotItem.SetItem(alchemyController._craftedItem);
        }
        else slotItem.Clear();
    }

    private void StartCartoon()
    {
        StartCoroutine(Cartoon());
    }

    private IEnumerator  Cartoon()
    {
        CoverSheet.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        cartoon_1.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        cartoon_2.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        cartoon_3.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        cartoon_1.gameObject.SetActive(false);
        cartoon_2.gameObject.SetActive(false);
        cartoon_3.gameObject.SetActive(false);
        alchemyController.AlchemyAllItems();
        CoverSheet.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
        if (alchemyController.Items.Count <= 0)
            return;
        
        isPressed = true;
        lightObj.SetActive(true);
        StartCartoon();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Release();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Release();
    }

    private void Release()
    {
        if (!isPressed) return;

        isPressed = false;
        lightObj.SetActive(false);
    }
}