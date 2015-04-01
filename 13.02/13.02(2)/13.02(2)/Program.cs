using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_2
{
    class Program
    {
        static int fibonacci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            else
            {
                int previousNumber = 1;
                int earlyPreviousNumber = 0;
                int number = 1;

                for (int i = 2; i < n; i++)
                {
                    earlyPreviousNumber = previousNumber;
                    previousNumber = number;
                    number = earlyPreviousNumber + previousNumber;
                }

                return number;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер нужного числа Фибоначчи");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("{0}-ое число Фибоначчи - {1}", number, fibonacci(number));
        }
    }
}
