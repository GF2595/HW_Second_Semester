using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_6
{
    class Array
    {
        private int length;
        private int[,] array;

        public Array(int size)
        {
            length = size;
            array = new int[length, length];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                array[i, j] = 0;
                }
            }
        }

        public void RandomFill()
        {
            Random generator = new Random();

            for (int i = 0; i < this.length; i++)
            {
                for (int j = 0; j < this.length; j++)
                {
                    this.array[i, j] = generator.Next(-20, 20);
                }
            }
        }

        public void PlaceElement(int element, int row, int column)
        {
            if ((row < this.length) && (column < this.length))
            {
                this.array[row, column] = element;
            }
        }

        public void Print()
        {
            for (int i = 0; i < this.length; i++)
            {
                for (int j = 0; j < this.length; j++)
                {
                    Console.Write("{0} ", this.array[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void SpiralPrint()
        {
            int ni = this.length;
            int i = 0;
            int j = 0;
            int nj = this.length;
            int n0i = 0;
            int n0j = 1;

            do
            {
                for (int counter = i; i < ni - 1; i++)
                {
                    Console.Write("{0} ", this.array[i, j]);
                }
                for (int counter = j; j < nj - 1; j++)
                {
                    Console.Write("{0} ", this.array[i, j]);
                }
                for (int counter = i; i > n0i; i--)
                {
                    Console.Write("{0} ", this.array[i, j]);
                }
                for (int counter = j; j > n0j; j--)
                {
                    Console.Write("{0} ", this.array[i, j]);
                }

                ni--;
                nj--;
                n0i++;
                n0j++;
            } while (ni > 0);

            Console.WriteLine("{0} ", this.array[this.length / 2, this.length / 2]);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива");
            int size = Convert.ToInt32(Console.ReadLine());

            Array array = new Array(size);
            array.RandomFill();
            array.Print();

            array.SpiralPrint();
        }
    }
}
