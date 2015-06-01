using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_6
{
    public class Array
    {
        private int length;
        private int[,] array;

        /// <summary>
        /// Array constructor
        /// </summary>
        /// <param name="size">Size of array to be constructed</param>
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

        /// <summary>
        /// Fills array with random numbers
        /// </summary>
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

        /// <summary>
        /// Places element on specified place in array
        /// </summary>
        /// <param name="element">Element to be placed</param>
        /// <param name="row">Element row</param>
        /// <param name="column">Element column</param>
        public void PlaceElement(int element, int row, int column)
        {
            if ((row < this.length) && (column < this.length))
            {
                this.array[row, column] = element;
            }
        }

        /// <summary>
        /// Prints array
        /// </summary>
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

        /// <summary>
        /// Prints array with spiral method
        /// </summary>
        public string SpiralPrint()
        {
            string output = "";
            int direction = 0;
            int wayToPass = 1;
            int currentI = this.length / 2;
            int currentJ = currentI;
            bool currentWayLengthPassedOnce = false;

            output += this.array[currentI, currentJ].ToString() + ' ';

            while (wayToPass != this.length)
            {
                for (int i = 0; i < wayToPass; i++)
                {
                    switch (direction)
                    {
                        case 0:
                            {
                                --currentI;
                            }
                            break;

                        case 1:
                            {
                                ++currentJ;
                            }
                            break;

                        case 2:
                            {
                                ++currentI;
                            }
                            break;

                        case 3:
                            {
                                --currentJ;
                            }
                            break;
                    }

                    output += this.array[currentI, currentJ].ToString() + ' ';
                }

                ++direction;

                if (currentWayLengthPassedOnce)
                {
                    direction %= 4;
                    ++wayToPass;
                    currentWayLengthPassedOnce = false;
                }
                else
                {
                    currentWayLengthPassedOnce = true;
                }
            }

            for (int i = 0; i < this.length - 1; i++)
            {
                --currentI;

                output += this.array[currentI, currentJ].ToString() + ' ';
            }

            return output;
        }
    }
}
