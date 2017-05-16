using System;
using System.Collections;

namespace Folkmancer.OOP.ControlOfEducationalProcess
{
    [Serializable]
    public class Test : Trial {
        private int _points;
        private int _pointsForThree;
        private int _pointsForFour;
        private int _pointsForFive;

        //Констуркторы

        public Test() : base() {
            this.Points = 0;
            this.PointsForThree = 15;
            this.PointsForFour = 25;
            this.PointsForFive = 30;
        }

        public Test(int id, string nameOfDiscipline, string date, string nameOfTeacher, 
            int points, int pointsForThree, int pointsForFour, int pointsForFive) 
            : base(id, nameOfDiscipline, date, nameOfTeacher) {
            this.Points = points;
            this.PointsForThree = pointsForThree;
            this.PointsForFour = pointsForFour;
            this.PointsForFive = pointsForFive;
        }

        //Свойства

        public int Points {
            get { return _points; }
            set
            { 
                if (value > 100) {
                    throw new TestException("Введено некорректное количество баллов!");
                }
                else if (value < 0) {
                    throw new TestException("Количество баллов не может быть отрицательным!");
                }
                else { _points = value; }
            }
        }

        public int PointsForThree {
            get { return _pointsForThree; }
            set { _pointsForThree = value; }
        }
        public int PointsForFour {
            get { return _pointsForFour; }
            set { _pointsForFour = value; }
        }
        public int PointsForFive {
            get { return _pointsForFive; }
            set { _pointsForFive = value; }
        }

        //Методы

        public int GetGrade() {
            if (Points >= PointsForFive) { return 5; }
            else if (Points < PointsForFive && Points >= PointsForFour) { return 4; }
            else if (Points < PointsForFour && Points >= PointsForThree) { return 3; }
            else { return 2; }
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public override bool Equals(object obj) {
            if (obj == null || !(obj is Test)) { return false; }
            Test temp = (Test)obj;
            return (
                this.ID == temp.ID &&
                this.NameOfDiscipline == temp.NameOfDiscipline &&
                this.Date == temp.NameOfTeacher &&
                this.NameOfTeacher == temp.NameOfTeacher &&
                this.Points == temp.Points &&
                this.PointsForThree == temp.PointsForThree &&
                this.PointsForFour == temp.PointsForFour &&
                this.PointsForFive == temp.PointsForFive
            );
        }

        public override string ToString() {
            return "Тестирование №: " + this.ID 
                + ". По дисциплине: " + this.NameOfDiscipline 
                + ". Дата: " + this.Date 
                + ". Преподаватель: " + this.NameOfTeacher 
                + ". Оценка: " + this.GetGrade();
        }

        public override void InputInfo() {
            base.InputInfo();
            Console.WriteLine("Введите количество баллов:");
            this.Points = int.Parse(Console.ReadLine());
        }

        //IComparer
        
        public class SortByPoint : IComparer {
            public int Compare(object obj1, object obj2) {
                Test temp1 = (Test)obj1;
                Test temp2 = (Test)obj2;
                if (temp1.Points > temp2.Points) { return 1; }
                else if (temp1.Points < temp2.Points) { return -1; }
                else { return  0; }
            }
        }
    }
}
