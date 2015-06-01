using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterHomework
{
    public class Program
    {
        public delegate bool function(int x);

        /// <summary>
        /// Deletes from list all elements for which function will return false
        /// </summary>
        /// <param name="list">List</param>
        /// <param name="func">Filter function</param>
        /// <returns>Reformed list</returns>
        public static List<int> Filter(List<int> list, function func)
        {
            List<int> newList = new List<int>();

            foreach(int element in list)
            {
                if (func(element))
                {
                    newList.Add(element);
                }
            }

            return newList;
        }

        static void Main(string[] args)
        {
        }
    }
}
