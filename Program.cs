using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciApp
{
    // Вывести все числа Фибоначчи, которые удовлетворяют переданному в функцию ограничению:
    // находятся в указанном диапазоне, либо имеют указанную длину.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n" + " Fibonacci sequence: please, enter mode:" + "\n"
                                + " Fibonacci numbers in the range     --> Press key '1' " + "\n"
                                + " Fibonacci numbers have some length --> Press key '2'");
            string mode = Console.ReadLine();

            switch (mode)
            {
                case "1":
                     int min = enterMinRange();
                     if (min == -1) { break; };
                     int max = enterMaxRange();
                   
                    if (validateParams(min, max))
                    {
                        Console.WriteLine(" Sequence Fibonacci in range: " + calcSequenceFibonacciInRange(min, max));
                    }
                    else
                    {
                        Console.WriteLine(" Try again");
                    }
                    break;

                case "2":
                    int lengthNumberFibonacci = enterLengthOfNumbers();
                    
                    if (validateParams(lengthNumberFibonacci))
                    {
                        Console.WriteLine(" Sequence Fibonacci in one length : " + calcSequenceInLength(lengthNumberFibonacci));
                    }
                    else
                    {
                        Console.WriteLine(" Try again");
                    }
                    break;
                default:
                    Console.WriteLine(" Warning! Wrong mode! Please, enter 1 or 2, try again"); 
                    break;
            }            

            Console.WriteLine(" Press any key to exit... ");

            //  Sequence Fibonacci in range
            string calcSequenceFibonacciInRange(int minR, int maxR) {
                string sequence = "";
                int f1 = 0;
                int f2 = 1;
                while (f1 <= maxR)
                {
                    if (f1 >= minR)
                    {
                        sequence = String.Concat(sequence, f1) + ", "; 
                    }
                    int sum = f1 + f2;
                    f1 = f2;
                    f2 = sum;
                }
                return sequence;
            }

            //  Sequence Fibonacci in one length
            string calcSequenceInLength(int lengthNumberFibonacci)
            {
                string sequence = "";
                int f1 = 0;
                int f2 = 1;
                while (Convert.ToString(f1).Length <= lengthNumberFibonacci)
                {
                   int length = Convert.ToString(f1).Length;
                   if (length == lengthNumberFibonacci)
                   {
                        sequence = String.Concat(sequence, f1) + ", ";
                   }
                   int sum = f1 + f2;
                   f1 = f2;
                   f2 = sum;
                }
                return sequence;
            }
            Console.ReadKey();
        }

        private static int enterLengthOfNumbers()
        {
            try
            {
                Console.WriteLine(" Enter the length of the Fibonacci numbers from 1 to 9--> ");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(" " + ex.Message + "\n" + " Length must be an integer digit");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        private static int enterMaxRange()
        {
            try
            {
                Console.Write(" Enter Max Range for Fibonacci numbers--> ");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(" " + ex.Message + "\n" + " Range must be an integer digit");                
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        private static int enterMinRange()
        {
            try
            {
                Console.Write(" Enter Min Range for Fibonacci numbers--> ");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(" " + ex.Message + "\n" + " Range must be an integer digit");

            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;            
        }

        private static bool validateParams(int min, int max)
        {
            if ((min < max)||(min<0)||(max<0))
            {
                return true;
            }
            else
            {
                Console.WriteLine(" Warning! Max Range must be > Mix Range and All Range > = 0");
                return false;
            }
        }

        private static bool validateParams (int lengthNumberFibonacci)
        {
            if ((lengthNumberFibonacci >= 1) && (lengthNumberFibonacci<=9))
            {
                return true;
            }
            else
            {
                Console.WriteLine(" Warning! Length of the Fibonacci numbers must be 1=< lenght <= 9");
                return false;
            }
        }
    }
}
