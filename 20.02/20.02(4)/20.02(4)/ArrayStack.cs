using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackNamespace
{
    public class EmptyStackPopException : ApplicationException
    {
        public EmptyStackPopException()
        {
        }

        public EmptyStackPopException(string message)
            : base(message)
        {
        }
    }

    /// <summary>
    /// Array-based stack
    /// </summary>
    class Stack : IStack
    {
        private class StackOverflowException : ApplicationException
        {
            public StackOverflowException()
            {
            }

            public StackOverflowException(string message)
                : base(message)
            {
            }
        }

        private int maxLength = 10;
        private int lastWrittenElementPosition = -1;
        private int[] array = new int[10];

        /// <summary>
        /// Increases maximum number of elements in stack
        /// </summary>
        private void ExpandArray()
        {
            maxLength += 10;

            switch(maxLength)
            {
                case 20:
                    {
                        int[] newArray = new int[20];
                        this.array.CopyTo(newArray, 0);
                        this.array = newArray;
                    }
                    break;
                case 30:
                    {
                        int[] newArray = new int[30];
                        this.array.CopyTo(newArray, 0);
                        this.array = newArray;
                    }
                    break;
                case 40:
                    {
                        int[] newArray = new int[40];
                        this.array.CopyTo(newArray, 0);
                        this.array = newArray;
                    }
                    break;
                case 50:
                    {
                        int[] newArray = new int[50];
                        this.array.CopyTo(newArray, 0);
                        this.array = newArray;
                    }
                    break;
                default:
                    {
                        throw new StackOverflowException();
                    }
            }
        }

        /// <summary>
        /// Push element into stack
        /// </summary>
        /// <param name="element">Element to be pushed</param>
        public void push(int element)
        {
            if (this.lastWrittenElementPosition == (this.maxLength - 1))
            {
                try
                {
                    this.ExpandArray();
                }
                catch(StackOverflowException)
                {
                    Console.WriteLine("Достигнут предел расширения массива. Добавление нового элемента невозможно");

                    return;
                }
            }

            ++this.lastWrittenElementPosition;
            this.array[this.lastWrittenElementPosition] = element;
        }

        /// <summary>
        /// Pop element from stack
        /// </summary>
        /// <returns>Top element from stack</returns>
        public int pop()
        {
            if (this.lastWrittenElementPosition != -1)
            {
                --this.lastWrittenElementPosition;

                return this.array[lastWrittenElementPosition + 1];
            }
            else
            {
                throw new EmptyStackPopException();
            }
        }
    }
}
