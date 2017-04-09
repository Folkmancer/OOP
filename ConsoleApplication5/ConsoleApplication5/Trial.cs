namespace ControlOfEducationalProcess
{
    abstract class Trial
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

        public Trial(string NameOfDiscipline, string Date, string NameOfTeacher)
        {
            this.nameOfDiscipline = NameOfDiscipline;
            this.date = Date;
            this.nameOfTeacher = NameOfTeacher;
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
            return "Испытание по дисциплине " + NameOfDiscipline + " назначено на " + Date + ". Преподаватель: " + NameOfTeacher;
        }
    }     
}
