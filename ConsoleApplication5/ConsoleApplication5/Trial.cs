﻿using System;
using System.Collections;

namespace ControlOfEducationalProcess
{
    abstract class Trial : IOutputInput, IComparable
    {
        private string nameOfDiscipline;
        private string date;
        private string nameOfTeacher;

        //Конструкторы

        public Trial()
        {
            this.nameOfDiscipline = "";
            this.date = "";
            this.nameOfTeacher = "";
        }

        public Trial(string nameOfDiscipline, string date, string nameOfTeacher)
        {
            this.nameOfDiscipline = nameOfDiscipline;
            this.date = date;
            this.nameOfTeacher = nameOfTeacher;
        }

        //Свойства

        public string NameOfDiscipline
        {
            get { return nameOfDiscipline; }
            set { nameOfDiscipline = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string NameOfTeacher
        {
            get { return nameOfTeacher; }
            set { nameOfTeacher = value; }
        }

        //Методы

        public override string ToString()
        {
            return "Испытание по дисциплине: " + NameOfDiscipline + ". Дата: " + Date + ". Преподаватель: " + NameOfTeacher;
        }

        //IOutputInput

        public virtual void InputInfo()
        {
            Console.WriteLine("Введите название дисциплины:");
            this.nameOfDiscipline = Console.ReadLine();
            Console.WriteLine("Введите дату:");
            this.date = Console.ReadLine();
            Console.WriteLine("Введите имя преподавателя:");
            this.nameOfTeacher = Console.ReadLine();
        }

        public virtual void OutputInfo()
        {
            Console.WriteLine(this);
        }

        //IComparable

        public int CompareTo(object obj)
        {
            Trial temp = (Trial)obj;
            return String.Compare(this.NameOfDiscipline, temp.NameOfDiscipline);
        }

        //IComparer

        public class SortByName : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                Trial temp1 = (Trial)obj1;
                Trial temp2 = (Trial)obj2;
                return String.Compare(temp1.NameOfDiscipline, temp2.NameOfDiscipline);
            }
        }

        public class SortByDate : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                Trial temp1 = (Trial)obj1;
                Trial temp2 = (Trial)obj2;
                return String.Compare(temp1.Date, temp2.Date);
            }
        }

        public class SortByTeacher : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                Trial temp1 = (Trial)obj1;
                Trial temp2 = (Trial)obj2;
                return String.Compare(temp1.NameOfTeacher, temp2.NameOfTeacher);
            }
        }
    }
}
