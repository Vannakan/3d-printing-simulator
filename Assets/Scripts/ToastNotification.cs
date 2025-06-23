using System.Collections;
using TMPro;
using UnityEngine;

public class ToastNotification : MonoBehaviour
{
    public Vector3 Force;
    public int LifetimeSeconds;
    public Rigidbody2D Rigidbody;
    public TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        Rigidbody.AddForce(Force);
        yield return new WaitForSeconds(LifetimeSeconds);
        Destroy(gameObject);
    }

    private void Update()
    {
        Text.alpha -= 0.002f;
    }
}
