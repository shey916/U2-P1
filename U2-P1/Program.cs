using System;

namespace PracticeR
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;

            do
            {
                // --- MENU DISPLAY ---
                Console.Clear(); // Clears the screen to keep it organized
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
                if (!int.TryParse(input, out option))
                {
                    option = 0;
                }

                Console.WriteLine();

                // --- SELECTION LOGIC ---
                switch (option)
                {
                    case 1:
                        ExecuteFactorialCase();
                        break;
                    case 2:
                        ExecuteSumCase();
                        break;
                    case 3:
                        ExecutePowerCase();
                        break;
                    case 4:
                        Console.WriteLine("Ending program.");
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

                if (option != 4)
                {
                    Console.WriteLine("\nPress any key to return to the menu..");
                    Console.ReadKey();
                }

            } while (option != 4);
        }

        static void ExecuteFactorialCase()
        {
            Console.Write("Enter a positive integer to calculate its factorial: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
            {
                long result = RecursiveFactorial(n);
                Console.WriteLine($"\nThe factorial of {n} is: {result}");
            }
            else
            {
                Console.WriteLine("Error: Only positive numbers allowed.");
            }
        }

        static void ExecuteSumCase()
        {
            Console.Write("Enter a number (n) to sum from n down to 1: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
            {
                int result = RecursiveSum(n);
                Console.WriteLine($"\nThe summation from 1 to {n} is: {result}");
            }
            else
            {
                Console.WriteLine("Error: You must enter a positive integer.");
            }
        }

        static void ExecutePowerCase()
        {
            Console.Write("Enter the base: ");
            bool baseOk = int.TryParse(Console.ReadLine(), out int baseNum);

            Console.Write("Enter the exponent (positive): ");
            bool expOk = int.TryParse(Console.ReadLine(), out int exp);

            if (baseOk && expOk && exp >= 0)
            {
                long result = RecursivePower(baseNum, exp);
                Console.WriteLine($"\n{baseNum} raised to the power of {exp} is: {result}");
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
        static long RecursiveFactorial(int n)
        {
            // Base Case - Exit condition
            if (n == 0 || n == 1) return 1;
            // Recursive Step
            return n * RecursiveFactorial(n - 1);
        }

        // 2. SUMMATION
        static int RecursiveSum(int n)
        {
            // Base Case - Exit condition
            if (n == 0) return 0;
            // Recursive Step
            return n + RecursiveSum(n - 1);
        }

        // 3. POWER
        static long RecursivePower(int baseNum, int exp)
        {
            // Base Case - Exit condition
            if (exp == 0) return 1;
            // Recursive Step
            return baseNum * RecursivePower(baseNum, exp - 1);
        }
    }
}