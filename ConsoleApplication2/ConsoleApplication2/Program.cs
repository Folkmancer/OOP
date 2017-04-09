using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            String oldString, newString;
            oldString = Console.ReadLine();
            newString = oldString.Trim();
            while(newString.Contains("  ") == true)
            {
               newString = newString.Remove(newString.IndexOf("  "), 1);
            }
            Console.WriteLine(newString);
            Console.ReadKey();
        }
    }
}
