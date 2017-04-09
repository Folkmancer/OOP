using System;

namespace ControlOfEducationalProcess
{
    class FinalExam : Exam
    {
        //Конструкторы
        
        public FinalExam() : base()
        {
         
        }

        public FinalExam(string newNameOfDiscipline, string newDate, string newNameOfTeacher, byte newNumberOfAdmitted) 
            : base(newNameOfDiscipline, newDate, newNameOfTeacher, newNumberOfAdmitted)
        {
         
        }

        //Методы

        public override string ToString()
        {
            return "Выпускной экзамен по дисциплине " + NameOfDiscipline + " назначен на " + Date + ". Допущено студентов: " + NumberOfAdmitted + ". Преподаватель: " + NameOfTeacher;
        }
    }
}
