using System;

namespace Folkmancer.OOP.RemovingSpaces
{
    class Program {
        static void Main(string[] args) {
            string oldString, newString;
            oldString = Console.ReadLine();
            newString = oldString.Trim();
            while (newString.Contains("  ") == true) {
               newString = newString.Remove(newString.IndexOf("  "), 1);
            }
            Console.WriteLine(newString);
            Console.ReadKey();
        }
    }
}
