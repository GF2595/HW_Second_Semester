using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListNamespace;

namespace HashtableNamespace
{
    /// <summary>
    ///_List-based hashtable
    /// </summary>
    public class Hashtable
    {
        private _List table = new _List();

        public delegate long HashFunction(string element);

        /// <summary>
        /// Default hash-function
        /// </summary>
        /// <param name="element">Element value</param>
        /// <returns>Element key</returns>
        private static long DefaultHashFunction(string element)
        {
            long result = 0;

            for (int i = 0; i < element.Length; i++)
            {
                result += element[i];
            }

            return result;
        }

        private HashFunction UsedHashFunction = DefaultHashFunction;

        /// <summary>
        /// Changes hash function
        /// </summary>
        /// <param name="newFunction">Hash function, that will be used by hashtable after this method calling</param>
        public void ChangeHashFunction(HashFunction newFunction)
        {
            for (int i = 0; i <= table.GetListLength(); i++)
            {
                table.DeleteElement(1);
            }

            this.UsedHashFunction = newFunction;
        }

        /// <summary>
        /// Adds element to hashtable
        /// </summary>
        /// <param name="element">Element to be added</param>
        public void AddElement(string element)
        {
            if (!this.IsElementInTable(element))
            {
                long key = this.UsedHashFunction(element);

                try
                {
                    this.table.PlaceElement(element, key);
                }
                catch (WrongElementPositionException)
                {
                    this.table.ExpandListLength(key - 1);
                    this.table.AddElement(element);
                }
            }
        }

        /// <summary>
        /// Checks if element is in table
        /// </summary>
        /// <param name="element">Element</param>
        /// <returns>"true" if element is found, "false" otherwise</returns>
        public bool IsElementInTable(string element)
        {
            long elementKey = this.UsedHashFunction(element);

            if (this.table.GetListLength() >= elementKey)
            {
                if (this.table.CheckElement(elementKey) == element)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes element from hashtable
        /// </summary>
        /// <param name="element">Element to be deleted</param>
        public void DeleteElement(string element)
        {
            long elementKey = this.UsedHashFunction(element);

            if (this.table.CheckElement(elementKey) != "")
            {
                this.table.DeleteElement(elementKey);
                this.table.PlaceElement("", elementKey - 1);
            }
        }
    }
}
