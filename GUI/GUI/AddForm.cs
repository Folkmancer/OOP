using System;
using System.Windows.Forms;

using Folkmancer.OOP.ControlOfEducationalProcess;

namespace Folkmancer.OOP.GUI {
    public partial class AddForm : Form {
        private Form1 _mainForm;

        public AddForm(Form1 MainForm) {
            InitializeComponent();
            _mainForm = MainForm;
            this.comboBox2.SelectedIndex = 0;
        }


        private void Adding(int index) {
            if (this.textBox1.Text == "") { throw new FormatException("Введите идентификатор."); }
            if (_mainForm.UniqId.Contains(int.Parse(this.textBox1.Text))) { throw new FormatException("Такой идентификатор уже существует."); }
            if ((this._mainForm.SpaceDeleting(this.textBox2.Text)) == "") { throw new FormatException("Введите предмет."); }
            if ((this._mainForm.SpaceDeleting(this.textBox3.Text)) == "") { throw new FormatException("Введите преподавателя."); }
            if (this.comboBox1.Enabled == true) {
                if (this.comboBox1.Text == "") {  throw new FormatException("Введите оценку."); }
            }
            if (this.textBox4.Enabled == true) {
                if (this.textBox4.Text == "") {  throw new FormatException("Введите баллы."); }
                if (this.textBox5.Text == "") {  throw new FormatException("Введите баллы на тройку."); }
                if (this.textBox6.Text == "") {  throw new FormatException("Введите баллы на четвёрку."); }
                if (this.textBox7.Text == "") {  throw new FormatException("Введите баллы на пятёрку."); }
            }
            switch (index) {
                case 0:
                    _mainForm.Exams.Insert(_mainForm.Exams.Count,
                        new Exam(
                            int.Parse(this.textBox1.Text),
                            _mainForm.SpaceDeleting(this.textBox2.Text),
                            this.dateTimePicker1.Text,
                            _mainForm.SpaceDeleting(this.textBox3.Text),
                            int.Parse(this.comboBox1.Text)
                    ));
                    _mainForm.UniqId.Add(int.Parse(this.textBox1.Text));
                    _mainForm.StatusOfChange = true;
                    break;
                case 1:
                    _mainForm.Exams.Insert(_mainForm.Exams.Count,
                       new FinalExam(
                           int.Parse(this.textBox1.Text),
                           _mainForm.SpaceDeleting(this.textBox2.Text),
                           this.dateTimePicker1.Text,
                           _mainForm.SpaceDeleting(this.textBox3.Text),
                           int.Parse(this.comboBox1.Text)
                    ));
                    _mainForm.UniqId.Add(int.Parse(this.textBox1.Text));
                    _mainForm.StatusOfChange = true;
                    break;
                case 2:
                    _mainForm.Exams.Insert(_mainForm.Exams.Count,
                        new Test(
                            int.Parse(this.textBox1.Text),
                            _mainForm.SpaceDeleting(this.textBox2.Text),
                            this.dateTimePicker1.Text,
                            _mainForm.SpaceDeleting(this.textBox3.Text),
                            int.Parse(this.textBox4.Text),
                            int.Parse(this.textBox5.Text),
                            int.Parse(this.textBox6.Text),
                            int.Parse(this.textBox7.Text)
                    ));
                    _mainForm.UniqId.Add(int.Parse(this.textBox1.Text));
                    _mainForm.StatusOfChange = true;
                    break;
                default:
                    throw new Exception("Неизвестная ошибка!");
            }
        }


        private void button1_Click(object sender, EventArgs e) {
            try {
                int index = this.comboBox2.SelectedIndex;
                Adding(index);
                this.Close();
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
            this.Close();
        }

        private void comboBox2_TextChanged(object sender, EventArgs e) {
            if (this.comboBox2.SelectedIndex == 2) {
                this.textBox4.Enabled = true;
                this.textBox5.Enabled = true;
                this.textBox6.Enabled = true;
                this.textBox7.Enabled = true;
                this.comboBox1.Enabled = false;
            }
            else {
                this.textBox4.Enabled = false;
                this.textBox5.Enabled = false;
                this.textBox6.Enabled = false;
                this.textBox7.Enabled = false;
                this.comboBox1.Enabled = true;
            }
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