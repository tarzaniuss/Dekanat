namespace Dekanat
{
    partial class StudentsRating
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
            this.dataGridViewStudRating = new System.Windows.Forms.DataGridView();
            this.numericUpDownMinGrade = new System.Windows.Forms.NumericUpDown();
            this.buttonUpdateRatingFromExcel = new System.Windows.Forms.Button();
            this.radioButtonGreater = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonLess = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonNAless = new System.Windows.Forms.RadioButton();
            this.radioButtonNAgreater = new System.Windows.Forms.RadioButton();
            this.numericUpDownNA = new System.Windows.Forms.NumericUpDown();
            this.buttonSaveToExcel = new System.Windows.Forms.Button();
            this.comboBoxFundingType = new System.Windows.Forms.ComboBox();
            this.buttonApplyFilters = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonResetFilters = new System.Windows.Forms.Button();
            this.comboBoxSpecialty = new System.Windows.Forms.ComboBox();
            this.comboBoxCourse = new System.Windows.Forms.ComboBox();
            this.comboBoxFaculty = new System.Windows.Forms.ComboBox();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudRating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinGrade)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNA)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewStudRating
            // 
            this.dataGridViewStudRating.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStudRating.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStudRating.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudRating.Location = new System.Drawing.Point(70, 25);
            this.dataGridViewStudRating.Name = "dataGridViewStudRating";
            this.dataGridViewStudRating.Size = new System.Drawing.Size(940, 320);
            this.dataGridViewStudRating.TabIndex = 1;
            // 
            // numericUpDownMinGrade
            // 
            this.numericUpDownMinGrade.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.numericUpDownMinGrade.Location = new System.Drawing.Point(81, 41);
            this.numericUpDownMinGrade.Name = "numericUpDownMinGrade";
            this.numericUpDownMinGrade.Size = new System.Drawing.Size(75, 22);
            this.numericUpDownMinGrade.TabIndex = 19;
            this.numericUpDownMinGrade.ValueChanged += new System.EventHandler(this.numericUpDownMinGrade_ValueChanged);
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
            // radioButtonGreater
            // 
            this.radioButtonGreater.AutoSize = true;
            this.radioButtonGreater.Location = new System.Drawing.Point(6, 31);
            this.radioButtonGreater.Name = "radioButtonGreater";
            this.radioButtonGreater.Size = new System.Drawing.Size(69, 20);
            this.radioButtonGreater.TabIndex = 23;
            this.radioButtonGreater.TabStop = true;
            this.radioButtonGreater.Text = "Більше";
            this.radioButtonGreater.UseVisualStyleBackColor = true;
            this.radioButtonGreater.CheckedChanged += new System.EventHandler(this.radioButtonGreater_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.radioButtonLess);
            this.groupBox2.Controls.Add(this.radioButtonGreater);
            this.groupBox2.Controls.Add(this.numericUpDownMinGrade);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(612, 374);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 95);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Бал";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // radioButtonLess
            // 
            this.radioButtonLess.AutoSize = true;
            this.radioButtonLess.Location = new System.Drawing.Point(6, 54);
            this.radioButtonLess.Name = "radioButtonLess";
            this.radioButtonLess.Size = new System.Drawing.Size(69, 20);
            this.radioButtonLess.TabIndex = 24;
            this.radioButtonLess.TabStop = true;
            this.radioButtonLess.Text = "Менше";
            this.radioButtonLess.UseVisualStyleBackColor = true;
            this.radioButtonLess.CheckedChanged += new System.EventHandler(this.radioButtonLess_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.radioButtonNAless);
            this.groupBox3.Controls.Add(this.radioButtonNAgreater);
            this.groupBox3.Controls.Add(this.numericUpDownNA);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(612, 490);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(174, 95);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Н/А";
            // 
            // radioButtonNAless
            // 
            this.radioButtonNAless.AutoSize = true;
            this.radioButtonNAless.Location = new System.Drawing.Point(6, 56);
            this.radioButtonNAless.Name = "radioButtonNAless";
            this.radioButtonNAless.Size = new System.Drawing.Size(69, 20);
            this.radioButtonNAless.TabIndex = 24;
            this.radioButtonNAless.TabStop = true;
            this.radioButtonNAless.Text = "Менше";
            this.radioButtonNAless.UseVisualStyleBackColor = true;
            this.radioButtonNAless.CheckedChanged += new System.EventHandler(this.radioButtonNAless_CheckedChanged);
            // 
            // radioButtonNAgreater
            // 
            this.radioButtonNAgreater.AutoSize = true;
            this.radioButtonNAgreater.Location = new System.Drawing.Point(6, 33);
            this.radioButtonNAgreater.Name = "radioButtonNAgreater";
            this.radioButtonNAgreater.Size = new System.Drawing.Size(69, 20);
            this.radioButtonNAgreater.TabIndex = 23;
            this.radioButtonNAgreater.TabStop = true;
            this.radioButtonNAgreater.Text = "Більше";
            this.radioButtonNAgreater.UseVisualStyleBackColor = true;
            this.radioButtonNAgreater.CheckedChanged += new System.EventHandler(this.radioButtonNAgreater_CheckedChanged);
            // 
            // numericUpDownNA
            // 
            this.numericUpDownNA.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.numericUpDownNA.Location = new System.Drawing.Point(81, 43);
            this.numericUpDownNA.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownNA.Name = "numericUpDownNA";
            this.numericUpDownNA.Size = new System.Drawing.Size(75, 22);
            this.numericUpDownNA.TabIndex = 19;
            this.numericUpDownNA.ValueChanged += new System.EventHandler(this.numericUpDownNA_ValueChanged);
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
            // comboBoxFundingType
            // 
            this.comboBoxFundingType.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBoxFundingType.FormattingEnabled = true;
            this.comboBoxFundingType.Location = new System.Drawing.Point(371, 142);
            this.comboBoxFundingType.Name = "comboBoxFundingType";
            this.comboBoxFundingType.Size = new System.Drawing.Size(120, 24);
            this.comboBoxFundingType.TabIndex = 27;
            this.comboBoxFundingType.SelectedIndexChanged += new System.EventHandler(this.comboBoxFundingType_SelectedIndexChanged);
            // 
            // buttonApplyFilters
            // 
            this.buttonApplyFilters.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonApplyFilters.Location = new System.Drawing.Point(80, 172);
            this.buttonApplyFilters.Name = "buttonApplyFilters";
            this.buttonApplyFilters.Size = new System.Drawing.Size(110, 30);
            this.buttonApplyFilters.TabIndex = 16;
            this.buttonApplyFilters.Text = "Пошук";
            this.buttonApplyFilters.UseVisualStyleBackColor = true;
            this.buttonApplyFilters.Click += new System.EventHandler(this.buttonApplyFilters_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxSearch.Location = new System.Drawing.Point(128, 116);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(140, 22);
            this.textBoxSearch.TabIndex = 15;
            // 
            // buttonResetFilters
            // 
            this.buttonResetFilters.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonResetFilters.Location = new System.Drawing.Point(215, 172);
            this.buttonResetFilters.Name = "buttonResetFilters";
            this.buttonResetFilters.Size = new System.Drawing.Size(126, 30);
            this.buttonResetFilters.TabIndex = 17;
            this.buttonResetFilters.Text = "Зкинути фільтри";
            this.buttonResetFilters.UseVisualStyleBackColor = true;
            this.buttonResetFilters.Click += new System.EventHandler(this.buttonResetFilters_Click);
            // 
            // comboBoxSpecialty
            // 
            this.comboBoxSpecialty.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBoxSpecialty.FormattingEnabled = true;
            this.comboBoxSpecialty.Location = new System.Drawing.Point(128, 64);
            this.comboBoxSpecialty.Name = "comboBoxSpecialty";
            this.comboBoxSpecialty.Size = new System.Drawing.Size(140, 24);
            this.comboBoxSpecialty.TabIndex = 14;
            this.comboBoxSpecialty.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpecialty_SelectedIndexChanged);
            // 
            // comboBoxCourse
            // 
            this.comboBoxCourse.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBoxCourse.FormattingEnabled = true;
            this.comboBoxCourse.Location = new System.Drawing.Point(408, 24);
            this.comboBoxCourse.Name = "comboBoxCourse";
            this.comboBoxCourse.Size = new System.Drawing.Size(94, 24);
            this.comboBoxCourse.TabIndex = 13;
            this.comboBoxCourse.SelectedIndexChanged += new System.EventHandler(this.comboBoxCourse_SelectedIndexChanged);
            // 
            // comboBoxFaculty
            // 
            this.comboBoxFaculty.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBoxFaculty.FormattingEnabled = true;
            this.comboBoxFaculty.Location = new System.Drawing.Point(128, 20);
            this.comboBoxFaculty.Name = "comboBoxFaculty";
            this.comboBoxFaculty.Size = new System.Drawing.Size(140, 24);
            this.comboBoxFaculty.TabIndex = 11;
            this.comboBoxFaculty.SelectedIndexChanged += new System.EventHandler(this.comboBoxFaculty_SelectedIndexChanged);
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(408, 64);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(94, 24);
            this.comboBoxGroup.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.comboBoxFundingType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxGroup);
            this.groupBox1.Controls.Add(this.comboBoxFaculty);
            this.groupBox1.Controls.Add(this.comboBoxCourse);
            this.groupBox1.Controls.Add(this.comboBoxSpecialty);
            this.groupBox1.Controls.Add(this.buttonResetFilters);
            this.groupBox1.Controls.Add(this.textBoxSearch);
            this.groupBox1.Controls.Add(this.buttonApplyFilters);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(70, 374);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 211);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фільтр";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(350, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Курс";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(350, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Група";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Факультет";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(6, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Спеціальність";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Пошук за ПІБ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(357, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Тип фінансування";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.buttonUpdateRatingFromExcel);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(806, 374);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(204, 95);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Робота з даними";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.buttonSaveToExcel);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(806, 490);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(204, 95);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Збереження";
            // 
            // StudentsRating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1079, 611);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewStudRating);
            this.Name = "StudentsRating";
            this.Text = "StudentsRating";
            this.Load += new System.EventHandler(this.StudentsRating_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudRating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinGrade)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNA)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStudRating;
        private System.Windows.Forms.NumericUpDown numericUpDownMinGrade;
        private System.Windows.Forms.Button buttonUpdateRatingFromExcel;
        private System.Windows.Forms.RadioButton radioButtonGreater;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonLess;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonNAless;
        private System.Windows.Forms.RadioButton radioButtonNAgreater;
        private System.Windows.Forms.NumericUpDown numericUpDownNA;
        private System.Windows.Forms.Button buttonSaveToExcel;
        private System.Windows.Forms.ComboBox comboBoxFundingType;
        private System.Windows.Forms.Button buttonApplyFilters;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonResetFilters;
        private System.Windows.Forms.ComboBox comboBoxSpecialty;
        private System.Windows.Forms.ComboBox comboBoxCourse;
        private System.Windows.Forms.ComboBox comboBoxFaculty;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}