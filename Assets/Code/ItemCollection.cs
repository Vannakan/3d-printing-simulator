using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Code
{
    [Serializable]
    public class ItemCollection
    {
        private List<InventoryItem> _items = new();
        public IReadOnlyList<InventoryItem> Items { get => _items; }

        public List<InventoryItem> ItemsCopy;

        public void Add(InventoryItem item)
        {
            if (_items.Any(e => e.Id == item.Id))
            {
                Debug.LogError("Attempted to add a dupelicate inventory item");
                return;
            }

            _items.Add(item);

            ItemsCopy = Items.ToList();

            ToastNotificationManager.Instance.Create($"Added {item.Item.name}");
        }

        public void Swap(InventoryItem a, InventoryItem b)
        {
            var aIndex = _items.IndexOf(a);
            var bIndex = _items.IndexOf(b);
            var aItem = _items[aIndex];
            var bItem = _items[bIndex];
            _items[aIndex] = bItem;
            _items[bIndex] = aItem;
        }

        public void Remove(InventoryItem item)
        {
            var existing = _items.FirstOrDefault(e => e.Id == item.Id);
            if (existing is null)
            {
                Debug.LogError($"{item.Id} does not exist");
                return;
            }

            _items.Remove(existing);

            ItemsCopy = Items.ToList();
        }

        public InventoryItem? GetById(int id) => _items.FirstOrDefault(e => e.Id == id);
        public InventoryItem? GetByIndex(int index)
        {
            if (index + 1 > _items.Count)
            {
                return null;
            }

            var item = _items[index];

            return item;
        }
    }
}
