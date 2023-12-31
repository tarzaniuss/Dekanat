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
    public partial class ContactInfoForm : Form
    {
        private int studentId;
        private DataBase dataBase = new DataBase();

        public ContactInfoForm(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;

            LoadContactInfo();
            StartPosition = FormStartPosition.CenterScreen;
            this.Select();
        }

        private void LoadContactInfo()
        {
            try
            {
                dataBase.openConnection();

                string query = "SELECT S.Last_name, S.First_name, S.Patronymic, CI.Phone_number, CI.Email " +
                               "FROM Student AS S " +
                               "INNER JOIN ContactInfo AS CI ON S.ContactInfo_id = CI.ContactInfo_id " +
                               "WHERE S.Student_id = @studentId";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            labelFullName.Text = $"{reader["Last_name"]} {reader["First_name"]} {reader["Patronymic"]}";
                            textBoxPhoneNumber.Text = reader["Phone_number"].ToString();
                            textBoxEmail.Text = reader["Email"].ToString();
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
    }
}