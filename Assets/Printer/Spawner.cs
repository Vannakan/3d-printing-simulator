using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Print;
    public Transform SpawnPoint;

    public void Spawn()
    {
        Instantiate(Print, SpawnPoint.position, transform.rotation);
    }
}
