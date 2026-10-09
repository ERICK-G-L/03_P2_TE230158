using System;

namespace Ejercicio3_TemperaturaMotor
{
    /// <summary>
    /// Clase encargada del registro y evaluación térmica de un motor.
    /// </summary>
    public class MonitoreoTemperatura
    {
        // PROPIEDAD: Arreglo para almacenar las mediciones de temperatura en °C
        public double[] Lecturas { get; set; }

        /// <summary>
        /// Constructor que inicializa el objeto con el arreglo de mediciones.
        /// </summary>
        public MonitoreoTemperatura(double[] lecturas)
        {
            Lecturas = lecturas;
        }

        /// <summary>
        /// Método para calcular el promedio. Incluye validación contra división por cero.
        /// </summary>
        /// <returns>Promedio en grados Celsius (°C)</returns>
        public double CalcularPromedio()
        {
            // Prevención estricta contra división entre cero si el arreglo estuviese vacío
            if (Lecturas == null || Lecturas.Length == 0)
            {
                return 0.0;
            }

            double suma = 0;
            for (int i = 0; i < Lecturas.Length; i++)
            {
                suma += Lecturas[i];
            }

            return suma / Lecturas.Length;
        }

        /// <summary>
        /// Método que determina si la temperatura es NORMAL (<= 70 °C) o ALERTA DE TEMPERATURA (> 70 °C).
        /// </summary>
        public string ObtenerEstado()
        {
            double promedio = CalcularPromedio();
            if (promedio <= 70.0)
            {
                return "NORMAL";
            }
            else
            {
                return "ALERTA DE TEMPERATURA";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("  EJERCICIO 3: MONITOREO DE TEMPERATURA DE MOTOR");
            Console.WriteLine("====================================================\n");

            double[] temperaturas = new double[5];

            // Lectura de 5 mediciones utilizando un ciclo for conforme a las instrucciones
            for (int i = 0; i < temperaturas.Length; i++)
            {
                Console.Write($"Ingrese la lectura de temperatura #{i + 1} (°C): ");
                while (!double.TryParse(Console.ReadLine(), out temperaturas[i]))
                {
                    Console.Write($"Entrada no válida. Ingrese un valor numérico para la lectura #{i + 1} (°C): ");
                }
            }

            // CREACIÓN DEL OBJETO
            MonitoreoTemperatura prueba = new MonitoreoTemperatura(temperaturas);

            double promedioCalculado = prueba.CalcularPromedio();
            string estadoFinal = prueba.ObtenerEstado();

            // Salida de datos indicando unidades de temperatura en °C
            Console.WriteLine("\n---------------- RESULTADOS ----------------");
            Console.WriteLine($"Lecturas registradas:  {string.Join(" °C, ", prueba.Lecturas)} °C");
            Console.WriteLine($"Temperatura Promedio: {promedioCalculado:F2} °C");
            Console.WriteLine($"Estado del Motor:     {estadoFinal}");
            Console.WriteLine("--------------------------------------------");
        }
    }
}