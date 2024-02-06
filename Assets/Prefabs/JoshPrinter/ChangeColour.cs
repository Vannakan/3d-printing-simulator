using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeOutline : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    private List<GameObject> _objectsWithOutline = new List<GameObject>();
    public GameManager Manager;

    void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            Renderer hitRenderer = _hit.transform.gameObject.GetComponentInChildren<Renderer>();


            if (hitRenderer != null)
            {
                Outline hitOutline = hitRenderer.GetComponent<Outline>();

                if (hitOutline != null)
                {
                    hitOutline.enabled = true;
                    _objectsWithOutline.Add(_hit.transform.gameObject);

                    foreach (GameObject previousObject in _objectsWithOutline)
                    {
                        if (previousObject != _hit.transform.gameObject)
                        {
                            previousObject.GetComponentInChildren<Renderer>().GetComponent<Outline>().enabled = false;
                        }
                    }
                }
            }
        }
        else
        {
            // Disable outline for all previously hit objects
            foreach (GameObject previousObject in _objectsWithOutline)
            {
                previousObject.GetComponentInChildren<Renderer>().GetComponent<Outline>().enabled = false;
            }

        }
    }
}
