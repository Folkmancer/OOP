using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlOfEducationalProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Trial asdad = new Trial("sda", "sad");
            Test a1 = new Test("Математика", "18.09.17", "Кирекмасов", 30, 15);
            Exam a2 = new Exam("Литература", "19.11.17", "Санбусов", 17);
            Trial Ran = new Exam("Русский язык", "19.11.17", "Кушкулёва", 16);
            Trial Poz = new Test("Англ язык", "12.11.17", "Денисова", 20, 10);
            Console.WriteLine(a1);
            Console.WriteLine(a2);
            Console.WriteLine(Ran);
            Console.WriteLine(Poz);
            Console.ReadKey();
        }
    }
    
}
