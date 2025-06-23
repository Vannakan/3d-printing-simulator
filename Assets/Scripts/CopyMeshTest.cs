using Assets.Code;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMeshTest : MonoBehaviour
{
    public GameObject Placeholder;
    public GameObject Target;
    public GameObject TestMesh;
    public int PlaceDistance;

    public PlayerInventory PlayerInventory;

    public int Rotation;

    public bool Active = false;
    public void CopyMesh(GameObject go)
    {
        var components = go.GetComponentsInChildren<MeshFilter>();

        foreach(Transform child in Placeholder.transform)
        {
            Destroy(child.gameObject);
        }
        // Overarching GO influences scale of other meshes
      //  Placeholder.transform.localScale = go.transform.localScale;
        foreach (var component in components)
        {
            //Copy the sub mesh scales
            var testMesh = Instantiate(TestMesh, Placeholder.transform);
            testMesh.transform.localScale = component.transform.localScale;
            testMesh.transform.localPosition = component.transform.localPosition;
            testMesh.transform.localRotation = component.transform.localRotation;
            testMesh.GetComponent<MeshFilter>().mesh = component.GetComponent<MeshFilter>().sharedMesh;
            testMesh.GetComponent<MeshRenderer>().materials = component.GetComponent<MeshRenderer>().sharedMaterials;

        }

    }

    void OnPlayerEquippedItemChanged(object src, EventArgs e)
    {
        // var current = PlayerInventory.CurrentEquippedItem;
         var current = PlayerInventory.CurrentEquippedItem;
        if (current != null && current?.Item?.ItemType == ItemType.Prop)
        {
            Active = true;
            Placeholder.SetActive(true);
            Target = current.Item.Prefab;
            CopyMesh(Target);
            FindDistanceFromMeshToGround();
        } else
        {
            Active = false;
            Placeholder.SetActive(false);
        }
    }

    void Start()
    {
        PlayerInventory.EquippedItemChanged += OnPlayerEquippedItemChanged;
        Placeholder.SetActive(false);
        Target = PrefabManager.Instance.PrefabMap["Table"];
     
    //    StartCoroutine(CheckPlacement());
    }

    private void FindDistanceFromMeshToGround()
    {
        var layerMask = LayerMask.GetMask("Default");
        var ray = new Ray(Placeholder.transform.position, Vector3.down);
        if (Physics.Raycast(ray, out var hit, PlaceDistance, layerMask))
        {
            if (hit.transform.gameObject.tag == "Floor")
            {
                var distance = Vector3.Distance(Placeholder.transform.position, hit.transform.position);
                Debug.Log(distance);

            }
        }
    }

    private void Update()
    {
        if (Active == false) return;
        var layerMask = LayerMask.GetMask("Default");

        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        // if (!Input.GetKeyUp(KeyCode.F)) return;

        if (Physics.Raycast(ray, out var hit, PlaceDistance, layerMask))
        {
            if (hit.transform.gameObject.tag == "Floor")
            {
              //  Debug.Log("Hello");
                Placeholder.transform.position = ray.origin + (ray.direction * 2);
                Placeholder.transform.position = new Vector3(Placeholder.transform.position.x, 0, Placeholder.transform.position.z);
                Placeholder.transform.localPosition = new Vector3(Placeholder.transform.localPosition.x, 0, Placeholder.transform.localPosition.z);
                // Get Placeholder
                // Move Placeholder position 
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Rotation += 90;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Rotation -= 90;
        }

        Placeholder.transform.rotation = Quaternion.Euler(0, Rotation, Placeholder.transform.rotation.z);

        if (Input.GetMouseButtonUp(0))
        {
            
            var obj = Instantiate(Target, Placeholder.transform, true);
            obj.transform.position = Placeholder.transform.position;

            obj.transform.localRotation = Quaternion.Euler(Target.transform.localRotation.x, Placeholder.transform.localRotation.y, Target.transform.localRotation.z);
             //   Placeholder.transform.localRotation;

            obj.transform.parent = null;

            PlayerInventory.Remove(PlayerInventory.CurrentEquippedItem);

        }
    }
}
