using System;
using System.Collections;
using UnityEngine;

public enum Direction
{
    Left, Right
}

public enum PrintHeadState { Idle, Moving }
public class PrintHeadController : MonoBehaviour
{

    public float RailYMin;
    public float RailYMax;

    public float Delta;

    public Direction Direction;
    public PrintHeadState State;

    public float IdleY;

    // Start is called before the first frame update
    void Start()
    {
        Direction = Direction.Left;    
    }


    public IEnumerator ReturnToIdle()
    {
        //var start = transform.localPosition;
        //var end = new Vector3(IdleZ, transform.localPosition.y, transform.localPosition.z);
        //while (true)
        //{
        //    if (Vector3.Distance(transform.localPosition, end) > Delta)
        //    {
        //        transform.localPosition = Vector3.Lerp(start, end, Delta);
        //        yield return new WaitForSeconds(0.01f);
        //    }
        //    else
        //    {
               yield break;
        //    }

        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (State == PrintHeadState.Idle) return;

        if(Direction == Direction.Right)
        {
            if (transform.localPosition.y - Delta >= RailYMin)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - Delta, transform.localPosition.z );
            } else
            {
                Direction = Direction.Left;
            }
        }else
        {
            if (transform.localPosition.y + Delta < RailYMax)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + Delta, transform.localPosition.z );
            }
            else
            {
                Direction = Direction.Right;
            }
        }
    }
}
