using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car> { };
            cars.Add(new Car("Волга", "Н180ТО", 6350));
            cars.Add(new Car("Жигули", "Т144ТО", 10350));
            cars.Add(new Car("Нива", "С234ТО", 56350));
            foreach (Car takeCar in cars)
            {
                takeCar.ShowCar();
            }
            int total = 0;
            foreach (Car takeCar in cars)
            {
                total += takeCar.ValueMileage;
            }
            Console.WriteLine("Общий пробег составляет: {0}", total);
            Console.ReadKey();
        }
    }
}
