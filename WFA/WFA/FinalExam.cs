using System;

namespace Folkmancer.OOP.ControlOfEducationalProcess
{
    public class FinalExam : Exam
    {
        //Конструкторы
        
        public FinalExam() : base()
        {
         
        }

        public FinalExam(int id, string nameOfDiscipline, string date, string nameOfTeacher, int grade) 
            : base(id, nameOfDiscipline, date, nameOfTeacher, grade)
        {
         
        }

        //Методы

        public override string ToString()
        {
            return "Выпускной экзамен по дисциплине: " + NameOfDiscipline + ". Дата: " + Date + ". Оценка: " + Grade + ". Преподаватель: " + NameOfTeacher;
        }
    }
}
