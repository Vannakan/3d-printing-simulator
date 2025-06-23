using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ShopBasketUI : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public Shop Shop;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PollBasket());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PollBasket()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Text.text = $"({Shop.Basket.Count})";
        }
    }
}
