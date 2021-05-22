using System;

namespace ControlForestal
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlDrones montserrat = new ControlDrones("Montserrat");
            montserrat.Iniciar();
        }
    }
}
