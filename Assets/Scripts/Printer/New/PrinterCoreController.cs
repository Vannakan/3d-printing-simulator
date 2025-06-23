using PrinterBehaviour;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Should maybe be called PrinterAnimationController or something?
public class PrinterCoreController : MonoBehaviour
{
    public PrinterBedController Bed;
    public PrintRailController Rail; // c
    public PrintHeadController Head;
    public PrintBehaviour Printer;

    // Start is called before the first frame update
    void Start()
    {
        Printer.PrintStateChanged += OnPrintStateChanged;
        
    }

    public void OnPrintStateChanged(object source, PrintState state)
    {
        switch (state)
        {
            case global::PrinterBehaviour.PrintState.Idle:
                Rail.MoveToIdlePosition();

                Bed.StartCoroutine(Bed.ReturnToIdle());
                Bed.State = PrinterBedState.Idle;

                Head.State = PrintHeadState.Idle;
                Head.StartCoroutine(Head.ReturnToIdle());

                break;
            case PrintState.Printing:
                Rail.MoveToStartingPosition();

                Bed.State = PrinterBedState.Moving;

                Head.State = PrintHeadState.Moving;

                break;
            default:
                Rail.MoveToIdlePosition();

                Bed.StartCoroutine(Bed.ReturnToIdle());
                Bed.State = PrinterBedState.Idle;

                Head.State = PrintHeadState.Idle;
                Head.StartCoroutine(Head.ReturnToIdle());

                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator StartPrintAnimation()
    {
        yield return null;
    }
}
