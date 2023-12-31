using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dekanat
{
    public partial class ManageStudentsForm : Form
    {
        DataBase dataBase = new DataBase(); 
        private StudentFilters studentFilters = new StudentFilters();
        private List<string> faculties;
        private List<string> groups;
        private List<int> courses;
        private List<string> specialties;
        
        public ManageStudentsForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            CreateColumns();
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            LoadFilters();

            comboBoxFaculty.SelectedIndex = -1;
            comboBoxGroup.SelectedIndex = -1;
            comboBoxCourse.SelectedIndex = -1;
            comboBoxSpecialty.SelectedIndex = -1;

            comboBoxFundingType.DataSource = new List<string> { "Усі", "Бюджет", "Контракт" };
            comboBoxFundingType.SelectedIndex = 0;

            comboBoxFaculty.SelectedIndexChanged += comboBoxFaculty_SelectedIndexChanged;
            comboBoxCourse.SelectedIndexChanged += comboBoxCourse_SelectedIndexChanged;
        }

        private void LoadFilters()
        {
            faculties = studentFilters.GetFaculties();
            courses = studentFilters.GetCourses();

            comboBoxFaculty.DataSource = faculties;

            comboBoxCourse.DataSource = courses;
        }

        private void LoadGroups()
        {
            if (comboBoxFaculty.SelectedIndex != -1)
            {
                string selectedFaculty = comboBoxFaculty.SelectedItem.ToString();
                int? selectedCourse = comboBoxCourse.SelectedItem as int?;


                string selectedSpecialty = comboBoxSpecialty.SelectedIndex != -1 && comboBoxSpecialty.SelectedIndex != 0
                    ? comboBoxSpecialty.SelectedItem.ToString()
                    : null;

                groups = studentFilters.GetGroups(selectedFaculty, selectedSpecialty, selectedCourse);

                comboBoxGroup.Items.Clear();
                comboBoxGroup.Items.Add("Усі");
                comboBoxGroup.Items.AddRange(groups.ToArray());
                comboBoxGroup.SelectedIndex = 0;

                comboBoxGroup.Enabled = true;
            }
            else
            {
                groups = new List<string>();

                comboBoxGroup.Enabled = false;
            }
        }


        private void LoadSpecialties()
        {

            if (comboBoxFaculty.SelectedIndex != -1)
            {
                string selectedFaculty = comboBoxFaculty.SelectedItem.ToString();
                specialties = studentFilters.GetSpecialties(selectedFaculty);

                comboBoxSpecialty.Items.Clear();

                comboBoxSpecialty.Items.Add("Усі");

                comboBoxSpecialty.Items.AddRange(specialties.ToArray());

                comboBoxSpecialty.SelectedIndex = 0;

                comboBoxSpecialty.Enabled = true;

                LoadGroups();
            }
            else
            {
                specialties = new List<string>();

                comboBoxSpecialty.Enabled = false;
            }
        }

      

        private void CreateColumns()
        {
            DataGridViewTextBoxColumn studentIdColumn = new DataGridViewTextBoxColumn();
            studentIdColumn.HeaderText = "ID";
            studentIdColumn.DataPropertyName = "Student_id";
            dataGridView1.Columns.Add(studentIdColumn);

            DataGridViewTextBoxColumn fullNameColumn = new DataGridViewTextBoxColumn();
            fullNameColumn.HeaderText = "ПІБ";
            fullNameColumn.DataPropertyName = "FullName";
            dataGridView1.Columns.Add(fullNameColumn);

            DataGridViewLinkColumn studyDataColumn = new DataGridViewLinkColumn();
            studyDataColumn.HeaderText = "Навчальні дані";
            studyDataColumn.Name = "StudyData_id";
            studyDataColumn.DataPropertyName = "StudyData_id";
            dataGridView1.Columns.Add(studyDataColumn);

            DataGridViewTextBoxColumn groupColumn = new DataGridViewTextBoxColumn();
            groupColumn.HeaderText = "Група";
            groupColumn.DataPropertyName = "Group";
            dataGridView1.Columns.Add(groupColumn);

            DataGridViewTextBoxColumn courseColumn = new DataGridViewTextBoxColumn();
            courseColumn.HeaderText = "Курс";
            courseColumn.DataPropertyName = "Course";
            dataGridView1.Columns.Add(courseColumn);

            DataGridViewTextBoxColumn formOfStudyColumn = new DataGridViewTextBoxColumn();
            formOfStudyColumn.HeaderText = "Форма навчання";
            formOfStudyColumn.DataPropertyName = "Form_of_study";
            dataGridView1.Columns.Add(formOfStudyColumn);

            DataGridViewTextBoxColumn fundingTypeColumn = new DataGridViewTextBoxColumn();
            fundingTypeColumn.HeaderText = "Тип фінансування";
            fundingTypeColumn.DataPropertyName = "Funding_type";
            dataGridView1.Columns.Add(fundingTypeColumn);

            DataGridViewLinkColumn contactInfoColumn = new DataGridViewLinkColumn();
            contactInfoColumn.HeaderText = "Контактна інформація";
            contactInfoColumn.Name = "ContactInfo_id";
            contactInfoColumn.DataPropertyName = "ContactInfo_id";
            dataGridView1.Columns.Add(contactInfoColumn);

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }
        }

        private void LoadStudentData()
        {
            try
            {
                dataBase.openConnection(); 
                       
                string query = "SELECT s.Student_id, CONCAT(s.Last_name, ' ', s.First_name, ' ', s.Patronymic) " +
                               "AS FullName, s.ContactInfo_id, " +
                               "s.StudyData_id, s.[Group], s.Course, s.Form_of_study, s.Funding_type " +
                               "FROM Student s " +
                               "INNER JOIN StudyData sd ON s.StudyData_id = sd.StudyData_id " +
                               "WHERE 1=1";

                dataGridView1.AutoGenerateColumns = false;
                if (comboBoxFaculty.SelectedIndex != -1 )
                {
                    string selectedFaculty = comboBoxFaculty.SelectedItem.ToString();
                    query += $" AND Faculty = '{selectedFaculty}'";

                }
                if (comboBoxSpecialty.SelectedIndex != -1 && comboBoxSpecialty.SelectedIndex != 0)
                {
                    string selectedSpecialty = comboBoxSpecialty.SelectedItem.ToString();
                    query += $" AND Specialty = '{selectedSpecialty}'";
                }
                if (comboBoxGroup.SelectedIndex != -1 && comboBoxGroup.SelectedIndex != 0)
                {
                    string selectedGroup = comboBoxGroup.SelectedItem.ToString();
                    query += $" AND [Group] = '{selectedGroup}'";
                }
                if (comboBoxCourse.SelectedIndex != -1)
                {
                    int selectedCourse = (int)comboBoxCourse.SelectedItem;
                    query += $" AND Course = {selectedCourse}";
                }
                if (!string.IsNullOrEmpty(comboBoxFundingType.Text) && comboBoxFundingType.Text != "Усі")
                {
                    string selectedFundingType = comboBoxFundingType.Text;
                    query += $" AND s.Funding_type = '{selectedFundingType}'";
                }
                if (!string.IsNullOrEmpty(textBoxSearch.Text))
                {
                    string searchKeyword = textBoxSearch.Text.Trim();
                    query += $" AND CONCAT(Last_name, ' ', First_name, ' ', Patronymic) LIKE '%{searchKeyword}%'";
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, dataBase.getConnection()))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                dataBase.closeConnection(); 
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadStudentData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["ContactInfo_id"].Index && e.RowIndex >= 0)
            {
                int student_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);

                ContactInfoForm contactInfoForm = new ContactInfoForm(student_id);
                contactInfoForm.Show();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["StudyData_id"].Index && e.RowIndex >= 0)
            {
                int studentId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);

                StudyDataForm studyDataForm = new StudyDataForm(studentId);
                studyDataForm.Show();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["ContactInfo_id"].Index && e.RowIndex >= 0 ||
                e.ColumnIndex == dataGridView1.Columns["StudyData_id"].Index && e.RowIndex >= 0)
            {
                e.Value = "Переглянути";
            }

        }

       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void RefreshDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            LoadStudentData();
        }

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.ShowDialog();

            RefreshDataGridView();
        }

        private void buttonUpdateStudent_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int studentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                EditStudentForm editStudentForm = new EditStudentForm(studentId);
                editStudentForm.ShowDialog();

                RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть студента для редагування.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити обраних студентів?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        int studentId = Convert.ToInt32(row.Cells[0].Value);

                        DeleteStudent(studentId);
                    }

                    MessageBox.Show("Студенти успіно видалені!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть принаймні одного студента для видалення.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteStudent(int studentId)
        {
            try
            {
                string query = "DELETE FROM Student WHERE Student_id = @StudentId";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId);

                    dataBase.openConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при видаленні студента: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        private void buttonApplyFilters_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void comboBoxFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSpecialties();
        }

        private void buttonResetFilters_Click(object sender, EventArgs e)
        {
            comboBoxFaculty.SelectedIndex = -1;
            comboBoxGroup.SelectedIndex = -1;
            comboBoxCourse.SelectedIndex = -1;

            comboBoxSpecialty.SelectedIndex = -1;
            textBoxSearch.Text = string.Empty;

            RefreshDataGridView();
        }

        private void comboBoxSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGroups();
        }

        private void buttonExportToExcel_Click(object sender, EventArgs e)
        {
            ExcelExporter.ExportStudentsToExcel(dataGridView1);
        }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGroups();
        }

        private void comboBoxFundingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }
    }
}