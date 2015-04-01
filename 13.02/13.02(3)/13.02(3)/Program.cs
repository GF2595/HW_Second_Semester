using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_2
{
    class Array
    {
        private int length;
        private int[] array;

        public Array(int size)
        {
            length = size;
            array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = 0;
            }
        }

        public void PlaceElement(int element, int position)
        {
            if (position < this.length)
            {
                this.array[position] = element;
            }
        }

        public void BubbleSort()
        {
            for (int i = 0; i < this.length - 1; i++)
            {
                for (int j = 0; j < this.length - i - 1; j++)
                {
                    if (this.array[j] > this.array[j + 1])
                    {
                        int temp = this.array[j];
                        this.array[j] = this.array[j + 1];
                        this.array[j + 1] = temp;
                    }
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < this.length; i++)
            {
                Console.Write("{0} ", this.array[i]);
            }

            Console.WriteLine();
        }
    }
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
