using UnityEngine;
using UnityEngine.UI;

public class DragItemUI : MonoBehaviour
{
    public static DragItemUI Instance;

    [SerializeField] private Image icon;  // 드래그 중 표시될 아이템 이미지

    private ItemSO currentItem;

    void Awake()
    {
        // 싱글톤 초기화
        Instance = this;
        gameObject.SetActive(false); // 시작 시 숨김
    }

    void Update()
    {
        // 드래그 중이면 마우스를 따라 이동
        if (gameObject.activeSelf)
        {
            transform.position = Input.mousePosition;
        }
    }

    // 드래그 시작
    public void BeginDrag(ItemSO item)
    {
        if (item == null) return;

        currentItem = item;
        icon.sprite = item.icon;
        gameObject.SetActive(true);
    }

    // 드래그 종료
    public void EndDrag()
    {
        currentItem = null;
        gameObject.SetActive(false);
    }

    // 현재 드래그 중인 아이템 반환 (Drop 시 사용)
    public ItemSO GetDraggingItem()
    {
        return currentItem;
    }
}