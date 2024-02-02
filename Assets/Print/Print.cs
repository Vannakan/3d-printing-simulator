using UnityEngine;

public class Print : MonoBehaviour
{
    public Item Item { get; private set; }
    void Start()
    {
        Item = new Item()
        {
            Name = "Item",
            Value = default,
        };
    }
}
