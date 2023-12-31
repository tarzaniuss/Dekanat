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
    public partial class EditDissertationForm : Form
    {
        private int dissertationId;
        private DataBase dataBase = new DataBase();

        public EditDissertationForm(int dissertationId)
        {
            InitializeComponent();
            this.dissertationId = dissertationId;
            LoadAdvisorsIntoComboBox();
            LoadDissertationData();

        }

        private void LoadDissertationData()
        {
            try
            {
                dataBase.openConnection();

                string query = "SELECT * FROM DissertationTopic WHERE DissertationTopic_id = @DissertationId";
                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@DissertationId", dissertationId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            textBoxTopicName.Text = reader["Topic_name"].ToString();
                            textBoxAuthor.Text = reader["Author"].ToString();
                            textBoxSpecialty.Text = reader["Specialty"].ToString();
                            textBoxDegree.Text = reader["Degree"].ToString();
                            dateTimePickerDefenseDate.Text = reader["Defense_date"].ToString();
                            textBoxStatus.Text = reader["Status"].ToString();

                            int advisorId = Convert.ToInt32(reader["ResearchAdvisor_id"]);

                            foreach (DataRowView item in comboBoxAdvisor.Items)
                            {
                                if (Convert.ToInt32(item["ResearchAdvisor_id"]) == advisorId)
                                {
                                    comboBoxAdvisor.SelectedItem = item;
                                    break;
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dissertation data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void buttonSaveChanges_Click_1(object sender, EventArgs e)
        {
            try
            {
                dataBase.openConnection();

                string updateQuery = "UPDATE DissertationTopic SET Topic_name = @TopicName, Author = @Author, " +
                                     "Specialty = @Specialty, Degree = @Degree, Defense_date = @DefenseDate, " +
                                     "ResearchAdvisor_id = @AdvisorId, Status = @Status WHERE DissertationTopic_id = @DissertationId";
                using (SqlCommand command = new SqlCommand(updateQuery, dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@TopicName", textBoxTopicName.Text);
                    command.Parameters.AddWithValue("@Author", textBoxAuthor.Text);
                    command.Parameters.AddWithValue("@Specialty", textBoxSpecialty.Text);
                    command.Parameters.AddWithValue("@Degree", textBoxDegree.Text);
                    command.Parameters.AddWithValue("@DefenseDate", dateTimePickerDefenseDate.Value);
                    command.Parameters.AddWithValue("@AdvisorId", Convert.ToInt32(comboBoxAdvisor.SelectedValue));
                    command.Parameters.AddWithValue("@Status", textBoxStatus.Text);
                    command.Parameters.AddWithValue("@DissertationId", dissertationId);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving changes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }
    }
}
