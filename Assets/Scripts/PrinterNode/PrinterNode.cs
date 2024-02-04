using UnityEngine;

public class PrinterNode : MonoBehaviour
{
    private bool _isOccupied { get => _occupier != null; }
    private GameObject _occupier;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag is Tags.Printer && !_isOccupied)
        {
            collision.transform.position = transform.position;
            collision.transform.parent = null;
            collision.transform.rotation = transform.rotation;
            _occupier = collision.gameObject; 
            
        }
    }

    public void OnTriggerLeave(Collider collision)
    {
        if (!(collision.gameObject.tag is Tags.Printer && _isOccupied && _occupier == collision.gameObject)) return;

        collision.transform.position = transform.position;
        collision.transform.rotation = transform.rotation;
        collision.transform.parent = null;
        _occupier = null;
    }
}
