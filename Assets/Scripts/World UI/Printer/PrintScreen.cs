using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.World_UI.Printer
{
    public class PrintScreen : PrinterMenuScreen
    {
        public void StartPrint()
        {
            Printer.Toggle();
        }

        public void CancelPrint()
        {

        }
    }
}
