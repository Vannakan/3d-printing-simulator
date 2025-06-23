using Assets;
using System.Net;
using UnityEngine;

public class PrinterNode : MonoBehaviour
{
    public bool _isOccupied { get => Printer != null; }
    public GameObject Printer;
    public AudioSource AudioSource;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag is Tags.Printer)  // && !_isOccupied)
        {
            Debug.Log("ENTER");
            collision.transform.position = transform.position;
          //  collision.transform.rotation = transform.rotation;
            collision.transform.parent = null;
            //collision.transform.rotation = transform.rotation;
            collision.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            AudioSource.Play();
            // _occupier = collision.gameObject; 
            //  _occupier.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

  //  public void OnTriggerExit(Collider collision)
  //  {
  ////      if (!(collision.gameObject.tag is Tags.Printer && _isOccupied && _occupier == collision.gameObject)) return;
  //      Debug.Log("LEAVE");
  //      //collision.transform.position = transform.position;
  //      //collision.transform.rotation = transform.rotation;
  //      _occupier = null;
  //  }
}
