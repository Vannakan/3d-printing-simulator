using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PrintRailState
{
    Idle,
    Moving
}

public class PrintRailController : MonoBehaviour
{
    public float RailYMin;
    public float RailYMax;

    public float IdlePosition;

    public float Delta;

    public float Target;
    
    // Start is called before the first frame update
    void Start()
    {
       //StartCoroutine(MoveTo(RailYMin));
    }

    public void MoveToStartingPosition()
    {
        StopAllCoroutines();
        StartCoroutine(MoveTo(RailYMin));
    }

    public void MoveToIdlePosition()
    {
        StopAllCoroutines();
        StartCoroutine(MoveTo(IdlePosition));
    }

    public void SlowlyMoveToIdlePosition()
    {

    }
    //void MoveRailTo()


    public IEnumerator MoveTo(float yPos)
    {
        var delta = yPos > transform.localPosition.y ? Delta : -Delta;

        var targetVector = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);

        while (true)
        {
            var dinstance = Vector3.Distance(transform.localPosition, targetVector);
          //  Debug.Log(dinstance);
            if(Vector3.Distance(transform.localPosition, targetVector) > Delta)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + delta, transform.localPosition.z);
            } else
            {
                StopAllCoroutines();
                yield break;
            }

            yield return new WaitForSeconds(0.01f);
        }
    }

    //IEnumerator Move(float position)
    //{
    //    //while (true)
    //    //{
    //    //    if(transform.localPosition.y )
    //    //    yield break;
    //    //}
    //}

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.PageDown))
        //{
        //    if(transform.position.y - Delta >= RailYMin)
        //    {
        //        transform.position = new Vector3(transform.position.x, transform.position.y - Delta, transform.position.z);
        //    }
        //}

        //if (Input.GetKey(KeyCode.PageUp))
        //{
        //    if (transform.position.y + Delta < RailYMax)
        //    {
        //        transform.position = new Vector3(transform.position.x, transform.position.y + Delta, transform.position.z);
        //    }
        //}
    }
}
