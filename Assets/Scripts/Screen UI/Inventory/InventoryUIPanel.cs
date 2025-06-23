using Assets.Code;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Screen_UI.Inventory
{
    public class InventoryUIPanel : MonoBehaviour
    {
        public GameObject List;

        public GameObject DraggableInventoryItemPrefab;

        public List<GameObject> InventoryUIItemContainers;
        public List<DraggableInventoryItem> DraggableInventoryItems;

        public MultiInventoryController MultiInventoryController;

        public GameObject DragZone;

        public void Initialize()
        {
            if (InventoryUIItemContainers.Count != 0) return;

            foreach (Transform item in List.transform)
                InventoryUIItemContainers.Add(item.gameObject);
        }

        public void RenderInventoryItems(IReadOnlyList<InventoryItem> ItemsToRender)
        {
            var containers = new Queue<GameObject>(InventoryUIItemContainers);

            // An easier and more efficient way to do this is probably to track a list of the current draggable items on the scene
            // and then wipe them here instead of a nested loop over the containers + draggable
            foreach (Transform item in List.transform)
            {
                foreach (Transform draggable in item.transform)
                {
                    Destroy(draggable.gameObject);
                }
            }

            foreach (var item in ItemsToRender)
            {
                if (containers.Count <= 0) return;

                var container = containers.Dequeue();
                //Create a game object
                var go = Instantiate(DraggableInventoryItemPrefab, container.transform);
                go.SetActive(true);
                go.GetComponent<Image>().sprite = item.Item.Sprite;

                var draggableItem = go.GetComponent<DraggableInventoryItem>();

                draggableItem.Current = container;
                draggableItem.InventoryUIPanel = this;
                draggableItem.InventoryItem = item;
            }
        }

        public void SetDraggableInventoryItemInFocus(DraggableInventoryItem item)
        {
            item.GetComponent<RectTransform>().SetParent(DragZone?.transform ?? transform);
        }
    }
}
