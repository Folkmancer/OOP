using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using Folkmancer.OOP.ControlOfEducationalProcess;

namespace Folkmancer.OOP.GUI {
    public partial class Form1 : Form {

        private string _pathXmlFile;
        private bool[] _switches = { false, false, false, false, false, false };
        public bool StatusOfChange { set; get; }
        public List<Trial> ListElements { set; get; }
        public List<int> UniqId { set; get; }
 

        public Form1() {
            InitializeComponent();
            _pathXmlFile = "";
            StatusOfChange = false;
            ListElements = new List<Trial>();
            UniqId = new List<int>();
            listView1.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            saveHowToolStripMenuItem.Enabled = false;
            addToolStripMenuItem.Enabled = false;
            delToolStripMenuItem.Enabled = false;
            editingToolStripMenuItem.Enabled = false;
            ViewCollection();
        }


        //==============================Methods==============================//
        private void Create() {
            listView1.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            saveHowToolStripMenuItem.Enabled = true;
            addToolStripMenuItem.Enabled = true;
            delToolStripMenuItem.Enabled = true;
            editingToolStripMenuItem.Enabled = true;
        }

        public void Adding() {
            AddForm addForm = new AddForm(this);
            addForm.ShowDialog();
        }

        public void Editing() {
            try {
                int index = listView1.FocusedItem.Index;
                EditForm editForm = new EditForm(this, index);
                editForm.ShowDialog();
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
                string message = "Вы уверены, что хотите удалить эту запись?\n" + ListElements[index].ToString();
                string caption = "Внимание";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                DialogResult result = MessageBox.Show(message, caption, buttons, icon);
                if (result == DialogResult.Yes) {
                    listView1.Items[index].Remove();
                    ListElements.RemoveAt(index);
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
            listView1.Columns.Add("Предмет");
            listView1.Columns.Add("Дата");
            listView1.Columns.Add("Преподаватель");
            listView1.Columns.Add("Оценка");
            listView1.Columns.Add("Тип");
            listView1.Columns[0].Width = 100;
            listView1.Columns[1].Width = 115;
            listView1.Columns[2].Width = 80;
            listView1.Columns[3].Width = 115;
            listView1.Columns[4].Width = 50;
            listView1.Columns[5].Width = 120;
            for (int i = 0; i < ListElements.Count; i++) {
                if (ListElements[i].GetType() == typeof(Exam)) {
                    Exam temp = (Exam)ListElements[i];
                    listView1.Items.Add(Convert.ToString(temp.ID));
                    listView1.Items[i].SubItems.Add(temp.NameOfDiscipline);
                    listView1.Items[i].SubItems.Add(temp.Date);
                    listView1.Items[i].SubItems.Add(temp.NameOfTeacher);
                    listView1.Items[i].SubItems.Add(Convert.ToString(temp.Grade));
                    listView1.Items[i].SubItems.Add("Экзамен");
                }
                else if (ListElements[i].GetType() == typeof(FinalExam)) {
                    FinalExam temp = (FinalExam)ListElements[i];
                    listView1.Items.Add(Convert.ToString(temp.ID));
                    listView1.Items[i].SubItems.Add(temp.NameOfDiscipline);
                    listView1.Items[i].SubItems.Add(temp.Date);
                    listView1.Items[i].SubItems.Add(temp.NameOfTeacher);
                    listView1.Items[i].SubItems.Add(Convert.ToString(temp.Grade));
                    listView1.Items[i].SubItems.Add("Выпускной экзамен");
                }
                else if (ListElements[i].GetType() == typeof(Test)) {
                    Test temp = (Test)ListElements[i];
                    listView1.Items.Add(Convert.ToString(temp.ID));
                    listView1.Items[i].SubItems.Add(temp.NameOfDiscipline);
                    listView1.Items[i].SubItems.Add(temp.Date);
                    listView1.Items[i].SubItems.Add(temp.NameOfTeacher);
                    listView1.Items[i].SubItems.Add(Convert.ToString(temp.GetGrade()));
                    listView1.Items[i].SubItems.Add("Тест");
                }
            }
        }

        public string SpaceDeleting(string line) {
            line = line.Trim();
            while (line.Contains("  ") == true) {
                line = line.Remove(line.IndexOf("  "), 1);
            }
            return line;
        }


        //==============================Work with table==============================//
        private void SortTable(ColumnClickEventArgs e) {
            switch (e.Column) {
                case 0:
                    if (_switches[0] == false) {
                        ListElements.Sort((a, b) => b.ID.CompareTo(a.ID));
                        _switches[0] = true;
                    }
                    else {
                        ListElements.Sort((a, b) => a.ID.CompareTo(b.ID));
                        _switches[0] = false;
                    }
                    break;
                case 1:
                    if (_switches[1] == false) {
                        ListElements.Sort((a, b) => b.NameOfDiscipline.CompareTo(a.NameOfDiscipline));
                        _switches[1] = true;
                    }
                    else {
                        ListElements.Sort((a, b) => a.NameOfDiscipline.CompareTo(b.NameOfDiscipline));
                        _switches[1] = false;
                    }
                    break;
                case 2:
                    if (_switches[2] == false) {
                        ListElements.Sort((a, b) => b.Date.CompareTo(a.Date));
                        _switches[2] = true;
                    }
                    else {
                        ListElements.Sort((a, b) => a.Date.CompareTo(b.Date));
                        _switches[2] = false;
                    }
                    break;
                case 3:
                    if (_switches[3] == false) {
                        ListElements.Sort((a, b) => b.NameOfTeacher.CompareTo(a.NameOfTeacher));
                        _switches[3] = true;
                    }
                    else {
                        ListElements.Sort((a, b) => a.NameOfTeacher.CompareTo(b.NameOfTeacher));
                        _switches[3] = false;
                    }
                    break;
                case 4:
                    if (_switches[4] == false) {
                        ListElements.Sort((a, b) => b.GetGrade().CompareTo(a.GetGrade()));
                        _switches[4] = true;
                    }
                    else {
                        ListElements.Sort((a, b) => a.GetGrade().CompareTo(b.GetGrade()));
                        _switches[4] = false;
                    }
                    break;
                case 5:
                    if (_switches[5] == false) {
                        ListElements.Sort((a, b) => b.TypeOfTrial().CompareTo(a.TypeOfTrial()));
                        _switches[5] = true;
                    }
                    else {
                        ListElements.Sort((a, b) => a.TypeOfTrial().CompareTo(b.TypeOfTrial()));
                        _switches[5] = false;
                    }
                    break;
                default:
                    string message = "Что-то пошло не так!";
                    string caption = "Ошибка";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBox.Show(message, caption, buttons, icon);
                    break;
            }
        }

        private void SizeChangeTable() {
            listView1.Columns[0].Width = (int)((listView1.Size.Width) * 0.16);
            listView1.Columns[1].Width = (int)((listView1.Size.Width) * 0.2);
            listView1.Columns[2].Width = (int)((listView1.Size.Width) * 0.14);
            listView1.Columns[3].Width = (int)((listView1.Size.Width) * 0.2);
            listView1.Columns[4].Width = (int)((listView1.Size.Width) * 0.09);
            listView1.Columns[5].Width = (int)((listView1.Size.Width) * 0.21);
        }


        //==============================Work with file==============================//
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
                            ListElements.Clear();
                            UniqId.Clear();
                            foreach (Trial i in listObj) {
                                ListElements.Insert(ListElements.Count, i);
                                UniqId.Insert(UniqId.Count, i.ID);
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

        public void SaveFile() {
            if (_pathXmlFile != "") {
                try {
                    XmlSerializer formatter = new XmlSerializer(typeof(List<Trial>));
                    using (FileStream fStream = new FileStream(_pathXmlFile, FileMode.Create)) {
                        formatter.Serialize(fStream, ListElements);
                        fStream.Close();
                    }   
                }
                catch (Exception ex) {
                    MessageBox.Show("Ошибка: невозможно прочитать файл с диска. Original error: " + ex.Message);
                }
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
                        formatter.Serialize(fStream, ListElements);
                        fStream.Close();
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Ошибка: невозможно прочитать файл с диска. Original error: " + ex.Message);
                }
            }
            _pathXmlFile = XmlDataFile.FileName;
        }


        //==============================Form object==============================//
        private void createToolStripMenuItem_Click(object sender, EventArgs e) {
            Create();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFile();
            Create();
            ViewCollection();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (_pathXmlFile != "") {
                SaveFile();
                StatusOfChange = false;
            }
            else {
                SaveHowFile();
                StatusOfChange = false;
            }
        }

        private void saveHowToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveHowFile();
            StatusOfChange = false;
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
            StatusOfChange = true;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            Editing();
            ViewCollection();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
            Help();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutBox1 AboutForm = new AboutBox1();
            AboutForm.ShowDialog();
        }


        //==============================Events==============================//
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e) {
            SortTable(e);
            ViewCollection();
        }

        private void Form1_SizeChanged(object sender, EventArgs e) {
            SizeChangeTable();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            if (StatusOfChange == true) {
                string message = "Хотите ли вы сохранить изменения?";
                string caption = "Внимание";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                DialogResult result = MessageBox.Show(message, caption, buttons, icon);
                if (result == DialogResult.Yes) {
                    if (_pathXmlFile != "") { SaveFile(); }
                    else { SaveHowFile(); }
                }
            }
        }  
    }
}
