using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GenericListNamespace
{
    /// <summary>
    /// Generic references-based enumerable list
    /// </summary>
    /// <typeparam name="T">List elements type</typeparam>
    public class GenericList<T> : IEnumerable<T>
    {
        protected ListElement head = null;
        protected ListElement tale = null;
        protected int length = 0;

        protected class ListElement
        {
            internal T Value { get; set; }

            internal ListElement Next { get; set; }
        }
        
        /// <summary>
        /// Here and further till GenericList(T).AddElement - IEnumerable interface realisation
        /// </summary>
        
        public IEnumerator<T> GetEnumerator()
        {
            return new GenericListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class GenericListEnumerator : IEnumerator<T>
        {
            private int length;
            private ListElement currentElement;
            private int currentIndex;
            private ListElement startElement;

            public GenericListEnumerator(GenericList<T> list)
            {
                startElement = new ListElement
                {
                    Value = default(T),
                    Next = list.head
                };
                length = list.length;
                currentElement = startElement;
                currentIndex = -1;
            }

            public T Current
            {
                get
                {
                    return currentElement.Value;
                }
            }

            public void Dispose()
            {
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                if (currentIndex == length - 1)
                {
                    Reset();
                    return false;
                }

                ++currentIndex;
                currentElement = currentElement.Next;
                return true;
            }

            public void Reset()
            {
                currentIndex = -1;
                currentElement = startElement;
            }
        }

        /// <summary>
        /// Adds value to the end of a list
        /// </summary>
        /// <param name="value">Value to be added</param>
        public virtual void AddElement(T value)
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
        public virtual void PlaceElement(T value, int position)
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
        public T CheckElement(int position)
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
        public int FindElement(T value)
        {
            if (this.head != null)
            {
                ListElement currentElement = this.head;
                int currentPosition = 1;

                while (currentPosition < this.length && !currentElement.Value.Equals(value))
                {
                    ++currentPosition;
                    currentElement = currentElement.Next;
                }

                if (currentElement.Value.Equals(value))
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
