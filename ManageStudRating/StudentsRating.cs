using OfficeOpenXml;
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
    public partial class StudentsRating : Form
    {
        private DataBase dataBase = new DataBase();
        private StudentFilters studentFilters = new StudentFilters();
        private List<string> faculties;
        private List<string> groups;
        private List<int> courses;
        private List<string> specialties;
        private float minGrade = 0.0f;
        private int NumberOfNA = 0;

        public StudentsRating()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dataGridViewStudRating.AllowUserToAddRows = false;
            CreateColumns();
            LoadFilters();

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            comboBoxFaculty.SelectedIndex = -1;
            comboBoxGroup.SelectedIndex = -1;
            comboBoxCourse.SelectedIndex = -1;
            comboBoxSpecialty.SelectedIndex = -1;

            comboBoxFundingType.DataSource = new List<string> { "Усі", "Бюджет", "Контракт" };
            comboBoxFundingType.SelectedIndex = 0;

            comboBoxFaculty.SelectedIndexChanged += comboBoxFaculty_SelectedIndexChanged;
            numericUpDownMinGrade.ValueChanged += numericUpDownMinGrade_ValueChanged;
            numericUpDownNA.ValueChanged += numericUpDownNA_ValueChanged;
            dataGridViewStudRating.CellValueChanged += dataGridViewStudRating_CellValueChanged;

            comboBoxCourse.SelectedIndexChanged += comboBoxCourse_SelectedIndexChanged;
            radioButtonGreater.Checked = true;
            radioButtonNAgreater.Checked = true;
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
            studentIdColumn.HeaderText = "ID студента";
            studentIdColumn.DataPropertyName = "Student_id";
            studentIdColumn.ReadOnly = true;
            dataGridViewStudRating.Columns.Add(studentIdColumn);

            DataGridViewTextBoxColumn fullNameColumn = new DataGridViewTextBoxColumn();
            fullNameColumn.HeaderText = "ПІБ студента";
            fullNameColumn.DataPropertyName = "FullName";
            fullNameColumn.ReadOnly = true;
            dataGridViewStudRating.Columns.Add(fullNameColumn);

            DataGridViewTextBoxColumn facultyColumn = new DataGridViewTextBoxColumn();
            facultyColumn.HeaderText = "Факультет";
            facultyColumn.DataPropertyName = "Faculty";
            facultyColumn.ReadOnly = true;
            dataGridViewStudRating.Columns.Add(facultyColumn);

            DataGridViewTextBoxColumn specialtyColumn = new DataGridViewTextBoxColumn();
            specialtyColumn.HeaderText = "Спеціальність";
            specialtyColumn.DataPropertyName = "Specialty";
            specialtyColumn.ReadOnly = true;
            dataGridViewStudRating.Columns.Add(specialtyColumn);

            DataGridViewTextBoxColumn courseColumn = new DataGridViewTextBoxColumn();
            courseColumn.HeaderText = "Курс";
            courseColumn.DataPropertyName = "Course";
            courseColumn.ReadOnly = true;
            dataGridViewStudRating.Columns.Add(courseColumn);

            DataGridViewTextBoxColumn groupColumn = new DataGridViewTextBoxColumn();
            groupColumn.HeaderText = "Група";
            groupColumn.DataPropertyName = "Group";
            groupColumn.ReadOnly = true;
            dataGridViewStudRating.Columns.Add(groupColumn);

            DataGridViewTextBoxColumn gradePointsColumn = new DataGridViewTextBoxColumn();
            gradePointsColumn.HeaderText = "Бали";
            gradePointsColumn.DataPropertyName = "Grade_points";
            gradePointsColumn.ReadOnly = false;
            dataGridViewStudRating.Columns.Add(gradePointsColumn);

            DataGridViewTextBoxColumn gradeAlphabeticalColumn = new DataGridViewTextBoxColumn();
            gradeAlphabeticalColumn.HeaderText = "Оцінка буквено";
            gradeAlphabeticalColumn.DataPropertyName = "Grade_alphabetical";
            gradeAlphabeticalColumn.ReadOnly = true;
            dataGridViewStudRating.Columns.Add(gradeAlphabeticalColumn);

            DataGridViewTextBoxColumn gradeVerbalColumn = new DataGridViewTextBoxColumn();
            gradeVerbalColumn.HeaderText = "Оцінка вербальна";
            gradeVerbalColumn.DataPropertyName = "Grade_verbal";
            gradeVerbalColumn.ReadOnly = true;
            dataGridViewStudRating.Columns.Add(gradeVerbalColumn);

            DataGridViewTextBoxColumn numberOfNAColumn = new DataGridViewTextBoxColumn();
            numberOfNAColumn.HeaderText = "Кількість N/A";
            numberOfNAColumn.DataPropertyName = "Number_of_na";
            numberOfNAColumn.ReadOnly = false;
            dataGridViewStudRating.Columns.Add(numberOfNAColumn);
        }

        private void LoadStudentRatingData()
        {
            try
            {
                dataBase.openConnection(); 
                string comparisonOperator = radioButtonGreater.Checked ? ">=" : "<=";
                string comparisonOperator2 = radioButtonNAgreater.Checked ? ">=" : "<=";
                string query = "SELECT sr.Student_id, CONCAT(s.Last_name, ' ', s.First_name, ' ', s.Patronymic) AS FullName, " +
                      "sr.Grade_points, sr.Grade_alphabetical, sr.Grade_verbal, sr.Number_of_na, " +
                      "sd.Faculty, sd.Specialty, s.Course, s.[Group] " +
                      "FROM StudentRating sr " +
                      "INNER JOIN Student s ON sr.Student_id = s.Student_id " +
                      "INNER JOIN StudyData sd ON s.StudyData_id = sd.StudyData_id " +
                      $"WHERE sr.Grade_points {comparisonOperator} @MinGrade AND sr.Number_of_na {comparisonOperator2} @NumberOfNA";

                dataGridViewStudRating.AutoGenerateColumns = false;
                if (comboBoxFaculty.SelectedIndex != -1)
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
                    adapter.SelectCommand.Parameters.AddWithValue("@MinGrade", minGrade);
                    adapter.SelectCommand.Parameters.AddWithValue("@NumberOfNA", NumberOfNA);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewStudRating.DataSource = dataTable;
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

        private void ProcessExcelFile(string filePath)
        {
            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        
                        UpdateStudentRatingFromExcelRow(worksheet, row);
                    }

                    MessageBox.Show("Успішність студентів оновлено успішно!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStudentRatingFromExcelRow(ExcelWorksheet worksheet, int row)
        {
            try
            {    
                string firstName = worksheet.Cells[row, 1].Value.ToString();
                string lastName = worksheet.Cells[row, 2].Value.ToString();
                string patronymic = worksheet.Cells[row, 3].Value.ToString();
                string group = worksheet.Cells[row, 4].Value.ToString();
                int course = Convert.ToInt32(worksheet.Cells[row, 5].Value);
                float gradePoints = Convert.ToSingle(worksheet.Cells[row, 6].Value);
                int numberOfNA = Convert.ToInt32(worksheet.Cells[row, 7].Value);
                int studentId = GetStudentId(firstName, lastName, patronymic, group, course);
            
                if (studentId != -1)
                {
                    if (!IsStudentRatingRecordExist(studentId))
                    {
                        MessageBox.Show($"Запис з рейтингом для студента {firstName} {lastName} {patronymic} з групи {group} та курсу {course} не знайдена.");
                    }
                    else
                    {
                        UpdateStudentPerformance(studentId, gradePoints, numberOfNA);
                        RefreshDataGridView();
                    }
                }
                else
                {
                    MessageBox.Show($"Студент {firstName} {lastName} {patronymic} з групи {group} та курсу {course} не знайдений.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при оновленні успішності студента: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetStudentId(string firstName, string lastName, string patronymic, string group, int course)
        {
            int studentId = -1;
            try
            {
                dataBase.openConnection(); 
                string query = "SELECT Student_id FROM Student " +
                               "WHERE First_name = @FirstName " +
                               "AND Last_name = @LastName " +
                               "AND Patronymic = @Patronymic " +
                               "AND [Group] = @Group " +
                               "AND Course = @Course";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Patronymic", patronymic);
                    command.Parameters.AddWithValue("@Group", group);
                    command.Parameters.AddWithValue("@Course", course);
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        studentId = Convert.ToInt32(result);
                    }
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
            return studentId;
        }

        private bool IsStudentRatingRecordExist(int studentId)
        {
            try
            {
                dataBase.openConnection();

                
                string query = "SELECT COUNT(*) FROM StudentRating " +
                               "WHERE Student_id = @StudentId";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId);

                    
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        private void UpdateStudentPerformance(int studentId, float gradePoints, int numberOfNA)
        {
            try
            {
                dataBase.openConnection();

                
                string query = "UPDATE StudentRating " +
                               "SET Grade_points = @GradePoints, Number_of_na = @NumberOfNA " +
                               "WHERE Student_id = @StudentId";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@GradePoints", gradePoints);
                    command.Parameters.AddWithValue("@NumberOfNA", numberOfNA);
                    command.Parameters.AddWithValue("@StudentId", studentId);

                    
                    command.ExecuteNonQuery();
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

        private void comboBoxFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSpecialties();
        }

        private void comboBoxSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGroups();
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

        private void buttonApplyFilters_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void StudentsRating_Load(object sender, EventArgs e)
        {
            LoadStudentRatingData();
        }

        private void RefreshDataGridView()
        {
            dataGridViewStudRating.DataSource = null;
            dataGridViewStudRating.Rows.Clear();

            LoadStudentRatingData();
        }

        private void numericUpDownMinGrade_ValueChanged(object sender, EventArgs e)
        {
            minGrade = (float)numericUpDownMinGrade.Value;
            LoadStudentRatingData();
        }

        private void buttonUpdateRatingFromExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                    openFileDialog.Title = "Select an Excel File";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;

                        
                        ProcessExcelFile(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButtonGreater_CheckedChanged(object sender, EventArgs e)
        {
            LoadStudentRatingData();
        }

        private void radioButtonLess_CheckedChanged(object sender, EventArgs e)
        {
            LoadStudentRatingData();
        }

        private void radioButtonNAgreater_CheckedChanged(object sender, EventArgs e)
        {
            LoadStudentRatingData();
        }

        private void radioButtonNAless_CheckedChanged(object sender, EventArgs e)
        {
            LoadStudentRatingData();
        }

        private void numericUpDownNA_ValueChanged(object sender, EventArgs e)
        {
            NumberOfNA = (int)numericUpDownNA.Value;
            LoadStudentRatingData();
        }


        private void buttonSaveToExcel_Click(object sender, EventArgs e)
        {
            ExcelExporter.ExportToExcel(dataGridViewStudRating);
        }

        private void dataGridViewStudRating_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Отримайте індекс рядка та значення зміненої клітинки
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            if (rowIndex >= 0 && columnIndex >= 0)
            {
                DataGridViewRow row = dataGridViewStudRating.Rows[rowIndex];
                int studentId = Convert.ToInt32(row.Cells[0].Value);

                // Отримайте значення, яке користувач ввів в клітинці
                object cellValue = row.Cells[columnIndex].Value;

                
                UpdateDatabaseRecord(studentId, columnIndex, cellValue);
                RefreshDataGridView();
            }
        }

        private void UpdateDatabaseRecord(int studentId, int columnIndex, object cellValue)
        {
            try
            {
                dataBase.openConnection();

                string columnName = dataGridViewStudRating.Columns[columnIndex].DataPropertyName;

                // Запит для оновлення конкретного поля в базі даних
                string query = $"UPDATE StudentRating SET {columnName} = @CellValue WHERE Student_id = @StudentId";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@CellValue", cellValue);
                    command.Parameters.AddWithValue("@StudentId", studentId);

                    
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating database record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
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
