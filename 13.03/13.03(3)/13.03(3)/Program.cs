using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldHomework
{
    public class Program
    {
        public delegate int function(int acc, int element);

        /// <summary>
        /// Accumulates value from list using function as accumulating rule
        /// </summary>
        /// <param name="list">List</param>
        /// <param name="basic">Basic value for accumulator</param>
        /// <param name="func">Accumulating rule function</param>
        /// <returns>Accumulated value</returns>
        public static int Fold(List<int> list, int basic, function func)
        {
            int acc = basic;
            
            foreach (int element in list)
            {
                acc = func(acc, element);
            }
            return acc;
        }

        static void Main(string[] args)
        {
        }
    }
}
