namespace Dekanat
{
    partial class EditDissertationForm
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
            this.buttonSaveChanges = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxTopicName = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerDefenseDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxAdvisor = new System.Windows.Forms.ComboBox();
            this.textBoxDegree = new System.Windows.Forms.TextBox();
            this.textBoxSpecialty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSaveChanges
            // 
            this.buttonSaveChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveChanges.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSaveChanges.Location = new System.Drawing.Point(348, 402);
            this.buttonSaveChanges.Name = "buttonSaveChanges";
            this.buttonSaveChanges.Size = new System.Drawing.Size(115, 31);
            this.buttonSaveChanges.TabIndex = 30;
            this.buttonSaveChanges.Text = "Зберегти";
            this.buttonSaveChanges.UseVisualStyleBackColor = true;
            this.buttonSaveChanges.Click += new System.EventHandler(this.buttonSaveChanges_Click_1);
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
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(833, 358);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Інформація про дисертацію";
            // 
            // textBoxTopicName
            // 
            this.textBoxTopicName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxTopicName.Location = new System.Drawing.Point(193, 60);
            this.textBoxTopicName.Name = "textBoxTopicName";
            this.textBoxTopicName.Size = new System.Drawing.Size(296, 26);
            this.textBoxTopicName.TabIndex = 0;
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxAuthor.Location = new System.Drawing.Point(193, 103);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(296, 26);
            this.textBoxAuthor.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(607, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 24);
            this.label7.TabIndex = 13;
            this.label7.Text = "Науковий керівник";
            // 
            // dateTimePickerDefenseDate
            // 
            this.dateTimePickerDefenseDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateTimePickerDefenseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateTimePickerDefenseDate.Location = new System.Drawing.Point(193, 246);
            this.dateTimePickerDefenseDate.Name = "dateTimePickerDefenseDate";
            this.dateTimePickerDefenseDate.Size = new System.Drawing.Size(296, 26);
            this.dateTimePickerDefenseDate.TabIndex = 14;
            this.dateTimePickerDefenseDate.Value = new System.DateTime(2023, 12, 16, 0, 2, 21, 0);
            // 
            // comboBoxAdvisor
            // 
            this.comboBoxAdvisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxAdvisor.FormattingEnabled = true;
            this.comboBoxAdvisor.Location = new System.Drawing.Point(563, 103);
            this.comboBoxAdvisor.Name = "comboBoxAdvisor";
            this.comboBoxAdvisor.Size = new System.Drawing.Size(259, 28);
            this.comboBoxAdvisor.TabIndex = 4;
            // 
            // textBoxDegree
            // 
            this.textBoxDegree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxDegree.Location = new System.Drawing.Point(193, 150);
            this.textBoxDegree.Name = "textBoxDegree";
            this.textBoxDegree.Size = new System.Drawing.Size(296, 26);
            this.textBoxDegree.TabIndex = 2;
            // 
            // textBoxSpecialty
            // 
            this.textBoxSpecialty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSpecialty.Location = new System.Drawing.Point(193, 198);
            this.textBoxSpecialty.Name = "textBoxSpecialty";
            this.textBoxSpecialty.Size = new System.Drawing.Size(296, 26);
            this.textBoxSpecialty.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(36, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 24);
            this.label6.TabIndex = 12;
            this.label6.Text = "Статус";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxStatus.Location = new System.Drawing.Point(193, 289);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(296, 26);
            this.textBoxStatus.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(36, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Захист";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(32, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Тема дисертації";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(32, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Спеціальність";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(32, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Автор";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(32, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ступінь";
            // 
            // EditDissertationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(857, 454);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSaveChanges);
            this.MaximumSize = new System.Drawing.Size(873, 493);
            this.MinimumSize = new System.Drawing.Size(873, 493);
            this.Name = "EditDissertationForm";
            this.Text = "Змінити дані про дисертацію";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveChanges;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxTopicName;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerDefenseDate;
        private System.Windows.Forms.ComboBox comboBoxAdvisor;
        private System.Windows.Forms.TextBox textBoxDegree;
        private System.Windows.Forms.TextBox textBoxSpecialty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}