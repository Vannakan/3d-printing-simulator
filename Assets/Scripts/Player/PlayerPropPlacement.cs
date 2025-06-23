using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPropPlacement : MonoBehaviour
{
    public GameObject Placeholder;
    public int PlaceDistance;
    public PlayerInventory PlayerInventory;

    //Lame need to change this

    public Mesh Table;


    public void CheckModel()
    {
        if (PlayerInventory.CurrentEquippedItem is not null)
        {
            var filter = Placeholder.GetComponent<MeshFilter>();
            filter.mesh = Table;
        }
    }

    public void CheckPlacement()
    {
        var layerMask = LayerMask.GetMask("Default");

        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        if (!Input.GetKeyUp(KeyCode.F)) return;

        if (Physics.Raycast(ray, out var hit, PlaceDistance, layerMask))
        {
            if (hit.transform.gameObject.tag == "Floor")
            {
                // Get Placeholder
                // Move Placeholder position 
            }
        }
    }

}