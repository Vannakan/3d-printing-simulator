using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public PlayerInventory Inventory;
    public GameObject _target;
    public GameObject Cam;
    public int InteractDistance;


/*
    private void setCurrentPrinter(Printer p)
    {
        if(gameManager.GetComponent<GameManager>().go == p) return;

        if(gameManager.GetComponent<GameManager>().go!= null) gameManager.GetComponent<GameManager>().go.isLooking = false;

        gameManager.GetComponent<GameManager>().go = p;

        if(gameManager.GetComponent<GameManager>().go!=null) gameManager.GetComponent<GameManager>().go.isLooking = true;

    }
    */



    void Update()
    {

        

        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        int layer_mask = LayerMask.GetMask("Interactable");
        



        if (Physics.Raycast(ray, out RaycastHit hit, InteractDistance, layer_mask))
        {

            /*
            hit.transform.gameObject.GetComponent<Printer>().isLooking = true;

            var interact = hit.transform.gameObject.GetComponent<Printer>();
            gameManager.GetComponent<GameManager>().go = interact;

            if(hit.collider.TryGetComponent<Printer>(out var printer))
            {
                setCurrentPrinter(printer);
            }
            else
            {
                setCurrentPrinter(null);
            }

            */


            if (Input.GetKeyUp(KeyCode.Space))
            {
                var go = hit.transform.gameObject;
                go.transform.parent = Cam.transform;
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                var go = hit.transform.gameObject.GetComponent<Printer>();
                go.Toggle();
            }

            if (Input.GetKeyUp(KeyCode.Q))
            {
                var go = hit.transform.gameObject.GetComponent<Printer>();
                go.AddFilament(100);
            }         

        }
        
        

    }


    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != Tags.Item) return;

        var go = collision.collider.gameObject;
        var print = go.GetComponent<Print>();

        if (print is not null)
        {
            Inventory.Items.Add(print.Item);
            Destroy(go);
        }
    }
}

public class Tags
{
    public const string Item = nameof(Item);
    public const string Spool = nameof(Spool);
    public const string Print = nameof(Print);
    public const string Printer = nameof(Printer);
}
