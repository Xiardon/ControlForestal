using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlForestal
{
    /// <summary>
    /// Representa el contol de drones sobre el que se define el area a vigilar asi como los drones que se programan para ejecutar la ruta
    /// de vigilancia especificada..
    /// </summary>
    public class ControlDrones
    {
        /// <summary>
        /// Anchura del area a vigilar.
        /// </summary>
        private int LongitudAreaX { get; set; }

        /// <summary>
        /// Altura del area a vigilar.
        /// </summary>
        private int LongitudAreaY { get; set; }

        /// <summary>
        /// Nombre del parque sobre el que se implementara el area a vigilar.
        /// </summary>
        private string NombreParque { get; set; }

        /// <summary>
        /// Coleccion de drones en el area de patrulla.
        /// </summary>
        private List<Dron> Drones { get; set; }

        public ControlDrones(string nombreParque)
        {
            NombreParque = nombreParque;
            LongitudAreaX = 0;
            LongitudAreaY = 0;
            Drones = new List<Dron>();
        }

        /// <summary>
        /// Inicia el programa de control de drones.
        /// </summary>
        public void Iniciar()
        {
            Console.WriteLine($"Bienvenido al programa de control de drones del parque forestal {NombreParque} \n");
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
            List<string> area = Console.ReadLine().Split(' ').ToList();
            int areaX = 0, areaY = 0;

            /// Comprobamos que el los valores introducidos sean correctos, si no lo son reiniciamos la peticion de los mismos.
            bool esNumero = area.Count() == 2 && int.TryParse(area[0], out areaX) && int.TryParse(area[1], out areaY);

            if (esNumero && areaX > 0 && areaY > 0)
            {
                LongitudAreaX = areaX;
                LongitudAreaY = areaY;
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
        /// Añande el dron a la coleccion de drones.
        /// </summary>
        private void AñadirDron()
        {
            int Xinicial = 0;
            int Yinicial = 0;
            char orientacionInicial = ' ';
            char[] puntosCardinales = { 'N', 'S', 'E', 'O' };

            List<string> posicionInicial = Console.ReadLine().ToUpper().Split(' ').ToList();

            ///Comprobamos que los datos introducidos para indicar la posicion inicial del dron son validos.
            bool datosValidos = posicionInicial.Count() == 3 && int.TryParse(posicionInicial[0], out Xinicial) && int.TryParse(posicionInicial[1], out Yinicial)
                && char.TryParse(posicionInicial[2], out orientacionInicial) && posicionInicial[2].ToUpper().IndexOfAny(puntosCardinales) != -1;

            if (datosValidos && (Xinicial <= LongitudAreaX || Xinicial >= LongitudAreaX) && (Yinicial <= LongitudAreaY || Yinicial >= LongitudAreaY))
            {
                Dictionary<string, int> coordenadas = new Dictionary<string, int>()
                {
                    { "X", Xinicial}, {"Y", Yinicial}
                };
                Dictionary<string, int> area = new Dictionary<string, int>()
                {
                    {"X", LongitudAreaX}, {"Y", LongitudAreaY}
                };

                Dron dron = new Dron(coordenadas, orientacionInicial, ProgramarRutaDron(), area);
                Drones.Add(dron);
            }
            else if (posicionInicial.Count() == 0 && Drones.Count() > 0)
            {
                ///TODO metodo para lanzar la ejecucion de ordenes de los drones.
            }
            else
            {
                Console.WriteLine("ERROR Coordenadas de incio erroneas");
                AñadirDron();
            }
        }

        /// <summary>
        /// Se solicita las ordenes de ruta para el dron y se validan que sean correctas.
        /// </summary>
        /// <returns> Una lista con las ordenes para el dron</returns>
        private List<string> ProgramarRutaDron()
        {
            char[] ordenesValidas = { 'L', 'R', 'M' };

            List<string> ordenes = Console.ReadLine().ToUpper().Split().ToList();

            if(ordenes.Count() <= 0 && !ordenes.All(x => x.IndexOfAny(ordenesValidas) != -1))
            {
                Console.WriteLine("ERROR en las ordenes de ruta del dron");
                ProgramarRutaDron();
            }

            return ordenes;

        }
    }
}