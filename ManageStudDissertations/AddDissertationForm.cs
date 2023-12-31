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
    public partial class AddDissertationForm : Form
    {
        private DataBase dataBase = new DataBase();

        public AddDissertationForm()
        {
            InitializeComponent();
            LoadAdvisorsIntoComboBox();

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonAddDissertation_Click(object sender, EventArgs e)
        {
            try
            {
                dataBase.openConnection();

                string insertQuery = "INSERT INTO DissertationTopic (Topic_name, Author, Specialty, Degree, Defense_date, ResearchAdvisor_id, Status) " +
                                     "VALUES (@TopicName, @Author, @Specialty, @Degree, @DefenseDate, @AdvisorId, @Status)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, dataBase.getConnection()))
                {
                    cmd.Parameters.AddWithValue("@TopicName", textBoxTopicName.Text);
                    cmd.Parameters.AddWithValue("@Author", textBoxAuthor.Text);
                    cmd.Parameters.AddWithValue("@Specialty", textBoxSpecialty.Text);
                    cmd.Parameters.AddWithValue("@Degree", textBoxDegree.Text);
                    cmd.Parameters.AddWithValue("@DefenseDate", dateTimePickerDefenseDate.Value);
                    cmd.Parameters.AddWithValue("@AdvisorId", Convert.ToInt32(comboBoxAdvisor.SelectedValue));
                    cmd.Parameters.AddWithValue("@Status", textBoxStatus.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Dissertation added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }

        }

        private void LoadAdvisorsIntoComboBox()
        {
            try
            {
                dataBase.openConnection();

                string query = "SELECT ResearchAdvisor_id, CONCAT(Last_name, ', ', First_name, ' ', Patronymic) AS AdvisorName FROM ResearchAdvisor";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, dataBase.getConnection()))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the data to the combo box
                    comboBoxAdvisor.DisplayMember = "AdvisorName";
                    comboBoxAdvisor.ValueMember = "ResearchAdvisor_id";
                    comboBoxAdvisor.DataSource = dataTable;
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
