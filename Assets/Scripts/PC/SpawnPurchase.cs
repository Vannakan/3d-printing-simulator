using System;
using System.Collections;
using UnityEngine;

public class SpawnPurchase : MonoBehaviour
{
    private bool _cooldown;

    public void Spawn(GameObject prefab, Action<GameObject> action = null) => StartCoroutine(SpawnItem(prefab, action));

    IEnumerator SpawnItem(GameObject prefab, Action<GameObject> action = null)
    {
      //  if (_cooldown) yield break;

     //   _cooldown = true;
        var gameobject = Instantiate(prefab, transform.position, transform.rotation);
        if(action != null)
        {
            action(gameobject);
        }
     //   yield return new WaitForSeconds(3);
     ////   _cooldown = false;
        yield break;
    }
}
