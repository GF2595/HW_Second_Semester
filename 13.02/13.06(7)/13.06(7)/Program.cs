using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_7
{
    /// <summary>
    /// This class represents two-dimensional array 
    /// </summary>
    class Array
    {
        /// <summary>
        /// Store for the array width and length and array itself.
        /// </summary>
        private int lengthRow;
        private int lengthColumn;
        private int[,] array;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="sizeRow">Array row size</param>
        /// <param name="sizeColumn">Array column size</param>
        public Array(int sizeRow, int sizeColumn)
        {
            lengthRow = sizeRow;
            lengthColumn = sizeColumn;

            array = new int[lengthColumn, lengthRow];

            for (int i = 0; i < lengthColumn; i++)
            {
                for (int j = 0; j < lengthRow; j++)
                {
                    array[i, j] = 0;
                }
            }
        }

        /// <summary>
        /// Fills array with random numbers from -20..20 interval
        /// </summary>
        public void RandomFill()
        {
            Random generator = new Random();

            for (int i = 0; i < this.lengthColumn; i++)
            {
                for (int j = 0; j < this.lengthRow; j++)
                {
                    this.array[i, j] = generator.Next(-20, 20);
                }
            }
        }

        /// <summary>
        /// Places element on specified place in array
        /// </summary>
        /// <param name="element">Element to be placed</param>
        /// <param name="row">Number of row in which element should be placed</param>
        /// <param name="column">Number of column in which element should be placed</param>
        public void PlaceElement(int element, int row, int column)
        {
            if ((row < this.lengthColumn) && (column < this.lengthRow))
            {
                this.array[row, column] = element;
            }
        }

        /// <summary>
        /// Prints whole array as table
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < this.lengthColumn; i++)
            {
                for (int j = 0; j < this.lengthRow; j++)
                {
                    Console.Write("{0} ", this.array[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        internal void SwapColumns(int firstColumn, int secondColumn)
        {
            for (int i = 0; i < this.lengthColumn; i++)
            {
                int temp = this.array[i, firstColumn];
                this.array[i, firstColumn] = this.array[i, secondColumn];
                this.array[i, secondColumn] = temp;
            }
        }

        /// <summary>
        /// Sorts array columns by their first element using bubble sort
        /// </summary>
        public void BubbleSort()
        {
            for (int i = 0; i < this.lengthRow - 1; i++)
            {
                for (int j = 0; j < this.lengthRow - i - 1; j++)
                {
                    if (this.array[0, j] > this.array[0, j + 1])
                    {
                        this.SwapColumns(j, j + 1);
                    }
                }
            }
        }
    }

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
