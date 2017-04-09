using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Car
    {
        private string carMake;
        private string regNumber;
        private int mileage;
        public Car(string newCarMake, string newRegNumber, int newMileage)
        {
            this.carMake = newCarMake;
            this.regNumber = newRegNumber;
            this.mileage = newMileage;
        }
        public string ValueCarMake
        {
            get { return carMake; }
            set { carMake = value; }
        }
        public string ValueRegNumber
        {
            get { return regNumber; }
            set { regNumber = value; }
        }
        public int ValueMileage
        {
            get { return mileage; }
            set { mileage = value; }
        }
        public void ShowCar()
        {
            Console.WriteLine("Марка автомобиля {0}, регистрационный номер {1}, пробег {2}", carMake, regNumber, mileage);
        }
    }
}
