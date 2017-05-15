using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Resources;
using System.IO;
using System.Xml.Serialization;
using Folkmancer.OOP.ControlOfEducationalProcess;

namespace WFA
{
    public partial class Form1 : Form
    {

        public List<Trial> Exams { set; get; }
        
        public Form1()
        {
            InitializeComponent();
            this.Exams = new List<Trial>();
            try
            {
                DeSerialization();
                ViewCollection();
            }
            catch
            {
                string message = "Не удалось открыть файл!";
                string caption = "Предупреждение!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
        }
     

        public void Adding()
        {
            AddForm newForm = new AddForm(this);
            newForm.ShowDialog();
        }

        public void Editing()
        {
            try
            {
                int index = listView1.FocusedItem.Index;
                EditForm newForm = new EditForm(this, index);
                newForm.ShowDialog();
            }
            catch
            {
                string message = "Отсутствует или не выбрана строка для редактирования!";
                string caption = "Предупреждение!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
        }

        public void Serialization()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Trial>));
            using (FileStream fs = new FileStream("Table.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Exams);
            }
        }

        public void DeSerialization()
        {
            using (FileStream fs = new FileStream("Table.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Trial>));
                List<Trial> newExams = (List<Trial>)formatter.Deserialize(fs);
                foreach (Trial i in newExams)
                {
                    this.Exams.Insert(this.Exams.Count, i);
                }
            }
        }
       
        public void Deleting()
        {
            try
            {
                int delIndex = listView1.FocusedItem.Index;
                string message = "Вы уверены, что хотите удалить эту запись?";
                string caption = "Предупреждение!";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    listView1.Items[delIndex].Remove();
                    Exams.RemoveAt(delIndex);
                }
            }
            catch
            {
                string message = "Отсутствует или не выбрана строка для удаления!";
                string caption = "Предупреждение!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBox.Show(message, caption, buttons);
            }
        }

        public void ViewCollection()
        {
            listView1.Clear();
            listView1.Columns.Add("Идентификатор");
            listView1.Columns.Add("Предмет");
            listView1.Columns.Add("Дата");
            listView1.Columns.Add("Преподаватель");
            listView1.Columns.Add("Оценка");
            listView1.Columns.Add("Тип");
            for (int i = 0; i < this.Exams.Count; i++)
            {
                if (this.Exams[i].GetType() == typeof(Exam))
                {
                    Exam Temp = (Exam)this.Exams[i];
                    listView1.Items.Add(Convert.ToString(Temp.ID));
                    listView1.Items[i].SubItems.Add(Temp.NameOfDiscipline);
                    listView1.Items[i].SubItems.Add(Temp.Date);
                    listView1.Items[i].SubItems.Add(Temp.NameOfTeacher);
                    listView1.Items[i].SubItems.Add(Convert.ToString(Temp.Grade));
                    listView1.Items[i].SubItems.Add("Экзамен");
                }
                else if (this.Exams[i].GetType() == typeof(FinalExam))
                {
                    FinalExam Temp = (FinalExam)this.Exams[i];
                    listView1.Items.Add(Convert.ToString(Temp.ID));
                    listView1.Items[i].SubItems.Add(Temp.NameOfDiscipline);
                    listView1.Items[i].SubItems.Add(Temp.Date);
                    listView1.Items[i].SubItems.Add(Temp.NameOfTeacher);
                    listView1.Items[i].SubItems.Add(Convert.ToString(Temp.Grade));
                    listView1.Items[i].SubItems.Add("Выпускной экзамен");
                }
                else if (this.Exams[i].GetType() == typeof(Test))
                {
                    Test Temp = (Test)this.Exams[i];
                    listView1.Items.Add(Convert.ToString(Temp.ID));
                    listView1.Items[i].SubItems.Add(Temp.NameOfDiscipline);
                    listView1.Items[i].SubItems.Add(Temp.Date);
                    listView1.Items[i].SubItems.Add(Temp.NameOfTeacher);
                    listView1.Items[i].SubItems.Add(Convert.ToString(Temp.GetGrade()));
                    listView1.Items[i].SubItems.Add("Тест");
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Adding();
            ViewCollection();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Adding();
            ViewCollection();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Deleting();
            ViewCollection();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Deleting();
            ViewCollection();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Editing();
            ViewCollection();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Editing();
            ViewCollection();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Serialization();
        }

        ///МУСОР///
        private void BodyLocalization(ResourceManager Local)
        {
            toolStripButton1.Text = Local.GetString("addButton");
            toolStripMenuItem1.Text = Local.GetString("addButton");
            toolStripButton3.Text = Local.GetString("deleteButton");
            toolStripMenuItem3.Text = Local.GetString("deleteButton");
            toolStripButton4.Text = Local.GetString("editButton");
            toolStripMenuItem4.Text = Local.GetString("editButton");
            toolStripButton5.Text = Local.GetString("helpButton");
            toolStripMenuItem5.Text = Local.GetString("helpButton");
            toolStripDropDownButton1.Text = Local.GetString("langButton");
            toolStripMenuItem6.Text = Local.GetString("langButton");
        }

        private void LocalizationRU()
        {
            BodyLocalization(new ResourceManager("WFA.LocalizationStrings", typeof(Form1).Assembly));
        }

        private void LocalizationEN()
        {

            BodyLocalization(new ResourceManager("WFA.LocalizationStrings.en_EN", typeof(Form1).Assembly));
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            LocalizationRU();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            LocalizationEN();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            LocalizationRU();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            LocalizationEN();
        }
    }
}
