using Assets.Code;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Screen_UI.Inventory
{
    // TODO: establish whether we can delete this or not
    // i ACTUALLY THINK we need to delete the other one
    public class DraggableInventoryItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public InventoryUIPanel InventoryUIPanel;
        public GameObject Current;
        public ToolbarItem CurrentToolbarItem;

        public InventoryItem InventoryItem;

        private bool _isHover;
        public bool IsHeld;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Debug.Log("LEFT SHIFT");
            }
            IsHeld = true;
            InventoryUIPanel?.SetDraggableInventoryItemInFocus(this);


            // new
            _isHover = false;
            ItemInfoPanelManager.Instance.Toggle(false);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsHeld = false;

            if (CurrentToolbarItem != null)
            {
                CurrentToolbarItem.SetInventoryItem(InventoryItem);
                CurrentToolbarItem = null;
            }
            var test = Current.GetComponent<DraggableInventoryItemContainer>();
            if (test != null)
            {
                if(test.InventoryUIPanel.gameObject == InventoryUIPanel.gameObject)
                {
                    Debug.Log("Same");
                    
                } else
                {
                    Debug.Log("Different");

                    InventoryUIPanel.MultiInventoryController.Swap(InventoryItem, test.InventoryUIPanel.GetComponent<InventoryUIPanel>(), InventoryUIPanel);
                   
                }
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
            if (collision.tag == "DraggableItemContainer")
            {
                //   Debug.Log("DRAGGABLE ITEM CONTAINER");
                if (collision.transform.childCount == 0)
                {
                    Current = collision.gameObject;
                }

                return;
            }

            if (collision.tag == "ToolbarItem")
            {
                CurrentToolbarItem = collision.gameObject.GetComponent<ToolbarItem>();

                Debug.Log("ToolbarItem trigger");

                return;
            }
        }

        /// <summary>
        /// /////new
        /// </summary>
        // todo once we're held we need to remove the item info panel
        public void SetItemInfoPanel()
        {
            if (_isHover)
            {
                ItemInfoPanelManager.Instance.SetPosition(Current.transform.position);
                ItemInfoPanelManager.Instance.SetText(InventoryItem.Item.Name);
            }
                
            ItemInfoPanelManager.Instance.Toggle(_isHover);
        }
        
        public IEnumerator CheckHover(float delay)
        {
            yield return new WaitForSeconds(delay);
            SetItemInfoPanel();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (IsHeld) return;
            Debug.Log("Pointer Enter");
            StartCoroutine(CheckHover(.5f));
            _isHover = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (IsHeld) return;
            Debug.Log("Pointer Exit");
            _isHover = false;
            StartCoroutine(CheckHover(.2f));
        }
    }
}
