using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPurchase : MonoBehaviour
{
    private bool _cooldown;

    public void Spawn(GameObject prefab) => StartCoroutine(SpawnItem(prefab));

    IEnumerator SpawnItem(GameObject prefab)
    {
        if (_cooldown) yield break;

        _cooldown = true;
        Instantiate(prefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(3);
        _cooldown = false;
        yield break;
    }
}
