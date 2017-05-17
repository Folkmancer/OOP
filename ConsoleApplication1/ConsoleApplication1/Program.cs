using System;

namespace Folkmancer.OOP.FirstLab
{
    class Program {
        static void Main(string[] args) {
            int rows, columns;
            Console.WriteLine("Введите количество строк:");
            string buf = Console.ReadLine();
            rows = Convert.ToInt32(buf);
            Console.WriteLine("Введите количество столбцов:");
            buf = Console.ReadLine();
            columns = Convert.ToInt32(buf);
            Random ran = new Random();
            int[,] masStart = new int[rows, columns];
            int[,] masMaxElementRows = new int[rows, 3];
            int[,] maxElement = new int[1, 3];
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    masStart[i,j] = ran.Next(-20,+20);
                    if (j != columns - 1) { Console.Write("{0}\t", masStart[i, j]); }
                    else { Console.WriteLine(masStart[i, j]); }
                }  
            }
            Console.WriteLine("Максимальные элементы строк:");
            for (int i = 0; i < rows; i++) {
                 for (int j = 0; j < columns; j++) {
                     if (masStart[i,j] > masMaxElementRows[i,0]) {
                        masMaxElementRows[i, 0] = masStart[i, j];
                        masMaxElementRows[i, 1] = i;
                        masMaxElementRows[i, 2] = j;
                    } 
                 }
                Console.WriteLine("{0}\t", masMaxElementRows[i,0]);
            }
            maxElement[0, 0] = masMaxElementRows[0, 0];
            maxElement[0, 1] = masMaxElementRows[0, 1];
            maxElement[0, 2] = masMaxElementRows[0, 2];
            for (int i = 0; i < rows; i++) {
                if (masMaxElementRows[i, 0] > maxElement[0, 0]) {
                    maxElement[0, 0] = masMaxElementRows[i, 0];
                    maxElement[0, 1] = masMaxElementRows[i, 1];
                    maxElement[0, 2] = masMaxElementRows[i, 2];

                }
            }
            Console.WriteLine("Максимальный элемент:");
            Console.WriteLine("i[" + (maxElement[0, 1] + 1) + "] j[" + (maxElement[0, 2] + 1)+ "] " + maxElement[0, 0]);
            Console.ReadKey();
        }
    }
}
