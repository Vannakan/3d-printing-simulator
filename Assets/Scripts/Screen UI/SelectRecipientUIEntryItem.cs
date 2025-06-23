using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Screen_UI
{
    public class SelectRecipientUIEntryItem : MonoBehaviour
    {
        public TextMeshProUGUI Text;
        public string Recipient;

        public event EventHandler<string> OnButtonClicked;

        public void SetRecipient(string recipient)
        {
            Recipient = recipient;
            Text.text = Recipient;
        }

        public void Click()
        {
            OnButtonClicked?.Invoke(this, Recipient);
        }
    }

}
