using UnityEngine;

public enum PrinterScreenState { Home }
public class PrinterScreen : MonoBehaviour
{
    public PrinterScreenState State;

    // Start is called before the first frame update
    void Start()
    {
        State = PrinterScreenState.Home;       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
