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
    public partial class DissertationInfoForm : Form
    {
        private DataBase dataBase = new DataBase();

        public DissertationInfoForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dataGridViewDissertationInfo.AllowUserToAddRows = false;
            CreateColumns();
            dataGridViewDissertationInfo.CellClick += dataGridViewDissertationInfo_CellClick;
            dataGridViewDissertationInfo.CellFormatting += dataGridViewDissertationInfo_CellFormatting;
        }

        private void CreateColumns()
        {
            DataGridViewTextBoxColumn dissertationIdColumn = new DataGridViewTextBoxColumn();
            dissertationIdColumn.HeaderText = "ID дисертації";
            dissertationIdColumn.DataPropertyName = "DissertationTopic_id";
            dissertationIdColumn.ReadOnly = true;
            dataGridViewDissertationInfo.Columns.Add(dissertationIdColumn);

            DataGridViewTextBoxColumn topicNameColumn = new DataGridViewTextBoxColumn();
            topicNameColumn.HeaderText = "Назва дисертації";
            topicNameColumn.DataPropertyName = "Topic_name";
            dataGridViewDissertationInfo.Columns.Add(topicNameColumn);

            DataGridViewTextBoxColumn authorColumn = new DataGridViewTextBoxColumn();
            authorColumn.HeaderText = "Автор";
            authorColumn.DataPropertyName = "Author";
            dataGridViewDissertationInfo.Columns.Add(authorColumn);

            DataGridViewLinkColumn advisorColumn = new DataGridViewLinkColumn();
            advisorColumn.HeaderText = "Керівник";
            advisorColumn.DataPropertyName = "Advisor";
            dataGridViewDissertationInfo.Columns.Add(advisorColumn);

            DataGridViewTextBoxColumn specialtyColumn = new DataGridViewTextBoxColumn();
            specialtyColumn.HeaderText = "Спеціальність";
            specialtyColumn.DataPropertyName = "Specialty";
            dataGridViewDissertationInfo.Columns.Add(specialtyColumn);

            DataGridViewTextBoxColumn degreeColumn = new DataGridViewTextBoxColumn();
            degreeColumn.HeaderText = "Ступінь";
            degreeColumn.DataPropertyName = "Degree";
            dataGridViewDissertationInfo.Columns.Add(degreeColumn);

            DataGridViewTextBoxColumn defenseDateColumn = new DataGridViewTextBoxColumn();
            defenseDateColumn.HeaderText = "Дата захисту";
            defenseDateColumn.DataPropertyName = "Defense_date";
            dataGridViewDissertationInfo.Columns.Add(defenseDateColumn);

            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.HeaderText = "Статус";
            statusColumn.DataPropertyName = "Status";
            dataGridViewDissertationInfo.Columns.Add(statusColumn);
        }

        private void LoadDissertationInfoData()
        {
            try
            {
                dataBase.openConnection(); 

                string query = "SELECT dt.DissertationTopic_id, dt.Topic_name, dt.Author, " +
                               "CONCAT(ra.Last_name, ' ', ra.First_name, ' ', ra.Patronymic) AS Advisor, " +
                               "dt.Specialty, dt.Degree, dt.Defense_date, dt.Status " +
                               "FROM DissertationTopic dt " +
                               "INNER JOIN ResearchAdvisor ra ON dt.ResearchAdvisor_id = ra.ResearchAdvisor_id";

                dataGridViewDissertationInfo.AutoGenerateColumns = false;

                if (!string.IsNullOrEmpty(textBoxTopic.Text))
                {
                    string selectedFaculty = textBoxTopic.Text;
                    query += $" AND dt.Topic_name LIKE '%{selectedFaculty}%'";

                }

                if (!string.IsNullOrEmpty(textBoxAuthor.Text))
                {
                    string selectedAuthor = textBoxAuthor.Text;
                    query += $" AND dt.Author LIKE '%{selectedAuthor}%'";

                }

                if (!string.IsNullOrEmpty(textBoxAdvisor.Text))
                {
                    string searchKeyword = textBoxAdvisor.Text.Trim();
                    query += $" AND CONCAT(ra.Last_name, ' ', ra.First_name, ' ', ra.Patronymic) LIKE '%{searchKeyword}%'";
                }

                if (!string.IsNullOrEmpty(textBoxSpecialty.Text))
                {
                    string selectedSpecialty = textBoxSpecialty.Text;
                    query += $" AND dt.Specialty LIKE '%{selectedSpecialty}%'";

                }


                using (SqlDataAdapter adapter = new SqlDataAdapter(query, dataBase.getConnection()))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewDissertationInfo.DataSource = dataTable;
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

        private void DissertationInfoForm_Load(object sender, EventArgs e)
        {
            LoadDissertationInfoData();
        }

        private void dataGridViewDissertationInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewDissertationInfo.Columns[3].Index && e.RowIndex >= 0)
            {
                string advisorName = dataGridViewDissertationInfo.Rows[e.RowIndex].Cells[3].Value.ToString();

                // Здійснюємо запит до бази даних для отримання ідентифікатора керівника за його ПІБ
                int advisorId = GetAdvisorIdByName(advisorName);

                // Відкликання нової форми для відображення інформації про керівника
                ResearchAdvisorInfoForm advisorInfoForm = new ResearchAdvisorInfoForm(advisorId);
                advisorInfoForm.Show();
            }
        }

        private int GetAdvisorIdByName(string advisorName)
        {
            try
            {
                dataBase.openConnection();

                string query = "SELECT ResearchAdvisor_id FROM ResearchAdvisor WHERE CONCAT(Last_name, ' ', First_name, ' ', Patronymic) = @AdvisorName";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@AdvisorName", advisorName);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToInt32(result);
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

            return -1; // Повертаємо -1 як помилку або якщо ідентифікатор не знайдено
        }

        private void dataGridViewDissertationInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewDissertationInfo.Columns[3].Index && e.RowIndex >= 0)
            {
   
                string cellValue = dataGridViewDissertationInfo.Rows[e.RowIndex].Cells[3].Value.ToString();

                e.Value = $"{cellValue}";
            }
        }

        private void RefreshDataGridView()
        {
            dataGridViewDissertationInfo.DataSource = null;
            dataGridViewDissertationInfo.Rows.Clear();

            LoadDissertationInfoData();
        }

        private void ResetFilters()
        {
            textBoxTopic.Text = string.Empty;
            textBoxAuthor.Text = string.Empty;
            textBoxAdvisor.Text = string.Empty;
            textBoxSpecialty.Text = string.Empty;
            // Очистіть інші елементи фільтрації, якщо вони є
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
            RefreshDataGridView();
        }

        private void buttonDeleteDissertation_Click(object sender, EventArgs e)
        {
            if (dataGridViewDissertationInfo.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected dissertation(s)?",
                                                      "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Iterate through all selected rows and delete each dissertation
                    foreach (DataGridViewRow row in dataGridViewDissertationInfo.SelectedRows)
                    {
                        int dissertationId = Convert.ToInt32(row.Cells[0].Value);
                        // Implement a method to delete the dissertation from the database
                        DeleteDissertation(dissertationId);
                    }

                    // Refresh the DataGridView after deleting
                    RefreshDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Please select at least one dissertation to delete.",
                                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteDissertation(int dissertationId)
        {
            try
            {
                // Implement the SQL DELETE statement to delete the dissertation
                string query = "DELETE FROM DissertationTopic WHERE DissertationTopic_id = @DissertationId";

                using (SqlCommand command = new SqlCommand(query, dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@DissertationId", dissertationId);
                    dataBase.openConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting dissertation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
            }
        }

        private void buttonAddDissertation_Click(object sender, EventArgs e)
        {
            AddDissertationForm addDissertationForm = new AddDissertationForm();
            addDissertationForm.ShowDialog();

            RefreshDataGridView();
        }

        private void buttonEditDissertation_Click(object sender, EventArgs e)
        {
            if (dataGridViewDissertationInfo.SelectedRows.Count > 0)
            {

                int dissertationId = Convert.ToInt32(dataGridViewDissertationInfo.SelectedRows[0].Cells[0].Value);

                EditDissertationForm editDissertationForm = new EditDissertationForm(dissertationId);
                editDissertationForm.ShowDialog();

                RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Please select a dissertation to edit.",
                                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
