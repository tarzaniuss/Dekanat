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
    public partial class AddStudentForm : Form
    {
        private DataBase dataBase = new DataBase(); 

        public AddStudentForm()
        {
            InitializeComponent();

            comboBoxFormOfStudy.Items.Add("Очна");
            comboBoxFormOfStudy.Items.Add("Заочна");

            comboBoxFundingType.Items.Add("Бюджет");
            comboBoxFundingType.Items.Add("Контракт");

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            FillStudyDataComboBox();
            StartPosition = FormStartPosition.CenterScreen;
        }


        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                dataBase.openConnection();
                int contactInfoId = CreateContactInfo();
                string insertQuery = "INSERT INTO Student (First_name, Last_name, Patronymic, ContactInfo_id, " +
                                    "StudyData_id, [Group], Course, Form_of_study, Funding_type, [Login], [Password]) " +
                                     "VALUES (@FirstName, @LastName, @Patronymic, @ContactInfoId, @StudyDataId, @Group, " +
                                     "@Course, @FormOfStudy, @FundingType, @Login, @Password)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, dataBase.getConnection()))
                {
                    cmd.Parameters.AddWithValue("@FirstName", textBoxFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", textBoxLastName.Text);
                    cmd.Parameters.AddWithValue("@Patronymic", textBoxPatronymic.Text);
                    cmd.Parameters.AddWithValue("@ContactInfoId", contactInfoId); 
                    cmd.Parameters.AddWithValue("@StudyDataId", Convert.ToInt32(comboBoxStudyData.SelectedItem));       
                    cmd.Parameters.AddWithValue("@Group", textBoxGroup.Text);
                    cmd.Parameters.AddWithValue("@Course", Convert.ToInt32(textBoxCourse.Text));
                    cmd.Parameters.AddWithValue("@FormOfStudy", comboBoxFormOfStudy.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@FundingType", comboBoxFundingType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Login", textBoxLogin.Text);
                    cmd.Parameters.AddWithValue("@Password", textBoxPassword.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Студент доданий успішно!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void GenerateLoginAndPassword(TextBox loginTextBox, TextBox passwordTextBox)
        {
            Random random = new Random();

            string login = "User" + random.Next(1000, 9999);

            string password = GenerateRandomPassword(8);

            loginTextBox.Text = login;
            passwordTextBox.Text = password;
        }

        private int CreateContactInfo()
        {
            string insertContactInfoQuery = "INSERT INTO ContactInfo (Phone_number, Email) VALUES (@PhoneNumber, @Email); SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(insertContactInfoQuery, dataBase.getConnection()))
            {
                cmd.Parameters.AddWithValue("@PhoneNumber", Convert.ToInt32(textBoxPhoneNumber.Text));
                cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private string GenerateRandomPassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }



        private void buttonGenerateCredentials_Click(object sender, EventArgs e)
        {
            GenerateLoginAndPassword(textBoxLogin, textBoxPassword);
        }

        private void FillStudyDataComboBox()
        {
            try
            {
                dataBase.openConnection();

                string query = "SELECT StudyData_id FROM StudyData";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxStudyData.Items.Add(reader["StudyData_id"]);
                        }
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
        }

        private void comboBoxStudyData_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int selectedStudyDataId = Convert.ToInt32(comboBoxStudyData.SelectedItem);

            string query = "SELECT Field_of_study, Faculty, Specialty, Tuition_fee_full_time, Tuition_fee_part_time " +
                           "FROM StudyData WHERE StudyData_id = @StudyDataId";

            using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
            {
                command.Parameters.AddWithValue("@StudyDataId", selectedStudyDataId);

                try
                {
                    dataBase.openConnection();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxFieldOfStudy.Text = reader["Field_of_study"].ToString();
                            textBoxFaculty.Text = reader["Faculty"].ToString();
                            textBoxSpecialty.Text = reader["Specialty"].ToString();
                            textBoxTuitionFeeFullTime.Text = reader["Tuition_fee_full_time"].ToString();
                            textBoxTuitionFeePartTime.Text = reader["Tuition_fee_part_time"].ToString();
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
            }
        }

        private void buttonAddStudentFromExcel_Click(object sender, EventArgs e)
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
                        string generatedLogin, generatedPassword;
                        do
                        {
                            GenerateLoginAndPassword(out generatedLogin, out generatedPassword);
                        } while (IsLoginExists(generatedLogin));
                        // Отримати дані з Excel-рядка та додати до бази даних
                        AddStudentFromExcelRow(worksheet, row, generatedLogin, generatedPassword);
                    }

                    MessageBox.Show("Студенти додані успішно!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddStudentFromExcelRow(ExcelWorksheet worksheet, int row, string generatedLogin, string generatedPassword)
        {
            try
            {
                string faculty = worksheet.Cells[row, 4].Value.ToString();
                string specialty = worksheet.Cells[row, 5].Value.ToString(); 

                if (IsStudentExists(
                    worksheet.Cells[row, 1].Value.ToString(), worksheet.Cells[row, 2].Value.ToString(),worksheet.Cells[row, 3].Value.ToString(),
                    faculty, specialty, Convert.ToInt32(worksheet.Cells[row, 7].Value), worksheet.Cells[row, 6].Value.ToString())) 
                {
                    MessageBox.Show("Студент з ідентичними даними вже існує в базі даних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }            
                int contactInfoId = CreateContactInfoFromExcel(worksheet, row);
                int studyDataId = GetStudyDataIdByFacultyAndSpecialty(faculty, specialty);
                string insertQuery = "INSERT INTO Student (First_name, Last_name, Patronymic, ContactInfo_id, StudyData_id, [Group], Course, Form_of_study, Funding_type, [Login], [Password]) " +
                                     "VALUES (@FirstName, @LastName, @Patronymic, @ContactInfoId, @StudyDataId, @Group, @Course, @FormOfStudy, @FundingType, @Login, @Password)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, dataBase.getConnection()))
                {
                    cmd.Parameters.AddWithValue("@FirstName", worksheet.Cells[row, 1].Value.ToString());
                    cmd.Parameters.AddWithValue("@LastName", worksheet.Cells[row, 2].Value.ToString());
                    cmd.Parameters.AddWithValue("@Patronymic", worksheet.Cells[row, 3].Value.ToString());
                    cmd.Parameters.AddWithValue("@ContactInfoId", contactInfoId);
                    cmd.Parameters.AddWithValue("@StudyDataId", studyDataId);
                    cmd.Parameters.AddWithValue("@Group", worksheet.Cells[row, 6].Value.ToString());
                    cmd.Parameters.AddWithValue("@Course", Convert.ToInt32(worksheet.Cells[row, 7].Value));
                    cmd.Parameters.AddWithValue("@FormOfStudy", worksheet.Cells[row, 8].Value.ToString());
                    cmd.Parameters.AddWithValue("@FundingType", worksheet.Cells[row, 9].Value.ToString());
                    cmd.Parameters.AddWithValue("@Login", generatedLogin);
                    cmd.Parameters.AddWithValue("@Password", generatedPassword);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing Excel row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        private int GetStudyDataIdByFacultyAndSpecialty(string faculty, string specialty)
        {
            string query = "SELECT StudyData_id FROM StudyData WHERE Faculty = @Faculty AND Specialty = @Specialty";
            using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
            {
                command.Parameters.AddWithValue("@Faculty", faculty);
                command.Parameters.AddWithValue("@Specialty", specialty);

                try
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error getting StudyData ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw; 
                }
                finally
                {

                }
            }
        }

        private bool IsStudentExists(string firstName, string lastName, string patronymic, string faculty, string specialty, int course, string group)
        {
            string query = "SELECT COUNT(*) FROM Student s " +
                           "INNER JOIN StudyData sd ON s.StudyData_id = sd.StudyData_id " +
                           "WHERE s.First_name = @FirstName AND s.Last_name = @LastName AND s.Patronymic = @Patronymic " +
                           "AND sd.Faculty = @Faculty AND sd.Specialty = @Specialty AND s.Course = @Course AND s.[Group] = @Group";

            using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
            {
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Patronymic", patronymic);
                command.Parameters.AddWithValue("@Faculty", faculty);
                command.Parameters.AddWithValue("@Specialty", specialty);
                command.Parameters.AddWithValue("@Course", course);
                command.Parameters.AddWithValue("@Group", group);

                try
                {
                    dataBase.openConnection();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error checking student existence: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    dataBase.closeConnection();
                }
            }
        }

        private bool IsLoginExists(string login)
        {
            string query = "SELECT COUNT(*) FROM Student WHERE [Login] = @Login";
            using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
            {
                command.Parameters.AddWithValue("@Login", login);

                try
                {
                    dataBase.openConnection();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error checking login existence: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    dataBase.closeConnection();
                }
            }
        }

        private void GenerateLoginAndPassword(out string generatedLogin, out string generatedPassword)
        {

            Random random = new Random();

            generatedLogin = "User" + random.Next(1000, 9999);

            generatedPassword = GenerateRandomPassword(8);
        }

        private int CreateContactInfoFromExcel(ExcelWorksheet worksheet, int row)
        {
            try
            {
                dataBase.openConnection();
                string phoneNumber = worksheet.Cells[row, 10].Value.ToString();
                string email = worksheet.Cells[row, 11].Value.ToString();
                phoneNumber = "0" + phoneNumber;
                string insertContactInfoQuery = "INSERT INTO ContactInfo (Phone_number, Email) VALUES (@PhoneNumber, @Email); SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(insertContactInfoQuery, dataBase.getConnection()))
                {
                    cmd.Parameters.AddWithValue("@PhoneNumber", (phoneNumber));
                    cmd.Parameters.AddWithValue("@Email", email);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating ContactInfo from Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; 
            }
            finally
            {
                
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}