using System;

namespace ControlOfEducationalProcess
{
    class Test : Trial
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

        public Test(string NameOfDiscipline, string Date, string NameOfTeacher, int Points, int PointsForThree, int PointsForFour, int PointsForFive) 
            : base(NameOfDiscipline, Date, NameOfTeacher)
        {
            this.points = Points;
            this.pointsForThree = PointsForThree;
            this.pointsForFour = PointsForFour;
            this.pointsForFive = PointsForFive;
        }

        //Свойства

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public int PointsForThree
        {
            get { return points; }
        }
        public int PointsForFour
        {
            get { return points; }
        }
        public int PointsForFive
        {
            get { return points; }
        }

        //Методы

        public int GetGrade()
        {
            if (Points >= PointsForFive) { return 5; }
            else if (Points < PointsForFive && Points >= PointsForFour  ) { return 4; }
            else if (Points < PointsForFour && Points >= PointsForThree  ) { return 3; }
            else { return 2; }
        }

        public override string ToString()
        {
            return "Тестирование по дисциплине: " + NameOfDiscipline + ". Дата: " + Date + ". Преподаватель: " + NameOfTeacher + ". Оценка: " + GetGrade();
        }
    }
}
