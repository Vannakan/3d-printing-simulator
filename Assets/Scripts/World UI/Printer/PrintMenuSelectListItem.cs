using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.World_UI.Printer
{
    public class PrintMenuSelectListItem : MonoBehaviour
    {
        public bool IsSelected;
        public Image Border;
        public TextMeshProUGUI Text;
        public Button Test;
        public string Name;

        public void SetSelected(bool selected)
        {
            Border.color = selected ? Color.white : Color.clear;
            IsSelected = selected;
        }

        public void Activate()
        {
            Test?.onClick?.Invoke();
            Debug.Log("Activated  " + Name);
        }

    }

}
