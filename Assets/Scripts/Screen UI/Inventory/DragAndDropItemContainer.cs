using Assets.Code;
using Assets.Scripts.Screen_UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropItemContainer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
{
    public PlayerInventoryUIPanel PlayerInventoryUIPanel;
    // todo store the gameobject and the type of collider
    public GameObject Current;
    public ToolbarItem CurrentToolbarItem;

    public InventoryItem InventoryItem;

    public bool IsHeld;

    public void OnPointerDown(PointerEventData eventData)
    {
    //    if (Input.GetKey(KeyCode.LeftShift)) return;
        IsHeld = true;
        PlayerInventoryUIPanel?.SetDraggableInventoryItemInFocus(this);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    Debug.Log("CLICKED");
        //    return;
        //}

        //   Destroy(gameObject);
        IsHeld = false;

        if (CurrentToolbarItem != null)
        {
            CurrentToolbarItem.SetInventoryItem(InventoryItem);
            CurrentToolbarItem = null;
        }

        GetComponent<RectTransform>().SetParent(Current.transform);
        transform.localPosition = Vector3.zero;
        CurrentToolbarItem = null;
    }


    void Update()
    {
        if (!IsHeld) return;
        transform.position = Input.mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DraggableItemContainer")
        {
         //   Debug.Log("DRAGGABLE ITEM CONTAINER");
            if (collision.transform.childCount == 0)
            {
                Current = collision.gameObject;
            }

            return;
        }

        if(collision.tag == "ToolbarItem")
        {
            CurrentToolbarItem = collision.gameObject.GetComponent<ToolbarItem>();  

            Debug.Log("ToolbarItem trigger");

            return;
        }
    }


}
