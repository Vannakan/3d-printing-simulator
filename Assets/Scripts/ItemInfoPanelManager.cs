using System;
using TMPro;
using UnityEngine;

public class ItemInfoPanelManager : MonoBehaviour
{
    private static ItemInfoPanelManager instance;
    public static ItemInfoPanelManager Instance { get => instance; }
    public GameObject InfoPanel;

    private void Awake()
    {
        instance = this;
    }

    public void SetPosition(Vector3 pos)
    {
        InfoPanel.transform.transform.position = pos;
    }

    public void Toggle(bool? active = null)
    {
        if(active is not null)
        {
            InfoPanel.SetActive(active.Value);
        } else
        {
            InfoPanel.SetActive(!InfoPanel.activeInHierarchy);
        }
    }

    internal void SetText(string name)
    {
        InfoPanel.GetComponent<TextMeshProUGUI>().text = name;  
    }
}
