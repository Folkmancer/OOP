using System;
using System.Collections;
using System.Xml.Serialization;

namespace Folkmancer.OOP.ControlOfEducationalProcess {
    [Serializable]
    [XmlInclude(typeof(Exam))]
    [XmlInclude(typeof(FinalExam))]
    [XmlInclude(typeof(Test))]
    public abstract class Trial : IInputOutput, IComparable {
        private int _id;
        private string _nameOfDiscipline;
        private string _date;
        private string _nameOfTeacher;

        //Конструкторы

        public Trial() {
            this.ID = 0;
            this.NameOfDiscipline = "";
            this.Date = "";
            this.NameOfTeacher = "";
        }

        public Trial(int id, string nameOfDiscipline, string date, string nameOfTeacher) {
            this.ID = id;
            this.NameOfDiscipline = nameOfDiscipline;
            this.Date = date;
            this.NameOfTeacher = nameOfTeacher;
        }

        //Свойства
        public int ID {
            get { return _id; }
            set { _id = value; }
        }

        public string NameOfDiscipline {
            get { return _nameOfDiscipline; }
            set { _nameOfDiscipline = value; }
        }

        public string Date {
            get { return _date; }
            set { _date = value; }
        }

        public string NameOfTeacher {
            get { return _nameOfTeacher; }
            set { _nameOfTeacher = value; }
        }

        public virtual int GetGrade() {
            return -1;
        }

        //Методы

        public virtual string TypeOfTrial() {
            return "Испытание";
        }

        public override int GetHashCode() {
            return this.ID.GetHashCode();
        }

        public override bool Equals(object obj) {
            if (obj == null || !(obj is Trial)) { return false; }
            Trial temp = (Trial)obj;
            return (
                this.ID == temp.ID &&
                this.NameOfDiscipline == temp.NameOfDiscipline &&
                this.Date == temp.NameOfTeacher &&
                this.NameOfTeacher == temp.NameOfTeacher
            );
        }

        public override string ToString() {
            return "Испытание №: " + this.ID
                + ". По дисциплине: " + this.NameOfDiscipline
                + ". Дата: " + this.Date
                + ". Преподаватель: " + this.NameOfTeacher;
        }

        public virtual void InputInfo() {
            Console.WriteLine("Введите название дисциплины:");
            this._id = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите название дисциплины:");
            this._nameOfDiscipline = Console.ReadLine();
            Console.WriteLine("Введите дату:");
            this._date = Console.ReadLine();
            Console.WriteLine("Введите имя преподавателя:");
            this._nameOfTeacher = Console.ReadLine();
        }

        public virtual void OutputInfo() {
            Console.WriteLine(this);
        }

        //IComparable

        public int CompareTo(object obj) {
            Trial temp = (Trial)obj;
            return string.Compare(this.NameOfDiscipline, temp.NameOfDiscipline);
        }

        //IComparer

        public class SortById : IComparer {
            public int Compare(object obj1, object obj2) {
                Trial temp1 = (Trial)obj1;
                Trial temp2 = (Trial)obj2;
                if (temp1.ID > temp2.ID) { return 1; }
                else if (temp1.ID < temp2.ID) { return -1; }
                else { return 0; }
            }
        }

        public class SortByName : IComparer {
            public int Compare(object obj1, object obj2) {
                Trial temp1 = (Trial)obj1;
                Trial temp2 = (Trial)obj2;
                return string.Compare(temp1.NameOfDiscipline, temp2.NameOfDiscipline);
            }
        }

        public class SortByDate : IComparer {
            public int Compare(object obj1, object obj2) {
                Trial temp1 = (Trial)obj1;
                Trial temp2 = (Trial)obj2;
                return string.Compare(temp1.Date, temp2.Date);
            }
        }

        public class SortByTeacher : IComparer {
            public int Compare(object obj1, object obj2) {
                Trial temp1 = (Trial)obj1;
                Trial temp2 = (Trial)obj2;
                return string.Compare(temp1.NameOfTeacher, temp2.NameOfTeacher);
            }
        }
    }
}
