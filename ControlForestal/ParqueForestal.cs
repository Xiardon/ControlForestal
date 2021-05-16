using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlForestal
{
    /// <summary>
    /// Representa un parque forestal sobre el que se define un area a vigilar asi como los drones que se programan para ejecutar la vigilancia.
    /// </summary>
    public class ParqueForestal
    {
        /// <summary>
        /// Anchura del area a vigilar.
        /// </summary>
        private int LongitudX { get; set; }
        /// <summary>
        /// Altura del area a vigilar.
        /// </summary>
        private int LongitudY { get; set; }

        private string Nombre { get; set; }
        public ParqueForestal(string nombreParque)
        {
            Nombre = nombreParque;
        }

        /// <summary>
        /// Inicia el programa de control de drones.
        /// </summary>
        public void Iniciar()
        {
            Console.WriteLine($"Bienvenido al programa de control de drones del parque forestal {Nombre}");
            DefinirArea();
        }

        /// <summary>
        /// Define el area sobre el que los drones patrullaran.
        /// </summary>
        private void DefinirArea()
        {
            Console.WriteLine("Introduzca el anchura y la altura del area a controlar (use espacios entre los numeros para separar las propiedades)");

            string imput = Console.ReadLine();

            /// Comprobamos que el los valores introducidos sean correctos, si no lo son reiniciamos la peticion de los mismos.
            if (!string.IsNullOrEmpty(imput))
            {
                List<string> area = imput.Split(' ').ToList();

               if(area.Count() == 2)
                {
                    int areaX = 0, areaY = 0;
                    bool esNumeroX = int.TryParse(area[0], out areaX);
                    bool esNumeroY = int.TryParse(area[1], out areaY);

                    if(esNumeroX && esNumeroY && areaX > 0 && areaY > 0)
                    {
                        LongitudX = areaX;
                        LongitudY = areaY;
                    }
                    else
                    {
                        Console.WriteLine("ERROR Introduzca valores correctos, solo se permiten dos numeros enteros mayores que 0");
                        DefinirArea();
                    }
                }
                else
                {
                    Console.WriteLine("ERROR Los valores introducidos tienen que ser dos");
                    DefinirArea();
                }
            }

            Console.WriteLine("Exito");
            DefinirArea();

        }

    }
}
