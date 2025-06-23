using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeliveryBoxUI : MonoBehaviour
{
    public DeliveryBox DeliveryBox;

    public TextMeshProUGUI Text; 
    private IEnumerator Poll()
    {
        while (true)
        {
            Text.text = $"{DeliveryBox.Current}/{DeliveryBox.Capacity}";
            yield return new WaitForSeconds(0.2f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Poll());
    }
}
