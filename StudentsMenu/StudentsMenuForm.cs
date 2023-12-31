using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dekanat
{
    public partial class StudentsMenuForm : Form
    {
        private int studentId;
        private Button currentButton;

        public StudentsMenuForm(int studentId)
        {
            this.studentId = studentId;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            InitializeMenuButtons();
            OpenForm(new HomeForm());
            labelTitleBar.Text = "Головна сторінка";
        }

        private void InitializeMenuButtons()
        {
            foreach (Control control in panelMenu.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button)control;
                    button.Click += MenuButton_Click;
                }
            }

            foreach (Control control in panel1.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button)control;
                    button.Click += MenuButton_Click;
                }
            }
        }

        private void OpenCorrespondingForm(Button clickedButton)
        {

            if (clickedButton.Name == "buttonDissertation")
            {
                StudentsDissertationViewForm disForm = new StudentsDissertationViewForm();
                OpenForm(disForm);
                labelTitleBar.Text = "Дисертації випускників";
            }
            else if (clickedButton.Name == "buttonHome")
            {
                HomeForm homeForm = new HomeForm();
                OpenForm(homeForm);
                labelTitleBar.Text = "Головна сторінка";
            }
            else if (clickedButton.Name == "buttonMyInfo")
            {
                StudentsInfoForm homeForm = new StudentsInfoForm(studentId);
                OpenForm(homeForm);
                labelTitleBar.Text = "Мої дані";
            }

        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (currentButton != null)
                currentButton.BackColor = Color.FromArgb(153, 180, 209);

            if (clickedButton.Name == "buttonHome")
            {
                OpenCorrespondingForm(clickedButton);
                return;
            }

            currentButton = clickedButton;
            currentButton.BackColor = Color.FromArgb(137, 161, 188);

            OpenCorrespondingForm(clickedButton);
        }

        private void OpenForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelFormSpace.Controls.Add(childForm);
            this.panelFormSpace.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void buttonMyInfo_Click(object sender, EventArgs e)
        {

        }

        private void buttonHome_Click(object sender, EventArgs e)
        {

        }

        private void buttonDissertation_Click(object sender, EventArgs e)
        {

        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {

        }
    }
}
