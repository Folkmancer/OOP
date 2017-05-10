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

namespace WFA
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
                AddExam(
                    int.Parse(this.textBox1.Text),
                    this.textBox2.Text,
                    this.dateTimePicker1.Text,
                    this.textBox3.Text,
                    int.Parse(this.comboBox1.Text)
                );
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
                _mainForm.ViewCollection();
            }
            else throw new Exception("Поля не могут быть пустыми или нулевыми!");
        }
    }
}