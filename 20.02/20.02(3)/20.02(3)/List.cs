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
        protected ListElement tail = null;
        protected long length = 0;

        protected class ListElement
        {
            internal string Value { get; set; }

            internal ListElement Next { get; set; }
        }

        /// <summary>
        /// Adds value to the end of a list
        /// </summary>
        /// <param name="value">Value to be added</param>
        public virtual void AddElement(string value)
        {
            ListElement newElement = new ListElement
            {
                Value = value,
                Next = null
            };

            if (this.head != null)
            {
                this.tail.Next = newElement;
                this.tail = newElement;
            }
            else
            {
                this.head = newElement;
                this.tail = newElement;
            }

            ++this.length;
        }

        /// <summary>
        /// Expands list length by specified number of elements
        /// </summary>
        /// <param name="position">New list length</param>
        public void ExpandListLength(long newLength)
        {
            if (this.head == null)
            {
                this.head = new ListElement
                {
                    Value = "",
                    Next = null
                };

                this.tail = this.head;

                ++this.length;
            }
            
            ListElement currentElement = this.tail;

            for (long i = this.length; i < newLength; i++)
            {
                ListElement temp = new ListElement
                {
                    Value = "",
                    Next = null
                };

                currentElement.Next = temp;
                currentElement = currentElement.Next;
                this.tail = currentElement;
                ++this.length;
            }

        }

        /// <summary>
        /// Replaces element on current position by new element
        /// </summary>
        /// <param name="value">New element</param>
        /// <param name="position">Element position</param>
        public void PlaceElement(string value, long position)
        {
            if (position > this.length)
            {
                throw new WrongElementPositionException();
            }
            else
            {
                ListElement currentElement = this.head;

                for (long i = 1; i < position; i++)
                {
                    currentElement = currentElement.Next;
                }

                currentElement.Value = value;
            }
        }

        /// <summary>
        /// Inserts new element in specified place in list
        /// </summary>
        /// <param name="value">Value to be added</param>
        /// <param name="position">Position on which element will be placed</param>
        public virtual void InsertElement(string value, long position)
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
                    this.tail = newElement;
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

                this.tail.Next = newElement;
                this.tail = newElement;
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
        public void DeleteElement(long position)
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
                else if (currentElement == this.tail)
                {
                    this.tail = previousElement;
                    this.tail.Next = null;
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
        public string CheckElement(long position)
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
        public long FindElement(string value)
        {
            if (this.head != null)
            {
                ListElement currentElement = this.head;
                long currentPosition = 1;

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

        /// <summary>
        /// Return list length
        /// </summary>
        /// <returns>List length</returns>
        public long GetListLength()
        {
            return this.length;
        }
    }
}
