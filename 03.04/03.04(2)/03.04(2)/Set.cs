using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetNamespace
{
    /// <summary>
    /// Generic List(T)-based set
    /// </summary>
    /// <typeparam name="T">Set elements type</typeparam>
    public class GenericSet<T>
    {
        private List<T> list = new List<T>();

        /// <summary>
        /// Adds element to set if it doesn't belong to set already
        /// </summary>
        /// <param name="element">Element to be added</param>
        public void AddElement(T element)
        {
            if (list.IndexOf(element) == -1)
            {
                list.Add(element);
            }
        }

        /// <summary>
        /// Deletes element from set
        /// </summary>
        /// <param name="element">Element to be deleted</param>
        public void DeleteElement(T element)
        {
            list.Remove(element);
        }

        /// <summary>
        /// Checks if element is in set
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool IsElementInSet(T element)
        {
            return list.IndexOf(element) != -1;
        }

        /// <summary>
        /// Builds the new set, which represents an intersection of two already existing sets
        /// </summary>
        /// <param name="firstSet">First to be intersected set</param>
        /// <param name="secondSet">Second to be intersected set</param>
        /// <returns>Intersection result</returns>
        public static GenericSet<T> Intersection(GenericSet<T> firstSet, GenericSet<T> secondSet)
        {
            GenericSet<T> newSet = new GenericSet<T>();

            foreach(T i in firstSet.list)
            {
                if (secondSet.IsElementInSet(i))
                {
                    newSet.AddElement(i);
                }
            }

            return newSet;
        }

        /// <summary>
        /// Builds the new set, which represents a union of two already existing sets
        /// </summary>
        /// <param name="firstSet">First to be united set</param>
        /// <param name="secondSet">Second to be united set</param>
        /// <returns>Union result</returns>
        public static GenericSet<T> Union(GenericSet<T> firstSet, GenericSet<T> secondSet)
        {
            GenericSet<T> unitedSet = new GenericSet<T>();

            foreach (T i in firstSet.list)
            {
                unitedSet.AddElement(i);
            }

            foreach (T i in secondSet.list)
            {                
                unitedSet.AddElement(i);
            }

            return unitedSet;
        }
    }
}
