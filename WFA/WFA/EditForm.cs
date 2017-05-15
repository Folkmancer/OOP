using System;
using System.Windows.Forms;
using Folkmancer.OOP.ControlOfEducationalProcess;

namespace Folkmancer.OOP.GUI
{
    public partial class EditForm : Form
    {
        private Form1 _mainForm;
        private int _index;

        public EditForm(Form1 F, int index)
        {
            InitializeComponent();
            this._mainForm = F;
            this._index = index;
            Initiate(_index);
        }

        private void Initiate(int index)
        {
            if (_mainForm.Exams[index].GetType() == typeof(Exam))
            {
                Exam Temp = (Exam)_mainForm.Exams[index];
                this.textBox1.Text = Temp.ID.ToString();
                this.textBox2.Text = Temp.NameOfDiscipline;
                this.dateTimePicker1.Text = Temp.Date;
                this.textBox3.Text = Temp.NameOfTeacher;
                this.comboBox1.Text = Temp.Grade.ToString();
            }
            else if (_mainForm.Exams[index].GetType() == typeof(FinalExam))
            {
                FinalExam Temp = (FinalExam)_mainForm.Exams[index];
                this.textBox1.Text = Temp.ID.ToString();
                this.textBox2.Text = Temp.NameOfDiscipline;
                this.dateTimePicker1.Text = Temp.Date;
                this.textBox3.Text = Temp.NameOfTeacher;
                this.comboBox1.Text = Temp.Grade.ToString();
            }
            else if (_mainForm.Exams[index].GetType() == typeof(Test))
            {
                Test Temp = (Test)_mainForm.Exams[index];
                this.textBox1.Text = Temp.ID.ToString();
                this.textBox2.Text = Temp.NameOfDiscipline;
                this.dateTimePicker1.Text = Temp.Date;
                this.textBox3.Text = Temp.NameOfTeacher;
                this.textBox4.Text = Temp.Points.ToString();
                this.textBox5.Text = Temp.PointsForThree.ToString();
                this.textBox6.Text = Temp.PointsForFour.ToString();
                this.textBox7.Text = Temp.PointsForFive.ToString();
            }
        }

        private void Editing(int index)
        {
            if (_mainForm.Exams[index].GetType() == typeof(Exam))
            {
                EditExam(
                   int.Parse(this.textBox1.Text),
                   this.textBox2.Text,
                   this.dateTimePicker1.Text,
                   this.textBox3.Text,
                   int.Parse(this.comboBox1.Text)
               );
            }
            else if (_mainForm.Exams[index].GetType() == typeof(FinalExam))
            {
                EditFInalExam(
                   int.Parse(this.textBox1.Text),
                   this.textBox2.Text,
                   this.dateTimePicker1.Text,
                   this.textBox3.Text,
                   int.Parse(this.comboBox1.Text)
               );
            }
            else if (_mainForm.Exams[index].GetType() == typeof(Test))
            {
                EditTest(
                   int.Parse(this.textBox1.Text),
                   this.textBox2.Text,
                   this.dateTimePicker1.Text,
                   this.textBox3.Text,
                   int.Parse(this.textBox4.Text),
                   int.Parse(this.textBox5.Text),
                   int.Parse(this.textBox6.Text),
                   int.Parse(this.textBox7.Text)
               );
            }
        }

        private void EditExam(int ID, string NOD, string Date, string NOT, int Grade)
        {
            if ((ID != 0) && (NOD != "") && (Date != "") && (NOT != "") && (Grade != 0))
            {
                _mainForm.Exams[_index] = new Exam(
                    ID, 
                    NOD, 
                    Date, 
                    NOT, 
                    Grade
                );
                this.Close();
            }
            else throw new Exception("Поля не могут быть пустыми или нулевыми!");
        }

        private void EditFInalExam(int ID, string NOD, string Date, string NOT, int Grade)
        {
            if ((ID != 0) && (NOD != "") && (Date != "") && (NOT != "") && (Grade != 0))
            {
                _mainForm.Exams[_index] = new FinalExam(
                        ID,
                        NOD,
                        Date,
                        NOT,
                        Grade
                );
            }
            else throw new Exception("Поля не могут быть пустыми или нулевыми!");
        }
        private void EditTest(int ID, string NOD, string Date, string NOT, int Point, int Pft, int Pffo, int Pffi)
        {
            if ((ID != 0) && (NOD != "") && (Date != "") && (NOT != "")
                && (Point != 0) && (Pft != 0) && (Pffo != 0) && (Pffi != 0))
            {
                _mainForm.Exams[_index] = new Test(
                        ID,
                        NOD,
                        Date,
                        NOT,
                        Point,
                        Pft,
                        Pffo,
                        Pffi
                );
            }
            else throw new Exception("Поля не могут быть пустыми или нулевыми!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Editing(_index);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
