using System;

namespace ConsoleApplication5
{
    class FinalExam : Exam
    {
        //Конструкторы
        //private List<string> = new List<string>;
        public FinalExam() : base()
        {
         
        }

        public FinalExam(string newNameOfDiscipline, string newDate, string newNameOfTeacher, byte newNumberOfAdmitted) 
            : base(newNameOfDiscipline, newDate, newNameOfTeacher, newNumberOfAdmitted)
        {
         
        }

        //Методы

        new string ToString()
        {
            return "Выпускной экзамен по дисциплине " + ValueNameOfDiscipline + " назначен на " + ValueDate + ". Допущено студентов: " + ValueNumberOfAdmitted + ". Преподаватель: " + ValueNameOfTeacher;
        }
    }
}
