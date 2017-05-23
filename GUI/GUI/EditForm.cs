using System;
using System.Windows.Forms;
using System.Collections.Generic;

using Folkmancer.OOP.ControlOfEducationalProcess;

namespace Folkmancer.OOP.GUI {
    public partial class EditForm : Form {
        private Form1 _mainForm;
        private List<Trial> _listElements;
        private List<int> _keys;
        private int _index;

        public EditForm(Form1 mainForm, int index) {
            InitializeComponent();
            _mainForm = mainForm;
            _listElements = mainForm.ListElements;
            _keys = mainForm.UniqId;
            _index = index;
            Initiate(_index);
        }


        //==============================Methods==============================//
        private void Initiate(int index) {
            if (_listElements[index].GetType() == typeof(Exam)) {
                Exam Temp = (Exam)_listElements[index];
                comboBox1.Enabled = true;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox1.Text = Temp.ID.ToString();
                textBox2.Text = Temp.NameOfDiscipline;
                dateTimePicker1.Text = Temp.Date;
                textBox3.Text = Temp.NameOfTeacher;
                comboBox1.Text = Temp.Grade.ToString();
            }
            else if (_listElements[index].GetType() == typeof(FinalExam)) {
                FinalExam Temp = (FinalExam)_listElements[index];
                comboBox1.Enabled = true;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox1.Text = Temp.ID.ToString();
                textBox2.Text = Temp.NameOfDiscipline;
                dateTimePicker1.Text = Temp.Date;
                textBox3.Text = Temp.NameOfTeacher;
                comboBox1.Text = Temp.Grade.ToString();
            }
            else if (_listElements[index].GetType() == typeof(Test)) {
                Test Temp = (Test)_listElements[index];
                comboBox1.Enabled = false;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox1.Text = Temp.ID.ToString();
                textBox2.Text = Temp.NameOfDiscipline;
                dateTimePicker1.Text = Temp.Date;
                textBox3.Text = Temp.NameOfTeacher;
                textBox4.Text = Temp.Points.ToString();
                textBox5.Text = Temp.PointsForThree.ToString();
                textBox6.Text = Temp.PointsForFour.ToString();
                textBox7.Text = Temp.PointsForFive.ToString();    
            }
        }

        private void Editing() {
            if (textBox1.Text == "") { throw new FormatException("Введите идентификатор."); }
            if (_listElements[_index].ID != int.Parse(textBox1.Text)) {
                if (_keys.Contains(int.Parse(textBox1.Text))) { throw new FormatException("Такой идентификатор уже существует."); }
            }
            if ((_mainForm.SpaceDeleting(textBox2.Text)) == "") { throw new FormatException("Введите предмет."); }
            if ((_mainForm.SpaceDeleting(textBox3.Text)) == "") { throw new FormatException("Введите преподавателя."); }
            if (comboBox1.Enabled == true) {
                if (comboBox1.Text == "") { throw new FormatException("Введите оценку."); }
            }
            if (textBox4.Enabled == true) {
                if (textBox4.Text == "") { throw new FormatException("Введите баллы."); }
                if (textBox5.Text == "") { throw new FormatException("Введите баллы на тройку."); }
                if (textBox6.Text == "") { throw new FormatException("Введите баллы на четвёрку."); }
                if (textBox7.Text == "") { throw new FormatException("Введите баллы на пятёрку."); }
            }
            if (_listElements[_index].GetType() == typeof(Exam)) {
                _listElements[_index] = new Exam(
                   int.Parse(textBox1.Text),
                   _mainForm.SpaceDeleting(textBox2.Text),
                   dateTimePicker1.Text,
                   _mainForm.SpaceDeleting(textBox3.Text),
                   int.Parse(comboBox1.Text)
                );
                _keys.Insert(_index, (int.Parse(textBox1.Text)));
                _mainForm.StatusOfChange = true;
            }
            else if (_listElements[_index].GetType() == typeof(FinalExam)) {
                _listElements[_index] = new FinalExam(
                   int.Parse(textBox1.Text),
                   _mainForm.SpaceDeleting(textBox2.Text),
                   dateTimePicker1.Text,
                   _mainForm.SpaceDeleting(textBox3.Text),
                   int.Parse(comboBox1.Text)
                );
                _keys.Insert(_index, (int.Parse(textBox1.Text)));
                _mainForm.StatusOfChange = true;
            }
            else if (_listElements[_index].GetType() == typeof(Test)) {
                _listElements[_index] = new Test(
                   int.Parse(textBox1.Text),
                   _mainForm.SpaceDeleting(textBox2.Text),
                   dateTimePicker1.Text,
                   _mainForm.SpaceDeleting(textBox3.Text),
                   int.Parse(textBox4.Text),
                   int.Parse(textBox5.Text),
                   int.Parse(textBox6.Text),
                   int.Parse(textBox7.Text)
                );
                _keys.Insert(_index, (int.Parse(textBox1.Text)));
                _mainForm.StatusOfChange = true;
            }
        }
        
        private void restrictDigit(KeyPressEventArgs e) {
            if (e.KeyChar != 8 &&
                (e.KeyChar < 48 || e.KeyChar > 57)) { e.Handled = true; }
        }

        private void restrictText(KeyPressEventArgs e) {
            if (e.KeyChar != 8 && e.KeyChar != 32 &&
                 e.KeyChar != 1025 && e.KeyChar != 1105 &&
                 (e.KeyChar < 1040 || e.KeyChar > 1103)) { e.Handled = true; }
        }


        //==============================Events==============================//
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            restrictDigit(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) {
            restrictText(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) {
            restrictText(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e) {
            restrictDigit(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e) {
            restrictDigit(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e) {
            restrictDigit(e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e) {
            restrictDigit(e);
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                Editing();
                Close();
            }
            catch (OverflowException) {
                string message = "Выход значения за возможный диапазон";
                string caption = "Ошибка";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, buttons, icon);
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
            Close();
        }
    }
}
