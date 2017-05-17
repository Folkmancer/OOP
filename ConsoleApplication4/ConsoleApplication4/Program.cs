using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program {
        static void Main(string[] args) {
            List<Car> _cars = new List<Car> { };
            _cars.Add(new Car("Волга", "Н180ТО", 6350));
            _cars.Add(new Car("Жигули", "Т144ТО", 10350));
            _cars.Add(new Car("Нива", "С234ТО", 56350));
            foreach (Car car in _cars)
            {
                car.ShowCar();
            }
            int total = 0;
            foreach (Car car in _cars)
            {
                total += car.Mileage;
            }
            Console.WriteLine("Общий пробег составляет: {0}", total);
            Console.ReadKey();
        }
    }
}
