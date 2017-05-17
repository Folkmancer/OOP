using System;
using System.Text.RegularExpressions;

namespace Folkmacer.OOP.UsingRegex
{
    class Program {
        static void Main(string[] args) {
            string text = "Абонент с номером 543-23-52. Позвоните по 213-25-93. Чей это номер 543-23-52?";
            string pattern = @"\d{3}-\d{2}-\d{2}";
            Regex r = new Regex(pattern);
            Match m = r.Match(text);
            while (m.Success) {
                Console.WriteLine(m);
                m = m.NextMatch();
            }
            Console.ReadKey();
        }
    }
}