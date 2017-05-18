using System;
using System.Windows.Forms;

using Folkmancer.OOP.ControlOfEducationalProcess;

namespace Folkmancer.OOP.GUI {
    public partial class EditForm : Form {
        private Form1 _mainForm;
        private int _index;

        public EditForm(Form1 F, int index) {
            InitializeComponent();
            this._mainForm = F;
            this._index = index;
            Initiate(_index);
        }

        private void Initiate(int index) {
            if (_mainForm.Exams[index].GetType() == typeof(Exam)) {
                Exam Temp = (Exam)_mainForm.Exams[index];
                this.comboBox1.Enabled = true;
                this.textBox4.Enabled = false;
                this.textBox5.Enabled = false;
                this.textBox6.Enabled = false;
                this.textBox7.Enabled = false;
                this.textBox1.Text = Temp.ID.ToString();
                this.textBox2.Text = Temp.NameOfDiscipline;
                this.dateTimePicker1.Text = Temp.Date;
                this.textBox3.Text = Temp.NameOfTeacher;
                this.comboBox1.Text = Temp.Grade.ToString();
            }
            else if (_mainForm.Exams[index].GetType() == typeof(FinalExam)) {
                FinalExam Temp = (FinalExam)_mainForm.Exams[index];
                this.comboBox1.Enabled = true;
                this.textBox4.Enabled = false;
                this.textBox5.Enabled = false;
                this.textBox6.Enabled = false;
                this.textBox7.Enabled = false;
                this.textBox1.Text = Temp.ID.ToString();
                this.textBox2.Text = Temp.NameOfDiscipline;
                this.dateTimePicker1.Text = Temp.Date;
                this.textBox3.Text = Temp.NameOfTeacher;
                this.comboBox1.Text = Temp.Grade.ToString();
            }
            else if (_mainForm.Exams[index].GetType() == typeof(Test)) {
                Test Temp = (Test)_mainForm.Exams[index];
                this.comboBox1.Enabled = false;
                this.textBox4.Enabled = true;
                this.textBox5.Enabled = true;
                this.textBox6.Enabled = true;
                this.textBox7.Enabled = true;
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

        private void Editing(int index) {
            if (this.textBox1.Text == "") { throw new FormatException("Введите идентификатор."); }
            if ((this._mainForm.SpaceDeleting(this.textBox2.Text)) == "") { throw new FormatException("Введите предмет."); }
            if ((this._mainForm.SpaceDeleting(this.textBox3.Text)) == "") { throw new FormatException("Введите преподавателя."); }
            if (this.comboBox1.Enabled == true) {
                if (this.comboBox1.Text == "") { throw new FormatException("Введите оценку."); }
            }
            if (this.textBox4.Enabled == true) {
                if (this.textBox4.Text == "") { throw new FormatException("Введите баллы."); }
                if (this.textBox5.Text == "") { throw new FormatException("Введите баллы на тройку."); }
                if (this.textBox6.Text == "") { throw new FormatException("Введите баллы на четвёрку."); }
                if (this.textBox7.Text == "") { throw new FormatException("Введите баллы на пятёрку."); }
            }
            if (_mainForm.Exams[index].GetType() == typeof(Exam)) {
                _mainForm.Exams[_index] = new Exam(
                   int.Parse(this.textBox1.Text),
                   _mainForm.SpaceDeleting(this.textBox2.Text),
                   this.dateTimePicker1.Text,
                   _mainForm.SpaceDeleting(this.textBox3.Text),
                   int.Parse(this.comboBox1.Text)
                );
                _mainForm.StatusOfChange = true;
            }
            else if (_mainForm.Exams[index].GetType() == typeof(FinalExam)) {
                _mainForm.Exams[_index] = new FinalExam(
                   int.Parse(this.textBox1.Text),
                   _mainForm.SpaceDeleting(this.textBox2.Text),
                   this.dateTimePicker1.Text,
                   _mainForm.SpaceDeleting(this.textBox3.Text),
                   int.Parse(this.comboBox1.Text)
                );
                _mainForm.StatusOfChange = true;
            }
            else if (_mainForm.Exams[index].GetType() == typeof(Test)) {
                _mainForm.Exams[_index] = new Test(
                   int.Parse(this.textBox1.Text),
                   _mainForm.SpaceDeleting(this.textBox2.Text),
                   this.dateTimePicker1.Text,
                   _mainForm.SpaceDeleting(this.textBox3.Text),
                   int.Parse(this.textBox4.Text),
                   int.Parse(this.textBox5.Text),
                   int.Parse(this.textBox6.Text),
                   int.Parse(this.textBox7.Text)
                );
                _mainForm.StatusOfChange = true;
            }
        }
        

        private void button1_Click(object sender, EventArgs e) {
            try {
                Editing(_index);
                this.Close();
            }
            catch (Exception trouble) {
                string message = trouble.Message;
                string caption = "Ошибка";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, buttons, icon);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != 8 &&
                (e.KeyChar < 48 || e.KeyChar > 57)) { e.Handled = true; }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != 8 && e.KeyChar != 32 &&
                e.KeyChar != 1025 && e.KeyChar != 1105 &&
                (e.KeyChar < 1040 || e.KeyChar > 1103)) { e.Handled = true; }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != 8 && e.KeyChar != 32 &&
                e.KeyChar != 1025 && e.KeyChar != 1105 &&
                (e.KeyChar < 1040 || e.KeyChar > 1103)) { e.Handled = true; }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != 8 &&
                (e.KeyChar < 48 || e.KeyChar > 57)) { e.Handled = true; }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != 8 &&
                (e.KeyChar < 48 || e.KeyChar > 57)) { e.Handled = true; }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != 8 &&
                (e.KeyChar < 48 || e.KeyChar > 57)) { e.Handled = true; }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != 8 &&
                (e.KeyChar < 48 || e.KeyChar > 57)) { e.Handled = true; }
        }
    }
}
