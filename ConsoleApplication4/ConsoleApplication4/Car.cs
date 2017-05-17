using System;

namespace Folkmancer.OOP.FirstClass
{
    class Car {
        private string _carMake;
        private string _regNumber;
        private int _mileage;

        public Car(string carMake, string regNumber, int mileage) {
            this.CarMake = carMake;
            this.RegNumber = regNumber;
            this.Mileage = mileage;
        }

        public string CarMake {
            get { return _carMake; }
            set { _carMake = value; }
        }

        public string RegNumber {
            get { return _regNumber; }
            set { _regNumber = value; }
        }

        public int Mileage {
            get { return _mileage; }
            set { _mileage = value; }
        }

        public void ShowCar() {
            Console.WriteLine("Марка автомобиля {0}, регистрационный номер {1}, пробег {2}", CarMake, RegNumber, Mileage);
        }
    }
}
