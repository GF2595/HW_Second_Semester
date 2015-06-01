using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину массива");
            int size = Convert.ToInt32(Console.ReadLine());

            Array array = new Array(size);

            Random generator = new Random();

            for (int i = 0; i < size; i++)
            {
                array.PlaceElement(generator.Next(-20, 20), i);
            }

            array.Print();
            array.BubbleSort();
            array.Print();
        }
    }
}
