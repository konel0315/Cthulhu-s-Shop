using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AlchemyUI : MonoBehaviour,
    IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IDropHandler
{
    [SerializeField] private GameObject lightObj;
    [SerializeField] private List<AlchemySlotUI> slots;
    [SerializeField] private AlchemyResultItem slotItem;

    [SerializeField] private GameObject cartoon_1;
    [SerializeField] private GameObject cartoon_2;
    [SerializeField] private GameObject cartoon_3;

    private AlchemyController alchemyController;
    private InventoryController inventoryController;

    public void Bind(AlchemyController controller, InventoryController inventoryController)
    {
        alchemyController = controller;
        this.inventoryController = inventoryController;
        alchemyController.OnAlchemyChanged += RefreshSlots;
        RefreshSlots();
    }

    public void OnDrop(PointerEventData eventData)
    {
        var itemData = DragItemUI.Instance.GetDraggingItem();
        if (itemData == null) return;
        
        
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
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        lightObj.SetActive(true);
        StartCartoon();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        lightObj.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        lightObj.SetActive(false);
    }
}