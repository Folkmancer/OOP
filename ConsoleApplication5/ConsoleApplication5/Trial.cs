namespace ConsoleApplication5
{
    class Trial
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

        public Trial(string newNameOfDiscipline, string newDate, string newNameOfTeacher)
        {
            this.nameOfDiscipline = newNameOfDiscipline;
            this.date = newDate;
            this.nameOfTeacher = newNameOfTeacher;
        }

        //Свойства

        public string ValueNameOfDiscipline
        {
            get { return nameOfDiscipline; }
            set { nameOfDiscipline = value; }
        }

        public string ValueDate
        {
            get { return date; }
            set { date = value; }
        }

        public string ValueNameOfTeacher
        {
            get { return nameOfTeacher; }
            set { nameOfTeacher = value; }
        }

        //Методы

        public override string ToString()
        {
            return "Испытание по дисциплине " + ValueNameOfDiscipline + " назначено на " + ValueDate + ". Преподаватель: " + ValueNameOfTeacher;
        }
    }     
}
