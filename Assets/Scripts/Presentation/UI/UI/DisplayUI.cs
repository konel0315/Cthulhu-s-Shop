using System.Collections.Generic;
using UnityEngine;

public class DisplayUI : MonoBehaviour
{
    private DisplayController _displayController;
    [SerializeField] private List<DisplaySlotUI> slots;
    public void Bind(DisplayController displayController)
    {
        _displayController = displayController;
        
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].Bind(_displayController, i);
        }
        RefreshUI();
        _displayController.OnDisplayChanged += RefreshUI;
    }

    private void RefreshUI()
    {
        if(_displayController == null) return;
        
        for(int i=0;i<3;i++)
        {
            var items = _displayController.GetItemAt(i);
            if (items != null)
            {
                slots[i].SetSlot(items,1);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

}