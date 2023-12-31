using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dekanat
{
    public partial class StudentsInfoForm : Form
    {
        private int studentId;
        private DataBase dataBase = new DataBase();
        private bool isPasswordVisible = false;

        public StudentsInfoForm(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId; 
            LoadStudentData();

            txtPassword.PasswordChar = '●';
            pictureBox1.Visible = false;
    
        }

        private void LoadStudentData()
        {
            
            string query = $"SELECT * FROM Student " +
                           $"JOIN StudyData ON Student.StudyData_id = StudyData.StudyData_id " +
                           $"JOIN ContactInfo ON Student.ContactInfo_id = ContactInfo.ContactInfo_id " +
                           $"WHERE Student.Student_id = {studentId}";

            SqlDataAdapter adapter = new SqlDataAdapter(query, dataBase.getConnection());
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                DataRow row = table.Rows[0];

                txtFullName.Text = $"{row["First_name"]} {row["Last_name"]} {row["Patronymic"]}";

                

                txtFaculty.Text = $"{row["Faculty"]}";
                txtSpecialty.Text = $"{row["Specialty"]}";
                txtGroup.Text = $"{row["Group"]}";
                txtCourse.Text = $"{row["Course"]}";
                txtFormOfStudy.Text = $"{row["Form_of_study"]}";
                txtFundingType.Text = $"{row["Funding_type"]}";

                
                txtPhoneNumber.Text = $"{row["Phone_number"]}";
                txtEmail.Text = $"{row["Email"]}";
                
                txtLogin.Text = $"{row["Login"]}";
                txtPassword.Text = $"{row["Password"]}";

                LoadStudentRating(studentId);


            }
            else
            {
                MessageBox.Show("Error loading student data.");
            }
        }

        private void LoadStudentRating(int studentId)
        {
            
            string ratingQuery = $"SELECT * FROM StudentRating WHERE Student_id = {studentId}";

            SqlDataAdapter ratingAdapter = new SqlDataAdapter(ratingQuery, dataBase.getConnection());
            DataTable ratingTable = new DataTable();
            ratingAdapter.Fill(ratingTable);

            if (ratingTable.Rows.Count > 0)
            {
                DataRow ratingRow = ratingTable.Rows[0];

                
                txtGradePoints.Text = $"{ratingRow["Grade_points"]}";
                txtGradeAlphabetical.Text = $"{ratingRow["Grade_alphabetical"]}";
                txtGradeVerbal.Text = $"{ratingRow["Grade_verbal"]}";
                txtNumberOfNA.Text = $"{ratingRow["Number_of_na"]}";
            }
            else
            {
                MessageBox.Show("No rating information available.");
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Номер телефону та Email є обов'язковими полями. Будь ласка, введіть вірні значення.");
                return;
            }

            if (!IsPhoneNumberValid(txtPhoneNumber.Text))
            {
                MessageBox.Show("Номер телефону повинен містити 10 цифр.");
                return;
            }

            string updateQuery = $"UPDATE ContactInfo " +
                                 $"SET Phone_number = '{txtPhoneNumber.Text}', " +
                                 $"Email = '{txtEmail.Text}' " +
                                 $"WHERE ContactInfo_id = (SELECT ContactInfo_id FROM Student WHERE Student_id = {studentId})";

            SqlConnection connection = dataBase.getConnection();
            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);

            try
            {
                connection.Open();
                updateCommand.ExecuteNonQuery();
                MessageBox.Show("Дані успішно оновлені!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving changes: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            txtPhoneNumber.ReadOnly = true;
            txtEmail.ReadOnly = true;
        }


        private bool IsPhoneNumberValid(string phoneNumber)
        {
            
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d{10}$");
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            
            txtPhoneNumber.ReadOnly = false;
            txtEmail.ReadOnly = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0';
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '●';
            pictureBox2.Visible = true;
            pictureBox1.Visible = false;
        }

        private void buttonEditLoginPass_Click(object sender, EventArgs e)
        {
            txtLogin.ReadOnly = false;
            txtPassword.ReadOnly = false;
        }

        private void SaveLoginAndPassChanges()
        {
            string newLogin = txtLogin.Text.Trim();
            string newPassword = txtPassword.Text.Trim();

            // Перевірка наявності нового логіна та пароля
            if (!string.IsNullOrEmpty(newLogin) && !string.IsNullOrEmpty(newPassword))
            {
                // Оновлення нового логіна та пароля в базі даних
                string updateQuery = $"UPDATE Student " +
                                     $"SET Login = '{newLogin}', " +
                                     $"Password = '{newPassword}' " +
                                     $"WHERE Student_id = {studentId}";

                SqlConnection connection = dataBase.getConnection();
                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);

                try
                {
                    connection.Open();
                    updateCommand.ExecuteNonQuery();
                    MessageBox.Show("Зміни логіна та пароля успішно виконана!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при збереженні змін: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть новий логін та пароль перед збереженням.");
            }
        }

        private void buttonSaveLoginPass_Click(object sender, EventArgs e)
        {
            SaveLoginAndPassChanges();

            txtLogin.ReadOnly = true;
            txtPassword.ReadOnly = true;
        }
    }
}
