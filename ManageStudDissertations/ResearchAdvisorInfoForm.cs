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
    public partial class ResearchAdvisorInfoForm : Form
    {
        private int advisorId;
        private DataBase dataBase = new DataBase();

        public ResearchAdvisorInfoForm(int ResearchAdvisorId)
        {
            InitializeComponent();
            this.advisorId = ResearchAdvisorId;
            LoadAdvisorData();
            StartPosition = FormStartPosition.CenterScreen;
            this.Select();
        }

        private void LoadAdvisorData()
        {
            try
            {
                dataBase.openConnection();

                string query = "SELECT RA.First_name, RA.Last_name, RA.Patronymic, RA.Academic_degree, RA.Academic_rank, RA.Scientific_interests, CI.Phone_number, CI.Email " +
                               "FROM ResearchAdvisor AS RA " +
                               "INNER JOIN ContactInfo AS CI ON RA.ContactInfo_id = CI.ContactInfo_id " +
                               "WHERE RA.ResearchAdvisor_id = @advisorId";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@advisorId", advisorId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string fullName = $"{reader["Last_name"]} {reader["First_name"]} {reader["Patronymic"]}";
                            labelFullName.Text = fullName;
                            labelAcademicDegree.Text = reader["Academic_degree"].ToString();
                            labelAcademicRank.Text = reader["Academic_rank"].ToString();
                            labelScientificInterests.Text = reader["Scientific_interests"].ToString();
                            labelPhoneNumber.Text = reader["Phone_number"].ToString();
                            labelEmail.Text = reader["Email"].ToString();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
