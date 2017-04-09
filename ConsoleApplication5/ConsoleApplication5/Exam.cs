using System;

namespace ControlOfEducationalProcess
{
    class Exam : Trial
    {
        private int numberOfAdmitted;

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

        public byte NumberOfAdmitted
        {
            get { return numberOfAdmitted; }
            set { numberOfAdmitted = value; }
        }

        //Методы

        public override string ToString()
        {
            return "Экзамен по дисциплине " + NameOfDiscipline + " назначен на " + Date + ". Допущено студентов: " + NumberOfAdmitted  + ". Преподаватель: " + NameOfTeacher;
        }
    }
}
