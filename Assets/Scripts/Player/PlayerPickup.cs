using Assets;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public PlayerInventory Inventory;
    public AudioSource AudioSource;

    public int PickupProgress = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PickupProgress++;
            if (PickupProgress >= 100)
            {
                // Pickup the item
                // Call core to deactivate this behaviour?
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag is not Tags.Item) return; // Change to be Pickup tag

        var go = collision.collider.gameObject;
        var pickup = go.GetComponent<Pickup>();

        if (pickup is not null)
        {
            AudioSource.Play();
            if(pickup.Item != null)
            {
                Inventory.Add(pickup.Item);
            }
               
            Destroy(go);
        }
    }
}
