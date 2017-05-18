using System;
using System.Collections;

namespace Folkmancer.OOP.ControlOfEducationalProcess {
    [Serializable]
    public class Exam : Trial {
        private int _grade;

        //Конструкторы

        public Exam() : base() {
            this.Grade = 0;
        }

        public Exam(int id, string nameOfDiscipline, string date, string nameOfTeacher, int grade)
            : base(id, nameOfDiscipline, date, nameOfTeacher) {
            this.Grade = grade;
        }

        //Свойства

        public int Grade {
            get { return _grade; }
            set { _grade = value; }
        }

        //Методы

        public override int GetHashCode() {
            return this.ID.GetHashCode();
        }

        public override bool Equals(object obj) {
            if (obj == null || !(obj is Exam)) { return false; }
            Exam temp = (Exam)obj;
            return (
                this.ID == temp.ID &&
                this.NameOfDiscipline == temp.NameOfDiscipline &&
                this.Date == temp.NameOfTeacher &&
                this.NameOfTeacher == temp.NameOfTeacher &&
                this.Grade == temp.Grade
            );
        }

        public override string ToString() {
            return "Экзамен №: " + this.ID
                + ". По дисциплине: " + this.NameOfDiscipline
                + ". Дата: " + this.Date
                + ". Оценка: " + this.Grade
                + ". Преподаватель: " + this.NameOfTeacher;
        }

        public override void InputInfo() {
            base.InputInfo();
            Console.WriteLine("Введите оценку:");
            this.Grade = int.Parse(Console.ReadLine());
        }

        //IComparer

        public class SortByGrade : IComparer {
            public int Compare(object obj1, object obj2) {
                Exam temp1 = (Exam)obj1;
                Exam temp2 = (Exam)obj2;
                if (temp1.Grade > temp2.Grade) { return 1; }
                else if (temp1.Grade < temp2.Grade) { return -1; }
                else { return 0; }
            }
        }

    }
}

