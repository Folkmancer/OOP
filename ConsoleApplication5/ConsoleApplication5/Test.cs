using System;

namespace ConsoleApplication5
{
    class Test : Trial
    {
        private byte points;
        private byte numberOfQuestions;
        
        //Констуркторы

        public Test() : base()
        {
            this.points = 0;
            this.numberOfQuestions = 0;
        }

        public Test(string newNameOfDiscipline, string newDate, string newNameOfTeacher, byte newPoints, byte newNumberOfQuestions) 
            : base(newNameOfDiscipline, newDate, newNameOfTeacher)
        {
            this.points = newPoints;
            this.numberOfQuestions = newNumberOfQuestions;
        }

        //Свойства

        public byte ValuePoints
        {
            get { return points; }
            set { points = value; }
        }

        public byte ValueNumberOfQuestions
        {
            get { return numberOfQuestions; }
            set { numberOfQuestions = value; }
        }

        //Методы

        public int PricePoint()
        {
            try
            {
                return points / numberOfQuestions;
            }
            catch(DivideByZeroException)
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return "Тестирование по дисциплине " + ValueNameOfDiscipline + " назначено на " + ValueDate + ". Преподаватель: " + ValueNameOfTeacher;
        }
    }
}
