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
    public partial class PaymentInfoForm : Form
    {
        private DataBase dataBase = new DataBase();
        private StudentFilters studentFilters = new StudentFilters();
        private List<string> faculties;
        private List<string> groups;
        private List<int> courses;
        private List<string> specialties;

        public PaymentInfoForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dataGridViewPaymentInfo.AllowUserToAddRows = false;
            CreateColumns();
            LoadFilters();
            dataGridViewPaymentInfo.CellValueChanged += dataGridViewPaymentInfo_CellValueChanged;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            List<string> paymentStatuses = new List<string> { "Усі", "Не оплачено", "Оплачено", "Частково оплачено" };
            comboBoxPaymentStatus.DataSource = paymentStatuses;
            comboBoxPaymentStatus.SelectedIndex = 0;
            comboBoxFaculty.SelectedIndex = -1;
            comboBoxGroup.SelectedIndex = -1;
            comboBoxCourse.SelectedIndex = -1;
            comboBoxSpecialty.SelectedIndex = -1;
        }

        private void LoadFilters()
        {
            // Load faculties, groups, and courses using StudentFilters
            faculties = studentFilters.GetContractFaculties();
            courses = studentFilters.GetContractCourses();

            // Bind data to ComboBoxes
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
                specialties = studentFilters.GetContractSpecialties(selectedFaculty);

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
            dataGridViewPaymentInfo.Columns.Add(studentIdColumn);

            DataGridViewTextBoxColumn fullNameColumn = new DataGridViewTextBoxColumn();
            fullNameColumn.HeaderText = "ПІБ студента";
            fullNameColumn.DataPropertyName = "FullName";
            fullNameColumn.ReadOnly = true;
            dataGridViewPaymentInfo.Columns.Add(fullNameColumn);

            DataGridViewTextBoxColumn facultyColumn = new DataGridViewTextBoxColumn();
            facultyColumn.HeaderText = "Факультет";
            facultyColumn.DataPropertyName = "Faculty";
            facultyColumn.ReadOnly = true;
            dataGridViewPaymentInfo.Columns.Add(facultyColumn);

            DataGridViewTextBoxColumn specialtyColumn = new DataGridViewTextBoxColumn();
            specialtyColumn.HeaderText = "Спеціальність";
            specialtyColumn.DataPropertyName = "Specialty";
            specialtyColumn.ReadOnly = true;
            dataGridViewPaymentInfo.Columns.Add(specialtyColumn);

            DataGridViewTextBoxColumn courseColumn = new DataGridViewTextBoxColumn();
            courseColumn.HeaderText = "Курс";
            courseColumn.DataPropertyName = "Course";
            courseColumn.ReadOnly = true;
            dataGridViewPaymentInfo.Columns.Add(courseColumn);

            DataGridViewTextBoxColumn groupColumn = new DataGridViewTextBoxColumn();
            groupColumn.HeaderText = "Група";
            groupColumn.DataPropertyName = "Group";
            groupColumn.ReadOnly = true;
            dataGridViewPaymentInfo.Columns.Add(groupColumn);

            DataGridViewTextBoxColumn amountPaidColumn = new DataGridViewTextBoxColumn();
            amountPaidColumn.HeaderText = "Оплачено";
            amountPaidColumn.DataPropertyName = "Amount_paid";
            amountPaidColumn.ReadOnly = false;
            dataGridViewPaymentInfo.Columns.Add(amountPaidColumn);

            DataGridViewTextBoxColumn totalPaymentAmountColumn = new DataGridViewTextBoxColumn();
            totalPaymentAmountColumn.HeaderText = "Вся сума оплати";
            totalPaymentAmountColumn.DataPropertyName = "Total_payment_amount";
            totalPaymentAmountColumn.ReadOnly = true;
            dataGridViewPaymentInfo.Columns.Add(totalPaymentAmountColumn);

            DataGridViewTextBoxColumn paymentStatusColumn = new DataGridViewTextBoxColumn();
            paymentStatusColumn.HeaderText = "Статус оплати";
            paymentStatusColumn.DataPropertyName = "Payment_status";
            paymentStatusColumn.ReadOnly = true;
            dataGridViewPaymentInfo.Columns.Add(paymentStatusColumn);
        }

        private void LoadPaymentInfoData()
        {
            try
            {
                dataBase.openConnection();

                string query = "SELECT pi.Student_id, CONCAT(s.Last_name, ' ', s.First_name, ' ', s.Patronymic) AS FullName, " +
                               "sd.Faculty, sd.Specialty, s.Course, s.[Group], " +
                               "pi.Amount_paid, pi.Total_payment_amount, pi.Payment_status " +
                               "FROM PaymentInfo pi " +
                               "INNER JOIN Student s ON pi.Student_id = s.Student_id " +
                               "INNER JOIN StudyData sd ON s.StudyData_id = sd.StudyData_id";

                dataGridViewPaymentInfo.AutoGenerateColumns = false;
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
                if (comboBoxPaymentStatus.SelectedIndex != -1 && comboBoxPaymentStatus.SelectedIndex != 0)
                {
                    string selectedPaymentStatus = comboBoxPaymentStatus.SelectedItem.ToString();
                    query += $" AND Payment_status = '{selectedPaymentStatus}'";
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
                    dataGridViewPaymentInfo.DataSource = dataTable;
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

        private void RefreshDataGridView()
        {
            dataGridViewPaymentInfo.DataSource = null;
            dataGridViewPaymentInfo.Rows.Clear();

            LoadPaymentInfoData();
        }

        private void PaymentInfoForm_Load(object sender, EventArgs e)
        {
            LoadPaymentInfoData();
        }

        private void comboBoxFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSpecialties();
        }

        private void comboBoxSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGroups();
        }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGroups();
        }

        private void buttonApplyFilters_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
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

                        UpdatePaymentInfoFromExcelRow(worksheet, row);
                    }

                    MessageBox.Show("Успішність студентів оновлено успішно!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePaymentInfoFromExcelRow(ExcelWorksheet worksheet, int row)
        {
            try
            {

                string firstName = worksheet.Cells[row, 1].Text;    
                string lastName = worksheet.Cells[row, 2].Text;
                string patronymic = worksheet.Cells[row, 3].Text;
                string group = worksheet.Cells[row, 4].Text;
                int course = int.Parse(worksheet.Cells[row, 5].Text);  
                int amountPaid = int.Parse(worksheet.Cells[row, 6].Text);

                int studentId = GetStudentId(firstName, lastName, patronymic, group, course);

                if (studentId != -1)
                {
                    if (!IsStudentPaymentRecordExist(studentId))
                    {
                        MessageBox.Show($"Запис з оплатою для студента {firstName} {lastName} {patronymic} з групи {group} та курсу {course} не знайдена.");
                    }
                    else
                    {
                        UpdatePaymentInfo(studentId, amountPaid);
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
                MessageBox.Show($"Помилка при оновленні оплати студента: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePaymentInfo(int studentId, int amountPaid)
        {
            try
            {

                dataBase.openConnection();
                string query = "UPDATE PaymentInfo SET Amount_paid = @AmountPaid WHERE Student_id = @StudentId";

                    using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                    {
                        command.Parameters.AddWithValue("@AmountPaid", amountPaid);
                        command.Parameters.AddWithValue("@StudentId", studentId);

                        command.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating payment information in the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        private bool IsStudentPaymentRecordExist(int studentId)
        {
            try
            {
                dataBase.openConnection();


                string query = "SELECT COUNT(*) FROM PaymentInfo " +
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

        private void dataGridViewPaymentInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            if (rowIndex >= 0 && columnIndex >= 0)
            {
                DataGridViewRow row = dataGridViewPaymentInfo.Rows[rowIndex];
                int studentId = Convert.ToInt32(row.Cells[0].Value);

                object cellValue = row.Cells[columnIndex].Value;


                UpdateDatabaseRecord(studentId, cellValue);
                RefreshDataGridView();
            }
        }

        private void UpdateDatabaseRecord(int studentId, object cellValue)
        {
            try
            {
                dataBase.openConnection();

                string query = $"UPDATE PaymentInfo SET Amount_paid = @Paid WHERE Student_id = @StudentId";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@Paid", cellValue);
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

        private void buttonSaveToExcel_Click(object sender, EventArgs e)
        {
            ExcelExporter.ExportToExcel(dataGridViewPaymentInfo);
        }

        private void comboBoxPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }
    }
}
