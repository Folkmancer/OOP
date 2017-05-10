using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.IO;
using System.Xml.Serialization;
using Folkmancer.OOP.ControlOfEducationalProcess;

namespace WFA
{
    public partial class Form1 : Form
    {

        public List<Exam> Exams { set; get; }
        
        public Form1()
        {
            InitializeComponent();
            this.Exams = new List<Exam>();
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
                string message = "You did not enter a server name. Cancel this operation?";
                string caption = "Error Detected in Input";
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
            for (int i = 0; i < this.Exams.Count; i++)
            {
                listView1.Items.Add(Convert.ToString(Exams[i].ID));
                listView1.Items[i].SubItems.Add(Exams[i].NameOfDiscipline);
                listView1.Items[i].SubItems.Add(Exams[i].Date);
                listView1.Items[i].SubItems.Add(Exams[i].NameOfTeacher);
                listView1.Items[i].SubItems.Add(Convert.ToString(Exams[i].Grade));
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Adding();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Adding();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ViewCollection();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
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
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Editing();
        }

        ///МУСОР///
        private void BodyLocalization(ResourceManager Local)
        {
            toolStripButton1.Text = Local.GetString("addButton");
            toolStripMenuItem1.Text = Local.GetString("addButton");
            toolStripButton2.Text = Local.GetString("viewButton");
            toolStripMenuItem2.Text = Local.GetString("viewButton");
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

        private void button1_Click(object sender, EventArgs e)
        {  
            XmlSerializer formatter = new XmlSerializer(typeof(List<Exam>));
            using (FileStream fs = new FileStream("Exams.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Exams);
            }  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("Exams.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Exam>));
                List<Exam> newExams = (List<Exam>)formatter.Deserialize(fs);
                foreach (Exam i in newExams)
                {
                    this.Exams.Insert(this.Exams.Count, i);
                    ViewCollection();
                }
            }
        }
    }
}
