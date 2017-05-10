using System;
using System.Collections;

namespace Folkmancer.OOP.ControlOfEducationalProcess
{
    public class Test : Trial
    {
        private int points;
        private readonly int pointsForThree;
        private readonly int pointsForFour;
        private readonly int pointsForFive;

        //Констуркторы

        public Test() : base()
        {
            this.points = 0;
            this.pointsForThree = 15;
            this.pointsForFour = 25;
            this.pointsForFive = 30;
        }

        public Test(int id, string nameOfDiscipline, string date, string nameOfTeacher, int points, int pointsForThree, int pointsForFour, int pointsForFive) 
            : base(id, nameOfDiscipline, date, nameOfTeacher)
        {
            this.points = points;
            this.pointsForThree = pointsForThree;
            this.pointsForFour = pointsForFour;
            this.pointsForFive = pointsForFive;
        }

        //Свойства

        public int Points
        {
            get { return points; }
            set
            { 
                if (value > 100)
                {
                    throw new TestException("Введено некорректное количество баллов!");
                }
                else if (value < 0)
                {
                    throw new TestException("Количество баллов не может быть отрицательным!");
                }
                else
                {
                    points = value;
                }
            }
        }

        public int PointsForThree
        {
            get { return pointsForThree; }
        }
        public int PointsForFour
        {
            get { return pointsForFour; }
        }
        public int PointsForFive
        {
            get { return pointsForFive; }
        }

        //Методы

        public int GetGrade()
        {
            if (Points >= PointsForFive) return 5;
            else if (Points < PointsForFive && Points >= PointsForFour) return 4; 
            else if (Points < PointsForFour && Points >= PointsForThree) return 3;
            else return 2;
        }

        public override string ToString()
        {
            return "Тестирование по дисциплине: " + NameOfDiscipline + ". Дата: " + Date + ". Преподаватель: " + NameOfTeacher + ". Оценка: " + GetGrade();
        }

        //IOutputInput

        public override void InputInfo()
        {
            base.InputInfo();
            Console.WriteLine("Введите количество баллов:");
            this.Points = int.Parse(Console.ReadLine());
        }

        //IComparer

        public class SortByPoint : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                Test temp1 = (Test)obj1;
                Test temp2 = (Test)obj2;
                if (temp1.Points > temp2.Points) return 1;
                else if (temp1.Points < temp2.Points) return -1;
                else return 0;
            }
        }
    }
}
