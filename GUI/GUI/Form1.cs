using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using Folkmancer.OOP.ControlOfEducationalProcess;

namespace Folkmancer.OOP.GUI {
    public partial class Form1 : Form {

        private string _pathXmlFile;
        public bool StatusOfChange { set; get; }
        public List<Trial> Exams { set; get; }
        public List<int> UniqId { set; get; }
 

        public Form1() {
            InitializeComponent();
            this.Exams = new List<Trial>();
            this.UniqId = new List<int>();
            this.StatusOfChange = false;
            this._pathXmlFile = "";
            this.listView1.Enabled = false;
            this.saveToolStripMenuItem.Enabled = false;
            this.saveHowToolStripMenuItem.Enabled = false;
            this.addToolStripMenuItem.Enabled = false;
            this.delToolStripMenuItem.Enabled = false;
            this.editingToolStripMenuItem.Enabled = false;
            ViewCollection(); 
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

        private void Create() {
            this.listView1.Enabled = true;
            this.saveToolStripMenuItem.Enabled = true;
            this.saveHowToolStripMenuItem.Enabled = true;
            this.addToolStripMenuItem.Enabled = true;
            this.delToolStripMenuItem.Enabled = true;
            this.editingToolStripMenuItem.Enabled = true;
        }

        public void ViewCollection() {
            listView1.Clear();
            listView1.Columns.Add("Идентификатор");
            listView1.Columns[0].Width = 100;
            listView1.Columns.Add("Предмет");
            listView1.Columns[1].Width = 115;
            listView1.Columns.Add("Дата");
            listView1.Columns[2].Width = 80;
            listView1.Columns.Add("Преподаватель");
            listView1.Columns[3].Width = 115;
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


        public void OpenFile() {
            OpenFileDialog XmlDataFile = new OpenFileDialog();
            XmlDataFile.InitialDirectory = Application.StartupPath;
            XmlDataFile.Filter = "xml files (*.xml)|*.xml";
            XmlDataFile.FilterIndex = 0;
            XmlDataFile.RestoreDirectory = true;
            if (XmlDataFile.ShowDialog() == DialogResult.OK) {
                try {
                    if ((XmlDataFile.OpenFile()) != null) {
                        using (FileStream fStream = File.OpenRead(XmlDataFile.FileName)) {
                            XmlSerializer formatter = new XmlSerializer(typeof(List<Trial>));
                            List<Trial> listObj = (List<Trial>)formatter.Deserialize(fStream);
                            this.Exams.Clear();
                            this.UniqId.Clear();
                            foreach (Trial i in listObj) {
                                this.Exams.Insert(this.Exams.Count, i);
                                this.UniqId.Insert(this.UniqId.Count, i.ID);
                            }
                            fStream.Close();
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Ошибка: невозможно прочитать файл с диска. Original error: " + ex.Message);
                }
                _pathXmlFile = XmlDataFile.FileName;
            }
        }

        public void SaveFile(string path) {
            if (path != "") {
                try {
                    XmlSerializer formatter = new XmlSerializer(typeof(List<Trial>));
                    using (FileStream fStream = new FileStream(path, FileMode.Create)) {
                        formatter.Serialize(fStream, Exams);
                        fStream.Close();
                    }   
                }
                catch (Exception ex) {
                    MessageBox.Show("Ошибка: невозможно прочитать файл с диска. Original error: " + ex.Message);
                }
                this.StatusOfChange = false;
            }
        }
        
        public void SaveHowFile() {
            SaveFileDialog XmlDataFile = new SaveFileDialog();
            XmlDataFile.InitialDirectory = Application.StartupPath;
            XmlDataFile.Filter = "XML files (*.xml)|*.xml";
            XmlDataFile.FilterIndex = 0;
            XmlDataFile.RestoreDirectory = true;
            if (XmlDataFile.ShowDialog() == DialogResult.OK) {
                try {
                    XmlSerializer formatter = new XmlSerializer(typeof(List<Trial>));
                    using (FileStream fStream = File.OpenWrite(XmlDataFile.FileName)) {
                        formatter.Serialize(fStream, Exams);
                        fStream.Close();
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Ошибка: невозможно прочитать файл с диска. Original error: " + ex.Message);
                }
            }
            this._pathXmlFile = XmlDataFile.FileName;
            this.StatusOfChange = false;
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFile();
            Create();
            ViewCollection();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this._pathXmlFile != "") { SaveFile(this._pathXmlFile); }
            else { SaveHowFile(); }
        }

        private void saveHowToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveHowFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e) {
            Adding();
            ViewCollection();
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e) {
            Deleting();
            ViewCollection();
            this.StatusOfChange = true;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            Editing();
            ViewCollection();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
            Help();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e) {
            Create();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            if (this.StatusOfChange == true) {
                string message = "Хотите ли вы сохранить изменения?";
                string caption = "Внимание";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                DialogResult result = MessageBox.Show(message, caption, buttons, icon);
                if (result == DialogResult.Yes) {
                    if (this._pathXmlFile != "") { SaveFile(this._pathXmlFile); }
                    else { SaveHowFile(); }
                }
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e) {
            this.listView1.Columns[0].Width = (int)((this.listView1.Size.Width) * 0.16);
            this.listView1.Columns[1].Width = (int)((this.listView1.Size.Width) * 0.2);
            this.listView1.Columns[2].Width = (int)((this.listView1.Size.Width) * 0.14);
            this.listView1.Columns[3].Width = (int)((this.listView1.Size.Width) * 0.2);
            this.listView1.Columns[4].Width = (int)((this.listView1.Size.Width) * 0.09);
            this.listView1.Columns[5].Width = (int)((this.listView1.Size.Width) * 0.21);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutBox1 AboutForm = new AboutBox1();
            AboutForm.ShowDialog();
        }
    }
}
