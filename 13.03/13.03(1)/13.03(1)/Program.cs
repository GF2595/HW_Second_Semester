using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapHomework
{
    public class Program
    {
        /// <summary>
        /// Commit function to all element of list
        /// </summary>
        /// <param name="list">List</param>
        /// <param name="func">Function to be committed</param>
        /// <returns>Reformed list</returns>
        public static List<int> Map(List<int> list, Func<int, int> func)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = func(list[i]);
            }

            return list;
        }

        static void Main(string[] args)
        {
        }
    }
}
