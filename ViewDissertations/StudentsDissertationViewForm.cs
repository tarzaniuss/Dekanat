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
    public partial class StudentsDissertationViewForm : Form
    {
        private DataBase dataBase = new DataBase();

        public StudentsDissertationViewForm()
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
            // Оголошення стовпців для DataGridView
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

            foreach (DataGridViewColumn column in dataGridViewDissertationInfo.Columns)
            {
                column.ReadOnly = true;
            }
        }

        private void LoadDissertationInfoData()
        {
            try
            {
                dataBase.openConnection(); // Відкриття з'єднання перед виконанням операцій

                // Ваш SQL-запит для отримання даних з таблиці DissertationTopic
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

                    // Прив'язка даних до DataGridView
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

        private void StudentsDissertationViewForm_Load(object sender, EventArgs e)
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

        private void dataGridViewDissertationInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewDissertationInfo.Columns[3].Index && e.RowIndex >= 0)
            {

                string cellValue = dataGridViewDissertationInfo.Rows[e.RowIndex].Cells[3].Value.ToString();

                e.Value = $"{cellValue}";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
