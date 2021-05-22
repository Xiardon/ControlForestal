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
        /// <summary>
        /// Posicion del dron.
        /// </summary>
        private Dictionary<string, int> Coordenadas { get; set; }

        /// <summary>
        /// Rumbo del dron.
        /// </summary>
        private char Orientacion { get; set; } 

        /// <summary>
        /// Anchura y altura sobre el area que el dron va a patrullar.
        /// </summary>
        private Dictionary<string, int> AreaPatrulla { get; set; }

        /// <summary>
        /// Ruta de patrulla del dron.
        /// </summary>
        private List<string> Ordenes { get; set; }

        public Dron(Dictionary<string, int> coordenadasInicio, char orientacion, List<string> ordenes, Dictionary<string, int> areaPatrulla)
        {
            Coordenadas = coordenadasInicio;
            Orientacion = orientacion;
            AreaPatrulla = areaPatrulla;
            Ordenes = ordenes;
        }

        /// <summary>
        /// Inicia la ejecucion de las ordenes de patrulla sobre el area.
        /// Una vez finalizadas todas las ordenes devuelve la posicion del dron.
        /// </summary>
        public void IniciarPatrulla()
        {
            foreach (string orden in Ordenes)
            {
                if (orden.Equals("M"))
                {
                    Avanzar();
                }
                else if (orden.Equals("R")) 
                {
                    GirarDerecha();
                }
                else
                {
                    GirarIzquierda();
                }
            }

            Console.WriteLine($"{Coordenadas["X"]} {Coordenadas["Y"]} {Orientacion}");
        }

        /// <summary>
        /// Hace anzar el dron en el eje XY en funcion de su orientacion.
        /// </summary>
        private void Avanzar()
        {
            if (Orientacion.Equals('N')) ///Norte
            {
                if (Coordenadas["Y"] < AreaPatrulla["Y"])
                    Coordenadas["Y"]++;
            }
            else if (Orientacion.Equals('S')) ///Sur
            {
                if (Coordenadas["Y"] > 0)
                    Coordenadas["Y"]--;
            }
            else if (Orientacion.Equals('E')) ///Este
            {
                if (Coordenadas["X"] < AreaPatrulla["X"])
                    Coordenadas["X"]++;
            }
            else
            {
                if (Coordenadas["X"] > 0) ///Oeste
                    Coordenadas["X"] --;
            }
        
        }

        /// <summary>
        /// Gira la orientacion del dron 90º hacia la derecha.
        /// </summary>
        private void GirarDerecha()
        {
            switch (Orientacion)
            {
                case 'N':
                    Orientacion = 'E';
                    break;

                case 'S':
                    Orientacion = 'O';
                    break;

                case 'E':
                    Orientacion = 'S';
                    break;

                case 'O':
                    Orientacion = 'N';
                    break;
            }
        }

        /// <summary>
        /// Gira la orientacion del dron 90º hacia la izquierda.
        /// </summary>
        private void GirarIzquierda()
        {
            switch (Orientacion)
            {
                case 'N':
                    Orientacion = 'O';
                    break;

                case 'S':
                    Orientacion = 'E';
                    break;

                case 'E':
                    Orientacion = 'N';
                    break;

                case 'O':
                    Orientacion = 'S';
                    break;
            }
        }
    
    }
}
