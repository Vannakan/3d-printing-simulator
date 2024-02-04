using UnityEngine;

public class Printer : MonoBehaviour
{
    public GameObject PrintPrefab;
    public Transform SpawnPoint;

    public GameObject SpoolHolder; //remove this

    public float TotalFilament;
    public float PrintTime;
    public string PrintStatus;

    private bool _isPrinting;
    private float _printStart;
    private readonly float _printCost = .1f;
    public Renderer PrintMesh;

    public void Toggle(string status = "")
    {
        _isPrinting = !_isPrinting;

        if (status == string.Empty)
        {
            status = _isPrinting ? "Printing" : "Not Printing";
        }

        PrintStatus = status;
        ChangeColor();
    }

    public void AddFilament(float filament) => TotalFilament += filament;

    void ChangeColor() => PrintMesh.material.SetColor("_Color", _isPrinting == true ? Color.green : Color.red);


    private void Start()
    {
        PrintStatus = "Not Printing";
        ChangeColor();
    }

    void Update()
    {
        if (_isPrinting)
        {
            if (TotalFilament <= 0.0)
            {
                SpoolHolder.SetActive(false);
                Toggle("No Filament");
            }
            else TotalFilament -= _printCost;     
        }

        if (Time.time > _printStart && _isPrinting)
        {
            Instantiate(PrintPrefab, SpawnPoint.position, transform.rotation);
            _printStart = Time.time + PrintTime;
        }

        transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tags.Spool)
        {
            TotalFilament += 350; //todo: filament.amount
            Destroy(other.gameObject);
            SpoolHolder.SetActive(true);
        }
    }
}
