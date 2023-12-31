namespace Dekanat
{
    partial class PaymentInfoForm
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
            this.dataGridViewPaymentInfo = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxPaymentStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.comboBoxFaculty = new System.Windows.Forms.ComboBox();
            this.buttonResetFilters = new System.Windows.Forms.Button();
            this.comboBoxCourse = new System.Windows.Forms.ComboBox();
            this.buttonApplyFilters = new System.Windows.Forms.Button();
            this.comboBoxSpecialty = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonUpdateRatingFromExcel = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonSaveToExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPaymentInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewPaymentInfo
            // 
            this.dataGridViewPaymentInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPaymentInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPaymentInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPaymentInfo.Location = new System.Drawing.Point(70, 25);
            this.dataGridViewPaymentInfo.Name = "dataGridViewPaymentInfo";
            this.dataGridViewPaymentInfo.Size = new System.Drawing.Size(940, 320);
            this.dataGridViewPaymentInfo.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxPaymentStatus);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxGroup);
            this.groupBox1.Controls.Add(this.comboBoxFaculty);
            this.groupBox1.Controls.Add(this.buttonResetFilters);
            this.groupBox1.Controls.Add(this.comboBoxCourse);
            this.groupBox1.Controls.Add(this.buttonApplyFilters);
            this.groupBox1.Controls.Add(this.comboBoxSpecialty);
            this.groupBox1.Controls.Add(this.textBoxSearch);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(70, 374);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 211);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фільтр";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(370, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "Статус оплати";
            // 
            // comboBoxPaymentStatus
            // 
            this.comboBoxPaymentStatus.FormattingEnabled = true;
            this.comboBoxPaymentStatus.Location = new System.Drawing.Point(365, 142);
            this.comboBoxPaymentStatus.Name = "comboBoxPaymentStatus";
            this.comboBoxPaymentStatus.Size = new System.Drawing.Size(137, 24);
            this.comboBoxPaymentStatus.TabIndex = 26;
            this.comboBoxPaymentStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxPaymentStatus_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(350, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Група";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(350, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Курс";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Пошук за ПІБ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(6, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Спеціальність";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Факультет";
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(408, 64);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(94, 24);
            this.comboBoxGroup.TabIndex = 5;
            // 
            // comboBoxFaculty
            // 
            this.comboBoxFaculty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxFaculty.FormattingEnabled = true;
            this.comboBoxFaculty.Location = new System.Drawing.Point(128, 20);
            this.comboBoxFaculty.Name = "comboBoxFaculty";
            this.comboBoxFaculty.Size = new System.Drawing.Size(140, 24);
            this.comboBoxFaculty.TabIndex = 4;
            this.comboBoxFaculty.SelectedIndexChanged += new System.EventHandler(this.comboBoxFaculty_SelectedIndexChanged);
            // 
            // buttonResetFilters
            // 
            this.buttonResetFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonResetFilters.Location = new System.Drawing.Point(215, 172);
            this.buttonResetFilters.Name = "buttonResetFilters";
            this.buttonResetFilters.Size = new System.Drawing.Size(126, 30);
            this.buttonResetFilters.TabIndex = 10;
            this.buttonResetFilters.Text = "Зкинути фільтри";
            this.buttonResetFilters.UseVisualStyleBackColor = true;
            this.buttonResetFilters.Click += new System.EventHandler(this.buttonResetFilters_Click);
            // 
            // comboBoxCourse
            // 
            this.comboBoxCourse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxCourse.FormattingEnabled = true;
            this.comboBoxCourse.Location = new System.Drawing.Point(408, 24);
            this.comboBoxCourse.Name = "comboBoxCourse";
            this.comboBoxCourse.Size = new System.Drawing.Size(94, 24);
            this.comboBoxCourse.TabIndex = 6;
            this.comboBoxCourse.SelectedIndexChanged += new System.EventHandler(this.comboBoxCourse_SelectedIndexChanged);
            // 
            // buttonApplyFilters
            // 
            this.buttonApplyFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonApplyFilters.Location = new System.Drawing.Point(80, 172);
            this.buttonApplyFilters.Name = "buttonApplyFilters";
            this.buttonApplyFilters.Size = new System.Drawing.Size(121, 31);
            this.buttonApplyFilters.TabIndex = 9;
            this.buttonApplyFilters.Text = "Пошук";
            this.buttonApplyFilters.UseVisualStyleBackColor = true;
            this.buttonApplyFilters.Click += new System.EventHandler(this.buttonApplyFilters_Click);
            // 
            // comboBoxSpecialty
            // 
            this.comboBoxSpecialty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxSpecialty.FormattingEnabled = true;
            this.comboBoxSpecialty.Location = new System.Drawing.Point(128, 64);
            this.comboBoxSpecialty.Name = "comboBoxSpecialty";
            this.comboBoxSpecialty.Size = new System.Drawing.Size(140, 24);
            this.comboBoxSpecialty.TabIndex = 7;
            this.comboBoxSpecialty.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpecialty_SelectedIndexChanged);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSearch.Location = new System.Drawing.Point(128, 116);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(140, 22);
            this.textBoxSearch.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.buttonUpdateRatingFromExcel);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(806, 374);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(204, 95);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Робота з даними";
            // 
            // buttonUpdateRatingFromExcel
            // 
            this.buttonUpdateRatingFromExcel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonUpdateRatingFromExcel.Location = new System.Drawing.Point(6, 31);
            this.buttonUpdateRatingFromExcel.Name = "buttonUpdateRatingFromExcel";
            this.buttonUpdateRatingFromExcel.Size = new System.Drawing.Size(178, 40);
            this.buttonUpdateRatingFromExcel.TabIndex = 20;
            this.buttonUpdateRatingFromExcel.Text = "Оновити дані з файлу";
            this.buttonUpdateRatingFromExcel.UseVisualStyleBackColor = true;
            this.buttonUpdateRatingFromExcel.Click += new System.EventHandler(this.buttonUpdateRatingFromExcel_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.buttonSaveToExcel);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(806, 490);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(204, 95);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Збереження";
            // 
            // buttonSaveToExcel
            // 
            this.buttonSaveToExcel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSaveToExcel.Location = new System.Drawing.Point(6, 33);
            this.buttonSaveToExcel.Name = "buttonSaveToExcel";
            this.buttonSaveToExcel.Size = new System.Drawing.Size(178, 40);
            this.buttonSaveToExcel.TabIndex = 26;
            this.buttonSaveToExcel.Text = "Зберегти список у excel";
            this.buttonSaveToExcel.UseVisualStyleBackColor = true;
            this.buttonSaveToExcel.Click += new System.EventHandler(this.buttonSaveToExcel_Click);
            // 
            // PaymentInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1079, 611);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewPaymentInfo);
            this.Name = "PaymentInfoForm";
            this.Text = "PaymentInfoForm";
            this.Load += new System.EventHandler(this.PaymentInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPaymentInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPaymentInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.ComboBox comboBoxFaculty;
        private System.Windows.Forms.Button buttonResetFilters;
        private System.Windows.Forms.ComboBox comboBoxCourse;
        private System.Windows.Forms.Button buttonApplyFilters;
        private System.Windows.Forms.ComboBox comboBoxSpecialty;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonUpdateRatingFromExcel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonSaveToExcel;
        private System.Windows.Forms.ComboBox comboBoxPaymentStatus;
        private System.Windows.Forms.Label label6;
    }
}