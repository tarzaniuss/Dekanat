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
    public partial class EditStudentForm : Form
    {
        private readonly DataBase dataBase = new DataBase(); 
        private readonly int studentId;

        public EditStudentForm(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;

            comboBoxFormOfStudy.Items.Add("Очна");
            comboBoxFormOfStudy.Items.Add("Заочна");

            comboBoxFundingType.Items.Add("Бюджет");
            comboBoxFundingType.Items.Add("Контракт");


            FillStudyDataComboBox();
            LoadStudentData(studentId);
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoadStudentData(int studentId)
        {
            try
            {
                dataBase.openConnection();

                
                string query = "SELECT First_name, Last_name, Patronymic, StudyData_id, [Group], Course, Form_of_study, Funding_type " +
                               "FROM Student WHERE Student_id = @StudentId";

                using (SqlCommand cmd = new SqlCommand(query, dataBase.getConnection()))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            textBoxFirstName.Text = reader["First_name"].ToString();
                            textBoxLastName.Text = reader["Last_name"].ToString();
                            textBoxPatronymic.Text = reader["Patronymic"].ToString();
                            textBoxGroup.Text = reader["Group"].ToString();
                            textBoxCourse.Text = reader["Course"].ToString();
                            comboBoxFormOfStudy.SelectedItem = reader["Form_of_study"].ToString();
                            comboBoxFundingType.SelectedItem = reader["Funding_type"].ToString();

                            
                            comboBoxStudyData.SelectedItem = reader["StudyData_id"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження даних студента: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
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


        private void comboBoxStudyData_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataBase.closeConnection();

                dataBase.openConnection();

                int selectedStudyDataId = Convert.ToInt32(comboBoxStudyData.SelectedItem);


                string query = "SELECT Field_of_study, Faculty, Specialty, Tuition_fee_full_time, Tuition_fee_part_time " +
                               "FROM StudyData WHERE StudyData_id = @StudyDataId";



                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@StudyDataId", selectedStudyDataId);

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

        private void buttonUpdateStudentInfo_Click(object sender, EventArgs e)
        {
            try
            {
                dataBase.openConnection();


                string updateQuery = "UPDATE Student " +
                                     "SET First_name = @FirstName, Last_name = @LastName, Patronymic = @Patronymic, " +
                                     "StudyData_id = @StudyDataId, [Group] = @Group, " +
                                     "Course = @Course, Form_of_study = @FormOfStudy, Funding_type = @FundingType " +
                                     "WHERE Student_id = @StudentId";

                using (SqlCommand cmd = new SqlCommand(updateQuery, dataBase.getConnection()))
                {
                    
                    cmd.Parameters.AddWithValue("@FirstName", textBoxFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", textBoxLastName.Text);
                    cmd.Parameters.AddWithValue("@Patronymic", textBoxPatronymic.Text);

                    cmd.Parameters.AddWithValue("@StudyDataId", Convert.ToInt32(comboBoxStudyData.SelectedItem)); 
                    cmd.Parameters.AddWithValue("@Group", textBoxGroup.Text);
                    cmd.Parameters.AddWithValue("@Course", Convert.ToInt32(textBoxCourse.Text));
                    cmd.Parameters.AddWithValue("@FormOfStudy", comboBoxFormOfStudy.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@FundingType", comboBoxFundingType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@StudentId", studentId);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Дані студента оновлено успішно!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка оновлення даних студента: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }
    }
}
