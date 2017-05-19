using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using Folkmancer.OOP.ControlOfEducationalProcess;

namespace Folkmancer.OOP.GUI {
    public partial class Form1 : Form {

        public List<Trial> Exams { set; get; }
        public List<int> UniqId { set; get; }
        public bool StatusOfChange { set; get; }

        public Form1() {
            InitializeComponent();
            this.Exams = new List<Trial>();
            this.UniqId = new List<int>();
            this.StatusOfChange = false; 
            try {
              //  Deserialization();
                huh();
                ViewCollection();
            }
            catch {
                string message = "Вы - пидор!";
                string caption = "Предупреждение!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Hand;
                MessageBox.Show(message, caption, buttons, icon);
            }
        }
     

        public string SpaceDeleting(string line) {
            line = line.Trim();
            while (line.Contains("  ") == true) {
                line = line.Remove(line.IndexOf("  "), 1);
            }
            return line;
        }

        public void Adding() {
            AddForm form = new AddForm(this);
            form.ShowDialog();
        }

        public void Editing() {
            try {
                int index = listView1.FocusedItem.Index;
                EditForm form = new EditForm(this, index);
                form.ShowDialog();
            }
            catch {
                string message = "Отсутствует или не выбрана строка для редактирования!";
                string caption = "Ошибка";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, buttons, icon);
            }
        }

        public void Deleting() {
            try {
                int index = listView1.FocusedItem.Index;
                string message = "Вы уверены, что хотите удалить эту запись?\n" + Exams[index].ToString();
                string caption = "Внимание";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                DialogResult result = MessageBox.Show(message, caption, buttons, icon);
                if (result == DialogResult.Yes) {
                    listView1.Items[index].Remove();
                    Exams.RemoveAt(index);
                }
            }
            catch {
                string message = "Отсутствует или не выбрана строка для удаления!";
                string caption = "Ошибка";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, buttons, icon);
            }
        }

        public void Help() {
            string message = (
                "Добавление\n" +
                "Кнопка \"Добавить\" открывает дополнительную форму ввода данных.\n" +
                "При добавлении необходимо заполнить все доступные поля.\n" +
                "\nУдаление\n" +
                "Кнопка \"Удалить\" удаляет выбранную запись из таблицы.\n" +
                "\nРедактирование\n" +
                "Кнопка \"Редактировать\" открывает дополнительную форму " +
                "для редактирования выбранной записи из таблицы.\n"
            );
            string caption = "Справка";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;
            MessageBox.Show(message, caption, buttons, icon);
        }

        public void ViewCollection() {
            listView1.Clear();
            listView1.Columns.Add("Идентификатор");
            listView1.Columns[0].Width = 100;
            listView1.Columns.Add("Предмет");
            listView1.Columns[1].Width = 120;
            listView1.Columns.Add("Дата");
            listView1.Columns[2].Width = 80;
            listView1.Columns.Add("Преподаватель");
            listView1.Columns[3].Width = 120;
            listView1.Columns.Add("Оценка");
            listView1.Columns[4].Width = 50;
            listView1.Columns.Add("Тип");
            listView1.Columns[5].Width = 120;
            for (int i = 0; i < this.Exams.Count; i++) {
                if (this.Exams[i].GetType() == typeof(Exam)) {
                    Exam Temp = (Exam)this.Exams[i];
                    listView1.Items.Add(Convert.ToString(Temp.ID));
                    listView1.Items[i].SubItems.Add(Temp.NameOfDiscipline);
                    listView1.Items[i].SubItems.Add(Temp.Date);
                    listView1.Items[i].SubItems.Add(Temp.NameOfTeacher);
                    listView1.Items[i].SubItems.Add(Convert.ToString(Temp.Grade));
                    listView1.Items[i].SubItems.Add("Экзамен");
                }
                else if (this.Exams[i].GetType() == typeof(FinalExam)) {
                    FinalExam Temp = (FinalExam)this.Exams[i];
                    listView1.Items.Add(Convert.ToString(Temp.ID));
                    listView1.Items[i].SubItems.Add(Temp.NameOfDiscipline);
                    listView1.Items[i].SubItems.Add(Temp.Date);
                    listView1.Items[i].SubItems.Add(Temp.NameOfTeacher);
                    listView1.Items[i].SubItems.Add(Convert.ToString(Temp.Grade));
                    listView1.Items[i].SubItems.Add("Выпускной экзамен");
                }
                else if (this.Exams[i].GetType() == typeof(Test)) {
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


        public void Serialization() {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Trial>));
            using (FileStream data = new FileStream("Table.xml", FileMode.OpenOrCreate)) {
                formatter.Serialize(data, Exams);
            }
        }

        public void Deserialization() {
            using (FileStream data = new FileStream("Table.xml", FileMode.OpenOrCreate)) {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Trial>));
                List<Trial> listObj = (List<Trial>)formatter.Deserialize(data);
                foreach (Trial i in listObj) {
                    this.Exams.Insert(this.Exams.Count, i);
                    this.UniqId.Insert(this.UniqId.Count, i.ID);
                }
            } 
        }

        public void huh() {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "xml files (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                try {
                    if ((openFileDialog1.OpenFile()) != null) {
                        using (FileStream data = File.OpenRead(openFileDialog1.FileName)) {
                            XmlSerializer formatter = new XmlSerializer(typeof(List<Trial>));
                            List<Trial> listObj = (List<Trial>)formatter.Deserialize(data);
                            foreach (Trial i in listObj) {
                                this.Exams.Insert(this.Exams.Count, i);
                                this.UniqId.Insert(this.UniqId.Count, i.ID);
                            }
                        }
                    } 
                }
                catch (Exception ex) {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        public void huh1() {
            SaveFileDialog openFileDialog1 = new SaveFileDialog();
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "XML files (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                try {
                    using (FileStream data = File.OpenWrite(openFileDialog1.FileName)) {
                        XmlSerializer formatter = new XmlSerializer(typeof(List<Trial>));
                        formatter.Serialize(data, Exams);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            Adding();
            ViewCollection();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            Adding();
            ViewCollection();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) {
            Deleting();
            ViewCollection();
        }

        private void toolStripButton2_Click(object sender, EventArgs e) {
            Deleting();
            ViewCollection();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e) {
            Editing();
            ViewCollection();
        }

        private void toolStripButton3_Click(object sender, EventArgs e) {
            Editing();
            ViewCollection();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e) {
            Help();
        }

        private void toolStripButton4_Click(object sender, EventArgs e) {
            Help();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            if (StatusOfChange == true) {
                string message = "Хотите ли вы сохранить изменения?";
                string caption = "Внимание";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                DialogResult result = MessageBox.Show(message, caption, buttons, icon);
            //    if (result == DialogResult.Yes) { Serialization(); }
               // if (result == DialogResult.Yes) { huh1(); }
                
            }
            huh1();
        }
    }
}
