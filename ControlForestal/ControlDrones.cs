using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlForestal
{
    /// <summary>
    /// Representa el contol de drones sobre el que se define el area a vigilar asi como los drones que se programan para ejecutar la vigilancia.
    /// </summary>
    public class ControlDrones
    {
        /// <summary>
        /// Anchura del area a vigilar.
        /// </summary>
        private int LongitudX { get; set; }

        /// <summary>
        /// Altura del area a vigilar.
        /// </summary>
        private int LongitudY { get; set; }

        /// <summary>
        /// Nombre del parque sobre el que se implementara el area a vigilar.
        /// </summary>
        private string Nombre { get; set; }

        public ControlDrones(string nombreParque)
        {
            Nombre = nombreParque;
        }

        /// <summary>
        /// Inicia el programa de control de drones.
        /// </summary>
        public void Iniciar()
        {
            Console.WriteLine($"Bienvenido al programa de control de drones del parque forestal {Nombre} \n");
            Console.WriteLine("1-Introduzca el anchura y la altura del area a controlar(Ej: 5 6 y tienen que ser valores mayores que 0) y pulse intro \n");
            Console.WriteLine("2-Despues introduca la posicion inicial de los drones y su orientacion(Ej: 2 4 N) y vuelva a pulsar intro(use espacios para separar los datos) \n");
            Console.WriteLine("3-Introduzca la secuencia de ordenes que debera realizar el dron segudias(Ej: LRM). \n");
            Console.WriteLine("4-Para dar la orden a los drones de que inicien la patrulla pulse intro sin introducir ningun dato despues de haber programado al menos un dron \n");
            Console.WriteLine("Puede introducir tantos drones como desee siguiendo los pasos 2 y 3 de forma continuada");

            DefinirArea();
        }

        /// <summary>
        /// Define el area sobre el que los drones patrullaran y valida que sea correcta.
        /// </summary>
        private void DefinirArea()
        {
            string imput = Console.ReadLine();
            List<string> area = imput.Split(' ').ToList();
            int areaX = 0, areaY = 0;

            /// Comprobamos que el los valores introducidos sean correctos, si no lo son reiniciamos la peticion de los mismos.
            bool esNumero = area.Count() == 2 && int.TryParse(area[0], out areaX) && int.TryParse(area[1], out areaY);

            if (esNumero && areaX > 0 && areaY > 0)
            {
                LongitudX = areaX;
                LongitudY = areaY;
                AñadirDron();
            }
            else
            {
                Console.WriteLine("ERROR en el area. Introduzca valores correctos, solo se permiten dos numeros enteros mayores que 0");
                DefinirArea();
            }
        }

        /// <summary>
        /// Añade un dron al programa de patrulla aerea y comprueba que las coordenadas inciales sean correctas.
        /// Recibe por entrada de consola las coordenadas X e Y de inicio del dron y su orientacion.
        /// </summary>
        private void AñadirDron()
        {
            Console.WriteLine("Especifique las coordenadas X e Y asi como la orientacion incial del dron en el area");

            int Xinicial = 0;
            int Yinicial = 0;
            char orientacionInicial = ' ';
            char[] puntosCardinales = { 'N', 'S', 'E', 'O' };

            string imput = Console.ReadLine();
            List<string> posicionInicial = imput.Split(' ').ToList();

            ///Comprobamos que los datos introducidos para indicar la posicion inicial del dron son validos.
            bool datosValidos = posicionInicial.Count() == 3 && int.TryParse(posicionInicial[0], out Xinicial) && int.TryParse(posicionInicial[1], out Yinicial)
                && char.TryParse(posicionInicial[2], out orientacionInicial) && posicionInicial[2].ToUpper().IndexOfAny(puntosCardinales) != -1;

            if (datosValidos && !(Xinicial < LongitudX || Xinicial > LongitudX) && !(Yinicial < LongitudY || Yinicial > LongitudY))
            {
                Dron dron = new Dron(Xinicial, Yinicial, orientacionInicial);
                ProgramarRutaDron(dron);
            }
            else
            {
                Console.WriteLine("ERROR Coordenadas de incio erroneas");
                AñadirDron();
            }
        }

        /// <summary>
        ///
        /// </summary>
        private void ProgramarRutaDron(Dron dron)
        {
        }
    }
}