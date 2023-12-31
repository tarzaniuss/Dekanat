namespace Dekanat
{
    partial class AddDissertationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDissertationForm));
            this.textBoxTopicName = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.textBoxDegree = new System.Windows.Forms.TextBox();
            this.textBoxSpecialty = new System.Windows.Forms.TextBox();
            this.comboBoxAdvisor = new System.Windows.Forms.ComboBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerDefenseDate = new System.Windows.Forms.DateTimePicker();
            this.buttonAddDissertation = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTopicName
            // 
            resources.ApplyResources(this.textBoxTopicName, "textBoxTopicName");
            this.textBoxTopicName.Name = "textBoxTopicName";
            // 
            // textBoxAuthor
            // 
            resources.ApplyResources(this.textBoxAuthor, "textBoxAuthor");
            this.textBoxAuthor.Name = "textBoxAuthor";
            // 
            // textBoxDegree
            // 
            resources.ApplyResources(this.textBoxDegree, "textBoxDegree");
            this.textBoxDegree.Name = "textBoxDegree";
            // 
            // textBoxSpecialty
            // 
            resources.ApplyResources(this.textBoxSpecialty, "textBoxSpecialty");
            this.textBoxSpecialty.Name = "textBoxSpecialty";
            // 
            // comboBoxAdvisor
            // 
            resources.ApplyResources(this.comboBoxAdvisor, "comboBoxAdvisor");
            this.comboBoxAdvisor.FormattingEnabled = true;
            this.comboBoxAdvisor.Name = "comboBoxAdvisor";
            // 
            // textBoxStatus
            // 
            resources.ApplyResources(this.textBoxStatus, "textBoxStatus");
            this.textBoxStatus.Name = "textBoxStatus";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // dateTimePickerDefenseDate
            // 
            resources.ApplyResources(this.dateTimePickerDefenseDate, "dateTimePickerDefenseDate");
            this.dateTimePickerDefenseDate.Name = "dateTimePickerDefenseDate";
            this.dateTimePickerDefenseDate.Value = new System.DateTime(2023, 12, 16, 0, 2, 21, 0);
            // 
            // buttonAddDissertation
            // 
            resources.ApplyResources(this.buttonAddDissertation, "buttonAddDissertation");
            this.buttonAddDissertation.Name = "buttonAddDissertation";
            this.buttonAddDissertation.UseVisualStyleBackColor = true;
            this.buttonAddDissertation.Click += new System.EventHandler(this.buttonAddDissertation_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxTopicName);
            this.groupBox1.Controls.Add(this.textBoxAuthor);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dateTimePickerDefenseDate);
            this.groupBox1.Controls.Add(this.comboBoxAdvisor);
            this.groupBox1.Controls.Add(this.textBoxDegree);
            this.groupBox1.Controls.Add(this.textBoxSpecialty);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxStatus);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // AddDissertationForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonAddDissertation);
            this.Name = "AddDissertationForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTopicName;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.TextBox textBoxDegree;
        private System.Windows.Forms.TextBox textBoxSpecialty;
        private System.Windows.Forms.ComboBox comboBoxAdvisor;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerDefenseDate;
        private System.Windows.Forms.Button buttonAddDissertation;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}