using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public SpawnPurchase Spawn;
    public GameObject PrinterPrefab;
    public GameObject FilamentPrefab;

    public void SpawnFilament()
    {
        Spawn.Spawn(FilamentPrefab);
    }

    public void SpawnPrinter()
    {
        Spawn.Spawn(PrinterPrefab);
    }
}
