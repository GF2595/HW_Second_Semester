using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_3
{
    public class Array
    {
        private int length;
        private int[] array;

        /// <summary>
        /// Array constructor
        /// </summary>
        /// <param name="size">Size of array to be constructed</param>
        public Array(int size)
        {
            length = size;
            array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = 0;
            }
        }

        /// <summary>
        /// Places element on specified position
        /// </summary>
        /// <param name="element">Element to be placed</param>
        /// <param name="position">Position, on which element will be placed</param>
        public void PlaceElement(int element, int position)
        {
            if ((position < this.length) && (position >= 0))
            {
                this.array[position] = element;
            }
        }

        /// <summary>
        /// Returns element on specified position of array
        /// </summary>
        /// <param name="position">Position to be checked</param>
        /// <returns>Element on specified position</returns>
        public int CheckElement(int position)
        {
            if ((position < this.length) && (position >= 0))
            {
                return this.array[position];
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Sorts array using "bubble" method
        /// </summary>
        public void BubbleSort()
        {
            for (int i = 0; i < this.length; i++)
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

        /// <summary>
        /// Prints array
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < this.length; i++)
            {
                Console.Write("{0} ", this.array[i]);
            }

            Console.WriteLine();
        }
    }
}
