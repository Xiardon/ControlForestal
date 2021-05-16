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
            Console.WriteLine("Introduzca el anchura y la altura del area a controlar(Ej: 5 6 y tienen que ser valores mayores que 0) y pulse intro, despues introduca la posicion " +
                "inicial de los drones y su orientacion(Ej: 2 4 N)  vuelva a pulsar intro(use espacios para separar los datos) e introduzca la secuencia de ordenes que debera " +
                "realizar el dron segudias(Ej: LRM). Para dar la orden a los drones de que inicien la patrulla pulse intro sin introducir ningun dato despues de haber programado " +
                "al menos un dron");

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
                        Console.WriteLine("ERROR en el area. Introduzca valores correctos, solo se permiten dos numeros enteros mayores que 0");
                        DefinirArea();
                    }
                }
                else
                {
                    Console.WriteLine("ERROR en el area. Los valores introducidos tienen que ser dos");
                    DefinirArea();
                }
            }

            
            AñadirDron();

        }

        /// <summary>
        /// Añade un dron al programa de patrulla aerea
        /// </summary>
        private void AñadirDron()
        {
            Console.WriteLine("Especifique las coordenadas X e Y asi como la orientacion incial del dron en el area ");

            string imput = Console.ReadLine();
            List<string> posicionInicial = imput.Split(' ').ToList();

            int Xinicial = 0;
            int Yinicial = 0;
            char orientacionInicial = ' ';
            char[] puntosCardinales = { 'N', 'S', 'E', 'O' };

            ///Comprobamos que los datos introducidos para indicar la posicion inicial del dron son validos
            if (posicionInicial.Count() == 3 && int.TryParse(posicionInicial[0], out Xinicial) && int.TryParse(posicionInicial[1], out Yinicial)
                && char.TryParse(posicionInicial[2], out orientacionInicial) && posicionInicial[2].ToUpper().IndexOfAny(puntosCardinales) != -1)
            {
                if(!(Xinicial < LongitudX || Xinicial > LongitudX ) && !(Yinicial < LongitudY || Yinicial > LongitudY))
                {
                    Dron dron = new Dron(Xinicial, Yinicial, orientacionInicial);
                }
            }
            else
            {
                Console.WriteLine("ERROR Coordenadas de incio erroneas");
                AñadirDron();
            }

            Console.WriteLine("Exito");
            AñadirDron();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ProgramarAccionesDron()
        {

        }

    }
}
