using System;

namespace Folkmancer.OOP.ControlOfEducationalProcess
{
    public delegate void TestDelegate();
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Test[] MASSTEST = { new Test("Химия", "10.12.17", "Кирекмасов", 16, 15, 25, 30), new Test("Математика", "07.04.17", "Самсонов", 20, 15, 25, 30),
            new Test("Алгебра", "18.09.17", "Юрков", 30, 15, 25, 30), new Test("Физика", "26.04.17", "Джан", 29, 15, 25, 30)};
                
                Exam Zan1 = new Exam();
                
                TestDelegate DelegateForExam = new TestDelegate(Zan1.InputInfo);
                DelegateForExam += Zan1.OutputInfo;

                Console.WriteLine("Работа делегата:");
                DelegateForExam();

                Console.WriteLine("\nИсходный массив:");
                foreach (Test Elem in MASSTEST)
                {
                    Elem.OutputInfo();
                }

                Array.Sort(MASSTEST, new Test.SortByName());
                Console.WriteLine("\nОтсортированный массив:");

                foreach (Test Elem in MASSTEST)
                {
                    Elem.OutputInfo();
                }

                Console.WriteLine("\nВведите количество баллов:");
                MASSTEST[2].Points = int.Parse(Console.ReadLine());           
            }
            catch (TestException FirstTest)
            {
                Console.WriteLine("Ошибка: " + FirstTest.Message);
            }
            catch (FormatException IX)
            {
                Console.WriteLine("Ошибка: " + IX.Message);
            }
            Console.WriteLine("Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
    }
    
}
