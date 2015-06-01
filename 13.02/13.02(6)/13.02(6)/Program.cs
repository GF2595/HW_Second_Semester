using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива");
            int size = Convert.ToInt32(Console.ReadLine());

            switch (size % 2)
            {
                case 0:
                    {
                        Console.WriteLine("Неверный размер массива");
                    }
                    break;
                case 1:
                    {
                        Array array = new Array(size);
                        array.RandomFill();
                        array.Print();

                        Console.WriteLine(array.SpiralPrint());
                    }
                    break;
            }
        }
    }
}
