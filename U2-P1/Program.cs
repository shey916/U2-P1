using System;

namespace PracticaRecursividad
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;

            do
            {
                // --- DIBUJO DEL MENÚ ---
                Console.Clear(); // Limpia la pantalla para que se vea ordenado
                Console.WriteLine("========================================");
                Console.WriteLine("   PROGRAMA 1: ALGORITMOS RECURSIVOS");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Calcular Factorial (n!)");
                Console.WriteLine("2. Sumatoria de Números Naturales (1..n)");
                Console.WriteLine("3. Calcular Potencia (base ^ exponente)");
                Console.WriteLine("4. Salir");
                Console.WriteLine("========================================");
                Console.Write("Selecciona una opción: ");

                // Lectura de la opción
                string entrada = Console.ReadLine();

                // Validación básica de entrada
                if (!int.TryParse(entrada, out opcion))
                {
                    opcion = 0; // Si no es número, forzamos opción inválida
                }

                Console.WriteLine(); // Salto de línea estético

                // --- LÓGICA DE SELECCIÓN ---
                switch (opcion)
                {
                    case 1:
                        EjecutarCasoFactorial();
                        break;
                    case 2:
                        EjecutarCasoSuma();
                        break;
                    case 3:
                        EjecutarCasoPotencia();
                        break;
                    case 4:
                        Console.WriteLine("Finalizando el programa. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor intenta de nuevo.");
                        break;
                }

                // Pausa antes de limpiar pantalla (excepto si sale)
                if (opcion != 4)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                }

            } while (opcion != 4);
        }

        static void EjecutarCasoFactorial()
        {
            Console.Write("Ingresa un número entero positivo para calcular su factorial: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
            {
                long resultado = FactorialRecursivo(n);
                Console.WriteLine($"\nEl Factorial de {n} es: {resultado}");
            }
            else
            {
                Console.WriteLine("Error: Debes ingresar un número entero positivo.");
            }
        }

        static void EjecutarCasoSuma()
        {
            Console.Write("Ingresa un número (n) para sumar desde n hasta 1: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
            {
                int resultado = SumaRecursiva(n);
                Console.WriteLine($"\nLa sumatoria de 1 hasta {n} es: {resultado}");
            }
            else
            {
                Console.WriteLine("Error: Debes ingresar un número entero positivo.");
            }
        }

        static void EjecutarCasoPotencia()
        {
            Console.Write("Ingresa la base: ");
            bool baseOk = int.TryParse(Console.ReadLine(), out int baseNum);

            Console.Write("Ingresa el exponente (positivo): ");
            bool expOk = int.TryParse(Console.ReadLine(), out int exp);

            if (baseOk && expOk && exp >= 0)
            {
                long resultado = PotenciaRecursiva(baseNum, exp);
                Console.WriteLine($"\n{baseNum} elevado a la {exp} es: {resultado}");
            }
            else
            {
                Console.WriteLine("Error: Revisa que los números sean enteros y el exponente positivo.");
            }
        }

        // ---------------------------------------------------------
        // LÓGICA RECURSIVA PURA (LOS ALGORITMOS)
        // ---------------------------------------------------------

        // 1. FACTORIAL
        static long FactorialRecursivo(int n)
        {
            // Condición de Salida
            if (n == 0 || n == 1) return 1;
            // Segmento Recursivo
            return n * FactorialRecursivo(n - 1);
        }

        // 2. SUMATORIA
        static int SumaRecursiva(int n)
        {
            // Condición de Salida
            if (n == 0) return 0;
            // Segmento Recursivo
            return n + SumaRecursiva(n - 1);
        }

        // 3. POTENCIA
        static long PotenciaRecursiva(int baseNum, int exp)
        {
            // Condición de Salida
            if (exp == 0) return 1;
            // Segmento Recursivo
            return baseNum * PotenciaRecursiva(baseNum, exp - 1);
        }
    }
}