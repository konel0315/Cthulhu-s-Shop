using UnityEngine;
using UnityEngine.UI;

public class DragItemUI : MonoBehaviour
{
    public static DragItemUI Instance;

    [SerializeField] private Image icon;

    private ItemSO currentItem;
    
    private HoldingAreaController holdingArea;
    public void Bind(HoldingAreaController holdingArea)
    {
        this.holdingArea = holdingArea;
    }
    
    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameObject.activeSelf)
        {
            transform.position = Input.mousePosition;
        }
    }
    
    public bool CanStartDrag()
    {
        return holdingArea == null || !holdingArea.HasItem;
    }

    public void UpdatePosition(Vector3 position)
    {
        transform.position = position;
    }
    
    public void BeginDrag(ItemSO item)
    {
        if (item == null) {return;}

        //if (!CanStartDrag())
            //return;
        
        currentItem = item;
        icon.sprite = item.icon;
        gameObject.SetActive(true);
    }
    
    public void EndDrag()
    {
        currentItem = null;
        gameObject.SetActive(false);
    }
    
    public ItemSO GetDraggingItem()
    {
        return currentItem;
    }
}