using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets.Scripts.World_UI.Printer
{
    public class PrintMenuSelectListScreen : MonoBehaviour
    {
        private int _index;
        public List<PrintMenuSelectListItem> Options;
        public PrintMenuSelectListItem Selected;
        protected bool isInitialized;
        //public GameObject PrintMenuSelectListItemPrefab;

        public virtual void Initialize()
        {
            if (isInitialized) return;
            foreach (Transform child in transform)
            {
                var item = child.GetComponent<PrintMenuSelectListItem>();
                if (item is null) continue;
                Options.Add(item);
            }

            Options.Reverse();

            Selected = Options[0];
            Selected.SetSelected(true);

            isInitialized = true;
        }

        public void Up()
        {
            if (_index < Options.Count)
            {
                _index++;
                var item = Options[_index];
                Selected.SetSelected(false);
                item.SetSelected(true);
                Selected = item;
            }
        }

        public void Down()
        {
            if (_index > 0)
            {
                _index--;
                var item = Options[_index];
                Selected.SetSelected(false);
                item.SetSelected(true);
                Selected = item;
            }
        }

        public void Select()
        {
            Selected.Activate();
        }
    }
}
