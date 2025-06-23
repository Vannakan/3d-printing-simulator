using Assets.Code;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Screen_UI
{
    public class PlayerInventoryUIPanel : MonoBehaviour
    {
        public GameObject List;

        public GameObject DraggableInventoryItemPrefab;

        public List<GameObject> PlayerInventoryUIPanelItemContainers;
        public List<DragAndDropItemContainer> DragAndDropItemContainers;

        public void Initialize()
        {
            if (PlayerInventoryUIPanelItemContainers.Count != 0) return;

            foreach (Transform item in List.transform)
                PlayerInventoryUIPanelItemContainers.Add(item.gameObject);

        }

        public void RenderPlayerInventoryItems(IReadOnlyList<InventoryItem> ItemsToRender)
        {
            var containers = new Queue<GameObject>(PlayerInventoryUIPanelItemContainers);

            // An easier and more efficient way to do this is probably to track a list of the current draggable items on the scene
            // and then wipe them here instead of a nested loop over the containers + draggable
            foreach(Transform item in List.transform)
            {
                foreach(Transform draggable in item.transform)
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

                var draggableItem = go.GetComponent<DragAndDropItemContainer>();

                draggableItem.Current = container;
                draggableItem.PlayerInventoryUIPanel = this;
                draggableItem.InventoryItem = item;
            }
        }

        public void SetDraggableInventoryItemInFocus(DragAndDropItemContainer item)
        {
            item.GetComponent<RectTransform>().SetParent(transform);
        }
    }

}
