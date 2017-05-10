﻿using System;

namespace ControlOfEducationalProcess
{
    class FinalExam : Exam
    {
        //Конструкторы
        
        public FinalExam() : base()
        {
         
        }

        public FinalExam(string nameOfDiscipline, string date, string nameOfTeacher, int grade) 
            : base(nameOfDiscipline, date, nameOfTeacher, grade)
        {
         
        }

        //Методы

        public override string ToString()
        {
            return "Выпускной экзамен по дисциплине: " + NameOfDiscipline + ". Дата: " + Date + ". Оценка: " + Grade + ". Преподаватель: " + NameOfTeacher;
        }
    }
}
