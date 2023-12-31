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
    public partial class LoginForm : Form
    {
        DataBase dataBase = new DataBase();

        public LoginForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '●';
            pictureBox_visible_pass.Visible = false;
            textBox_login.MaxLength = 50;
            textBox_password.MaxLength = 50;

        }

        private void button_logIn_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_login.Text;
            var passUser = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();


            string studentQuery = $"SELECT * FROM Student WHERE [Login] = '{loginUser}' AND [Password] = '{passUser}'";
            adapter = new SqlDataAdapter(studentQuery, dataBase.getConnection());
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                int studentId = Convert.ToInt32(table.Rows[0]["Student_id"]);
                StudentsMenuForm form3 = new StudentsMenuForm(studentId);
                form3.Show();
                this.Hide(); 
            }
            else
            {
                string deanaryQuery = $"SELECT * FROM DeanaryEmployee WHERE [Login] = '{loginUser}' AND [Password] = '{passUser}'";
                adapter = new SqlDataAdapter(deanaryQuery, dataBase.getConnection());
                table.Clear();
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    MenuForm form2 = new MenuForm();
                    form2.Show();
                    this.Hide(); 
                }
                else
                {
                    MessageBox.Show("Invalid login or password. Please try again.");
                }
            }

        }

        private void pictureBox_unvisible_pass_Click(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '\0';
            pictureBox_unvisible_pass.Visible = false;
            pictureBox_visible_pass.Visible = true;
        }

        private void pictureBox_visible_pass_Click(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '●';
            pictureBox_unvisible_pass.Visible = true;
            pictureBox_visible_pass.Visible = false;
        }
    }
}