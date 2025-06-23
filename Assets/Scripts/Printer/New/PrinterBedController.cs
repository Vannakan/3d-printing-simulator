using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PrinterBedState { Idle, Moving } // make this generic PrinterState and maybe these all read from the core controller?
public class PrinterBedController : MonoBehaviour
{
    public float MinX;
    public float MaxX;
    public float Delta;
    public Direction Direction;
    public PrinterBedState State;
    public float IdleX = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public IEnumerator ReturnToIdle()
    {
        var start = transform.localPosition;
        var end = new Vector3(IdleX, transform.localPosition.y, transform.localPosition.z);
        while (true)
        {
  
            if (Vector3.Distance(transform.localPosition, end) > Delta)
            {
               // Debug.Log(Vector3.Distance(transform.localPosition, end));
                transform.localPosition = Vector3.Lerp(start, end, Time.time * 0.2f);
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                yield break;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (State == PrinterBedState.Idle) return;


        if (Direction == Direction.Left)
        {
            if (transform.localPosition.x - Delta >= MinX)
            {
                transform.localPosition = new Vector3(transform.localPosition.x - Delta, transform.localPosition.y, transform.localPosition.z);
            }
            else
            {
                Direction = Direction.Right;
            }
        }
        else
        {
            if (transform.localPosition.x + Delta < MaxX)
            {
                transform.localPosition = new Vector3(transform.localPosition.x + Delta, transform.localPosition.y, transform.localPosition.z );
            }
            else
            {
                Direction = Direction.Left;
            }
        }
    }
}
