using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListNamespace
{
    /// <summary>
    /// References-based list
    /// </summary>
    public class _List
    {
        protected ListElement head = null;
        protected ListElement tale = null;
        protected int length = 0;

        protected class ListElement
        {
            internal int Value { get; set; }

            internal ListElement Next { get; set; }
        }

        /// <summary>
        /// Adds value to the end of a list
        /// </summary>
        /// <param name="value">Value to be added</param>
        public virtual void AddElement(int value)
        {
            ListElement newElement = new ListElement
            {
                Value = value,
                Next = null
            };

            if (this.head != null)
            {
                this.tale.Next = newElement;
                this.tale = newElement;
            }
            else
            {
                this.head = newElement;
                this.tale = newElement;
            }

            ++this.length;
        }

        /// <summary>
        /// Places value on specified place in list
        /// </summary>
        /// <param name="value">Value to be added</param>
        /// <param name="position">Position on which element will be placed</param>
        public virtual void PlaceElement(int value, int position)
        {
            if (position == 1)
            {
                ListElement newElement = new ListElement
                {
                    Value = value,
                    Next = this.head
                };

                if (this.head == null)
                {
                    this.tale = newElement;
                }

                this.head = newElement;
            }
            else if (position == this.length + 1)
            {
                ListElement newElement = new ListElement
                {
                    Value = value,
                    Next = null
                };

                this.tale.Next = newElement;
                this.tale = newElement;
            }
            else if (position > this.length + 1)
            {
                Console.WriteLine("Неверная позиция, добавление элемента невозможно");

                --this.length;
            }
            else
            {
                int currentPosition = 2;
                ListElement currentElement = this.head;

                while (position != currentPosition)
                {
                    ++currentPosition;
                    currentElement = currentElement.Next;
                }

                ListElement newElement = new ListElement
                {
                    Value = value,
                    Next = currentElement.Next
                };

                currentElement.Next = newElement;
            }

            ++this.length;
        }

        /// <summary>
        /// Deletes element, standing on specified position in list
        /// </summary>
        /// <param name="position">Position of element to be deleted</param>
        public void DeleteElement(int position)
        {
            if (position <= this.length)
            {
                int currentPosition = 1;
                ListElement currentElement = this.head;
                ListElement previousElement = null;

                while (position != currentPosition)
                {
                    ++currentPosition;
                    previousElement = currentElement;
                    currentElement = currentElement.Next;
                }

                if (currentElement == this.head)
                {
                    this.head = this.head.Next;
                }
                else if (currentElement == this.tale)
                {
                    this.tale = previousElement;
                    this.tale.Next = null;
                }
                else
                {
                    previousElement.Next = currentElement.Next;
                }

                --this.length;
            }
            else
            {
                Console.WriteLine("Запрашиваемый элемент не существует. Удаление невозможно");
            }
        }

        /// <summary>
        /// Returns element standing on specified position in list
        /// </summary>
        /// <param name="position">Position of element tobe checked</param>
        /// <returns>Element value</returns>
        /// <exception cref="WrongElementPositionException">Is thrown if element with such position doesn't exist in list</exception>
        public int CheckElement(int position)
        {
            if (position > this.length)
            {
                throw new WrongElementPositionException();
            }
            else
            {
                int currentPosition = 1;
                ListElement currentElement = this.head;

                while (position != currentPosition)
                {
                    ++currentPosition;
                    currentElement = currentElement.Next;
                }

                return currentElement.Value;
            }
        }

        /// <summary>
        /// Finds element in list
        /// </summary>
        /// <param name="value">Element value</param>
        /// <returns>Element position if element is found</returns>
        /// <exception cref="ElementNotFoundException">Is thrown if element is not found in list</exception>
        public int FindElement(int value)
        {
            if (this.head != null)
            {
                ListElement currentElement = this.head;
                int currentPosition = 1;

                while (currentPosition < this.length && currentElement.Value != value)
                {
                    ++currentPosition;
                    currentElement = currentElement.Next;
                }

                if (currentElement.Value == value)
                {
                    return currentPosition;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
