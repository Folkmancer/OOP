namespace Folkmancer.OOP.ControlOfEducationalProcess {
    public class FinalExam : Exam {
        //Конструкторы

        public FinalExam()
            : base() {

        }

        public FinalExam(int id, string nameOfDiscipline, string date, string nameOfTeacher, int grade)
            : base(id, nameOfDiscipline, date, nameOfTeacher, grade) {

        }

        //Методы

        public override string TypeOfTrial() {
            return "Выпускной экзамен";
        }

        public override int GetHashCode() {
            return this.ID.GetHashCode();
        }

        public override bool Equals(object obj) {
            if (obj == null || !(obj is FinalExam)) { return false; }
            FinalExam temp = (FinalExam)obj;
            return (
                this.ID == temp.ID &&
                this.NameOfDiscipline == temp.NameOfDiscipline &&
                this.Date == temp.NameOfTeacher &&
                this.NameOfTeacher == temp.NameOfTeacher &&
                this.Grade == temp.Grade
            );
        }

        public override string ToString() {
            return "Выпускной экзамен №: " + this.ID
                + ". По дисциплине: " + this.NameOfDiscipline
                + ". Дата: " + this.Date
                + ". Оценка: " + this.Grade
                + ". Преподаватель: " + this.NameOfTeacher;
        }
    }
}
