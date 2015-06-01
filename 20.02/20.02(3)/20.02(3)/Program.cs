using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashtableNamespace;

namespace HashTableHomeworkNamespace
{    
    class Program
    {
        private static long NewHashFunction(string element)
        {
            long result = 0;

            for (int i = 0; i < element.Length; i++)
            {
                result += element[i] + 1;
            }

            return result;
        }

        static void Main(string[] args)
        {
            Hashtable table = new Hashtable();

            table.AddElement("test");
            table.AddElement("lol");

            table.ChangeHashFunction(NewHashFunction);
        }
    }
}
