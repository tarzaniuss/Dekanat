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
    public partial class StudyDataForm : Form
    {
        private int studentId;
        private DataBase dataBase = new DataBase();

        public StudyDataForm(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            LoadStudyData();
            StartPosition = FormStartPosition.CenterScreen;
            this.Select();
        }

        private void LoadStudyData()
        {
            try
            {
                dataBase.openConnection();

                string query = "SELECT SD.Field_of_study, SD.Faculty, SD.Specialty, SD.Tuition_fee_full_time, SD.Tuition_fee_part_time " +
                               "FROM Student AS S " +
                               "INNER JOIN StudyData AS SD ON S.StudyData_id = SD.StudyData_id " +
                               "WHERE S.Student_id = @studentId";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            labelFieldOfStudy.Text = reader["Field_of_study"].ToString();
                            labelFaculty.Text = reader["Faculty"].ToString();
                            labelSpecialty.Text = reader["Specialty"].ToString();
                            labelTuitionFeeFullTime.Text = reader["Tuition_fee_full_time"].ToString();
                            labelTuitionFeePartTime.Text = reader["Tuition_fee_part_time"].ToString();
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}