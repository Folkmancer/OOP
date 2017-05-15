using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Folkmancer.OOP.ControlOfEducationalProcess;

namespace Folkmancer.OOP.GUI
{
    public partial class AddForm : Form
    {
        private Form1 _mainForm;

        public AddForm(Form1 MainForm)
        {
            InitializeComponent();
            _mainForm = MainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Adding();
                this.Close();
            }
            catch (Exception trouble)
            {
                string message = trouble.Message;
                string caption = "Предупреждение!";
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Adding()
        {
            try
            {
                int index = this.comboBox2.SelectedIndex;
                switch (index)
                {
                    case 0:
                        AddExam(
                            int.Parse(this.textBox1.Text),
                            this.textBox2.Text,
                            this.dateTimePicker1.Text,
                            this.textBox3.Text,
                            int.Parse(this.comboBox1.Text)
                        );
                        break;
                    case 1:
                        AddFInalExam(
                            int.Parse(this.textBox1.Text),
                            this.textBox2.Text,
                            this.dateTimePicker1.Text,
                            this.textBox3.Text,
                            int.Parse(this.comboBox1.Text)
                        );
                        break;
                    case 2:
                        AddTest(
                            int.Parse(this.textBox1.Text),
                            this.textBox2.Text,
                            this.dateTimePicker1.Text,
                            this.textBox3.Text,
                            int.Parse(this.textBox4.Text),
                            int.Parse(this.textBox5.Text),
                            int.Parse(this.textBox6.Text),
                            int.Parse(this.textBox7.Text)

                        );
                        break;
                    default:
                        throw new Exception("Не выбран тип!");
                }
                this.Close();
            }
            catch (Exception trouble)
            {
                string message = trouble.Message;
                string caption = "Предупреждение!";
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
        }

        private void AddExam(int ID, string NOD, string Date, string NOT, int Grade)
        {
            if ((ID != 0) && (NOD != "") && (Date != "") && (NOT != "") && (Grade != 0))
            {
                _mainForm.Exams.Insert(_mainForm.Exams.Count,
                    new Exam(
                        ID,
                        NOD,
                        Date,
                        NOT,
                        Grade
                ));
            }
            else throw new Exception("Поля не могут быть пустыми или нулевыми!");
        }
        private void AddFInalExam(int ID, string NOD, string Date, string NOT, int Grade)
        {
            if ((ID != 0) && (NOD != "") && (Date != "") && (NOT != "") && (Grade != 0))
            {
                _mainForm.Exams.Insert(_mainForm.Exams.Count,
                    new FinalExam(
                        ID,
                        NOD,
                        Date,
                        NOT,
                        Grade
                ));
            }
            else throw new Exception("Поля не могут быть пустыми или нулевыми!");
        }
        private void AddTest(int ID, string NOD, string Date, string NOT, int Point, int Pft, int Pffo, int Pffi)
        {
            if ((ID != 0) && (NOD != "") && (Date != "") && (NOT != "")
                && (Point != 0) && (Pft != 0) && (Pffo != 0) && (Pffi != 0))
            {
                _mainForm.Exams.Insert(_mainForm.Exams.Count,
                    new Test(
                        ID,
                        NOD,
                        Date,
                        NOT,
                        Point,
                        Pft,
                        Pffo,
                        Pffi
                ));
            }
            else throw new Exception("Поля не могут быть пустыми или нулевыми!");
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (this.comboBox2.SelectedIndex == 2)
            {
                this.textBox4.Enabled = true;
                this.textBox5.Enabled = true;
                this.textBox6.Enabled = true;
                this.textBox7.Enabled = true;
                this.comboBox1.Enabled = false;
            }
            else
            {
                this.textBox4.Enabled = false;
                this.textBox5.Enabled = false;
                this.textBox6.Enabled = false;
                this.textBox7.Enabled = false;
                this.comboBox1.Enabled = true;
            }
        }
    }
}