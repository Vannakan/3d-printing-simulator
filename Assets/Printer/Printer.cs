using UnityEngine;

public class Printer : MonoBehaviour
{
    public GameObject PrintPrefab;
    public Transform SpawnPoint;
    private Renderer _renderer;

    public float TotalFilament;
    public float PrintTime;

    private bool _isPrinting;
    private float _printStart;
    private readonly float _printCost = .1f;

    public void Toggle()
    {
        _isPrinting = !_isPrinting;
        ChangeColor();
    }

    public void AddFilament(float filament) => TotalFilament += filament;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void ChangeColor() => _renderer.material.SetColor("_Color", _isPrinting == true ? Color.green : Color.red);

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
