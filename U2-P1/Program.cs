using System;

namespace PracticeR
{
    class Program
    {
        static void Main(string[] args)
        {
            int op = 0;

            do
            {
                // --- DIBUJO DEL MENÚ ---
                Console.Clear(); // Limpia la pantalla para que se vea ordenado
                Console.WriteLine("========================================");
                Console.WriteLine("   PROGRAM 1: RECURSIVE ALGORITHMS");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Calculate Factorial (n!)");
                Console.WriteLine("2. Summation of Natural Numbers (1..n)");
                Console.WriteLine("3. Calculate Power (base ^ exponent)");
                Console.WriteLine("4. Exit");
                Console.WriteLine("========================================");
                Console.Write("Select an option: ");

                // Read option
                string input = Console.ReadLine();

                // Basic input validation
                if (!int.TryParse(input, out op))
                {
                    op = 0; 
                }

                Console.WriteLine(); 

                // --- SELECTION LOGIC ---
                switch (op)
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
                        Console.WriteLine("Ending program.");
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

                if (op != 4)
                {
                    Console.WriteLine("\nPress any key to return to the menu..");
                    Console.ReadKey();
                }

            } while (op != 4);
        }

        static void EjecutarCasoFactorial()
        {
            Console.Write("Enter a positive integer to calculate its factorial: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
            {
                long result = FactorialRecursivo(n);
                Console.WriteLine($"\nThe factorial {n} is: {result}");
            }
            else
            {
                Console.WriteLine("Error: Only positive number");
            }
        }

        static void EjecutarCasoSuma()
        {
            Console.Write("Enter a number (n) to sum from n down to 1:");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
            {
                int result = SumaRecursiva(n);
                Console.WriteLine($"\nThe summation from 1 to {n} is: {result}");
            }
            else
            {
                Console.WriteLine("Error: You must enter a positive integer.");
            }
        }

        static void EjecutarCasoPotencia()
        {
            Console.Write("Enter the base: ");
            bool baseOk = int.TryParse(Console.ReadLine(), out int baseNum);

            Console.Write("Enter the exponent (positive): ");
            bool expOk = int.TryParse(Console.ReadLine(), out int exp);

            if (baseOk && expOk && exp >= 0)
            {
                long result = PotenciaRecursiva(baseNum, exp);
                Console.WriteLine($"\n{baseNum}raised to the power of {exp} is: {result}");
            }
            else
            {
                Console.WriteLine("Error: Check that the numbers are integers and the exponent is positive.");
            }
        }

        // ---------------------------------------------------------
        // PURE RECURSIVE LOGIC (THE ALGORITHMS)
        // ---------------------------------------------------------

        // 1. FACTORIAL
        static long FactorialRecursivo(int n)
        {
            // Base Case - Exit condition
            if (n == 0 || n == 1) return 1;
            // Recursive Step
            return n * FactorialRecursivo(n - 1);
        }

        // 2. SUMMATION
        static int SumaRecursiva(int n)
        {
            // Base Case - Exit condition
            if (n == 0) return 0;
            // Recursive Step
            return n + SumaRecursiva(n - 1);
        }

        // 3. POWER
        static long PotenciaRecursiva(int baseNum, int exp)
        {
            // Base Case - Exit condition
            if (exp == 0) return 1;
            // Recursive Step
            return baseNum * PotenciaRecursiva(baseNum, exp - 1);
        }
    }
}