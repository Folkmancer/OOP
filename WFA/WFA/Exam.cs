using System;
using System.Collections;

namespace Folkmancer.OOP.ControlOfEducationalProcess
{
    [Serializable]
    public class Exam : Trial
    {
        private int grade;

        //Конструкторы

        public Exam() : base()
        {
            this.grade = 0;
        }

        public Exam(int id, string nameOfDiscipline, string date, string nameOfTeacher, int grade)
            : base(id, nameOfDiscipline, date, nameOfTeacher)
        {
            this.grade = grade;
        }

        //Свойства

        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        //Методы

        public override string ToString()
        {
            return "Экзамен по дисциплине: " + NameOfDiscipline + ". Дата: " + Date + ". Оценка: " + Grade + ". Преподаватель: " + NameOfTeacher;
        }

        //IOutputInput

        public override void InputInfo()
        {
            base.InputInfo();
            Console.WriteLine("Введите оценку:");
            this.Grade = int.Parse(Console.ReadLine());
        }

        //IComparer

        public class SortByGrade : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                Exam temp1 = (Exam)obj1;
                Exam temp2 = (Exam)obj2;
                if (temp1.Grade > temp2.Grade) return 1;
                else if (temp1.Grade < temp2.Grade) return -1;
                else return 0;
            }
        }

    }
}

