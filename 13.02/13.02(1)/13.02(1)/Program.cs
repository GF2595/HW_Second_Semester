using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_1
{   
    class Program
    {
        static int factorial(int number)
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
            Console.WriteLine("Введите число, для которого требуется взять фаткориал");
            int number = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Результат равен {0}", factorial(number));
        }
    }
}
