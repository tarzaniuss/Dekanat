namespace Dekanat
{
    partial class StudentsDissertationViewForm
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
            this.dataGridViewDissertationInfo = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSpecialty = new System.Windows.Forms.TextBox();
            this.textBoxAdvisor = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.textBoxTopic = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDissertationInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDissertationInfo
            // 
            this.dataGridViewDissertationInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDissertationInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDissertationInfo.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewDissertationInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDissertationInfo.Location = new System.Drawing.Point(70, 25);
            this.dataGridViewDissertationInfo.Name = "dataGridViewDissertationInfo";
            this.dataGridViewDissertationInfo.Size = new System.Drawing.Size(940, 320);
            this.dataGridViewDissertationInfo.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.buttonReset);
            this.groupBox1.Controls.Add(this.buttonFind);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxSpecialty);
            this.groupBox1.Controls.Add(this.textBoxAdvisor);
            this.groupBox1.Controls.Add(this.textBoxAuthor);
            this.groupBox1.Controls.Add(this.textBoxTopic);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(225, 373);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 190);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фільтр";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(412, 115);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(88, 26);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "Зкинути";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(412, 61);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(88, 26);
            this.buttonFind.TabIndex = 8;
            this.buttonFind.Text = "Знайти";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(17, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Пошук за спеціальністю";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(17, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Пошук за керівником";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(17, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пошук за автором";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(17, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Пошук за темою";
            // 
            // textBoxSpecialty
            // 
            this.textBoxSpecialty.Location = new System.Drawing.Point(213, 139);
            this.textBoxSpecialty.Name = "textBoxSpecialty";
            this.textBoxSpecialty.Size = new System.Drawing.Size(172, 22);
            this.textBoxSpecialty.TabIndex = 3;
            // 
            // textBoxAdvisor
            // 
            this.textBoxAdvisor.Location = new System.Drawing.Point(190, 103);
            this.textBoxAdvisor.Name = "textBoxAdvisor";
            this.textBoxAdvisor.Size = new System.Drawing.Size(172, 22);
            this.textBoxAdvisor.TabIndex = 2;
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(171, 67);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(172, 22);
            this.textBoxAuthor.TabIndex = 1;
            // 
            // textBoxTopic
            // 
            this.textBoxTopic.Location = new System.Drawing.Point(156, 31);
            this.textBoxTopic.Name = "textBoxTopic";
            this.textBoxTopic.Size = new System.Drawing.Size(172, 22);
            this.textBoxTopic.TabIndex = 0;
            // 
            // StudentsDissertationViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1079, 611);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewDissertationInfo);
            this.Name = "StudentsDissertationViewForm";
            this.Text = "Дисертації";
            this.Load += new System.EventHandler(this.StudentsDissertationViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDissertationInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDissertationInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSpecialty;
        private System.Windows.Forms.TextBox textBoxAdvisor;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.TextBox textBoxTopic;
    }
}