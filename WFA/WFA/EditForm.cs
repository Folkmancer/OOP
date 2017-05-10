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
    public partial class EditForm : Form
    {
        private Form1 _mainForm;
        private int _index;

        public EditForm(Form1 F, int index)
        {
            InitializeComponent();
            this._mainForm = F;
            this._index = index;
            this.textBox1.Text = _mainForm.Exams[index].ID.ToString();
            this.textBox2.Text = _mainForm.Exams[index].NameOfDiscipline;
            this.dateTimePicker1.Text = _mainForm.Exams[index].Date;
            this.textBox3.Text = _mainForm.Exams[index].NameOfTeacher;
            this.comboBox1.Text = _mainForm.Exams[index].Grade.ToString();
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
                _mainForm.ViewCollection();
            }
            else throw new Exception("Поля не могут быть пустыми или нулевыми!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditExam(
                int.Parse(this.textBox1.Text), 
                this.textBox2.Text, 
                this.dateTimePicker1.Text, 
                this.textBox3.Text, 
                int.Parse(this.comboBox1.Text)
            );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
