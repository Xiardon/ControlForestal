using System;
using System.Collections.Generic;
using System.Text;

namespace ControlForestal
{
    /// <summary>
    /// Representa un dron para ser programado mediante unas coordenadas X Y ademas de su orientacion.
    /// </summary>
    public class Dron
    {
        private Dictionary<string, int> Coordenadas { get; set; }
        private char Orientacion { get; set; } 
        private Dictionary<string, int> AreaPatrulla { get; set; }
        private List<string> Ordenes { get; set; }

        public Dron(Dictionary<string, int> coordenadasInicio, char orientacion, List<string> ordenes, Dictionary<string, int> areaPatrulla)
        {
            Coordenadas = coordenadasInicio;
            Orientacion = orientacion;
            AreaPatrulla = areaPatrulla;
            Ordenes = ordenes;
        }

        public void IniciarPatrulla()
        {

        }
    }
}
