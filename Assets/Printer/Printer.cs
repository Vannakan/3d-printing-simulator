using UnityEngine;

public class Printer : MonoBehaviour
{
    public GameObject PrintPrefab;
    public Transform SpawnPoint;

    public float TotalFilament;
    public float PrintTime;

    private bool _isPrinting;
    private float _printStart;
    private readonly float _printCost = .1f;
    public Renderer PrintMesh;

    public void Toggle()
    {
        _isPrinting = !_isPrinting;
        ChangeColor();
    }

    public void AddFilament(float filament) => TotalFilament += filament;

    void ChangeColor() => PrintMesh.material.SetColor("_Color", _isPrinting == true ? Color.green : Color.red);

    void Update()
    {
        if (_isPrinting)
        {
            if (TotalFilament <= 0.0)
                Toggle();
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
        }
    }
}
