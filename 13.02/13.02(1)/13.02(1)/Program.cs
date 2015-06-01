using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_1
{   
    public class Program
    {
        /// <summary>
        /// Calculates factorial of specified number
        /// </summary>
        /// <param name="number">Number, for which factorial will be calculated</param>
        /// <returns>Result</returns>
        public static int Factorial(int number)
        {
            int result = 1;

            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

        static void Main(string[] args)
        {            
            Console.WriteLine("Введите число, для которого требуется взять факториал");
            int number = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Результат равен {0}", Factorial(number));
        }
    }
}
