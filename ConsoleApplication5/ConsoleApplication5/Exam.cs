using System;

namespace ConsoleApplication5
{
    class Exam : Trial
    {
        private byte numberOfAdmitted;

        //Конструкторы

        public Exam() : base()
        {
            this.numberOfAdmitted = 0;
        }

        public Exam(string newNameOfDiscipline, string newDate, string newNameOfTeacher, byte newNumberOfAdmitted) 
            : base(newNameOfDiscipline, newDate, newNameOfTeacher)
        {
            this.numberOfAdmitted = newNumberOfAdmitted;
        }

        //Свойства

        public byte ValueNumberOfAdmitted
        {
            get { return numberOfAdmitted; }
            set { numberOfAdmitted = value; }
        }

        //Методы

        new public string ToString()
        {
            return "Экзамен по дисциплине " + ValueNameOfDiscipline + " назначен на " + ValueDate + ". Допущено студентов: " + ValueNumberOfAdmitted  + ". Преподаватель: " + ValueNameOfTeacher;
        }
    }
}
