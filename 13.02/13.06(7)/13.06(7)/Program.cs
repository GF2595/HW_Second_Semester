using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину столбца");
            int sizeColumn = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите длину строки");
            int sizeRow = Convert.ToInt32(Console.ReadLine());

            Array array = new Array(sizeRow, sizeColumn);

            array.RandomFill();
            array.Print();

            array.BubbleSort();
            array.Print();
        }
    }
}
