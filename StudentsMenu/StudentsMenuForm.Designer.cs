namespace Dekanat
{
    partial class StudentsMenuForm
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonDissertation = new System.Windows.Forms.Button();
            this.buttonMyInfo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonHome = new System.Windows.Forms.Button();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.labelTitleBar = new System.Windows.Forms.Label();
            this.panelFormSpace = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelMenu.Controls.Add(this.buttonDissertation);
            this.panelMenu.Controls.Add(this.buttonMyInfo);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(163, 741);
            this.panelMenu.TabIndex = 14;
            // 
            // buttonDissertation
            // 
            this.buttonDissertation.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonDissertation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDissertation.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDissertation.FlatAppearance.BorderSize = 0;
            this.buttonDissertation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDissertation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDissertation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonDissertation.Image = global::Dekanat.Properties.Resources.dissertation;
            this.buttonDissertation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDissertation.Location = new System.Drawing.Point(0, 188);
            this.buttonDissertation.Name = "buttonDissertation";
            this.buttonDissertation.Size = new System.Drawing.Size(163, 97);
            this.buttonDissertation.TabIndex = 17;
            this.buttonDissertation.Text = " Дисертації";
            this.buttonDissertation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDissertation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDissertation.UseVisualStyleBackColor = false;
            this.buttonDissertation.Click += new System.EventHandler(this.buttonDissertation_Click);
            // 
            // buttonMyInfo
            // 
            this.buttonMyInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonMyInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMyInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonMyInfo.FlatAppearance.BorderSize = 0;
            this.buttonMyInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMyInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMyInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonMyInfo.Image = global::Dekanat.Properties.Resources.resume;
            this.buttonMyInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMyInfo.Location = new System.Drawing.Point(0, 91);
            this.buttonMyInfo.Name = "buttonMyInfo";
            this.buttonMyInfo.Size = new System.Drawing.Size(163, 97);
            this.buttonMyInfo.TabIndex = 16;
            this.buttonMyInfo.Text = " Мої дані";
            this.buttonMyInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMyInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonMyInfo.UseVisualStyleBackColor = false;
            this.buttonMyInfo.Click += new System.EventHandler(this.buttonMyInfo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.buttonHome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 91);
            this.panel1.TabIndex = 13;
            // 
            // buttonHome
            // 
            this.buttonHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHome.FlatAppearance.BorderSize = 0;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHome.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonHome.Image = global::Dekanat.Properties.Resources.school;
            this.buttonHome.Location = new System.Drawing.Point(0, 0);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(163, 91);
            this.buttonHome.TabIndex = 0;
            this.buttonHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelTitleBar.Controls.Add(this.labelTitleBar);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(163, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1087, 91);
            this.panelTitleBar.TabIndex = 15;
            // 
            // labelTitleBar
            // 
            this.labelTitleBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTitleBar.AutoSize = true;
            this.labelTitleBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitleBar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitleBar.Location = new System.Drawing.Point(448, 38);
            this.labelTitleBar.Name = "labelTitleBar";
            this.labelTitleBar.Size = new System.Drawing.Size(0, 24);
            this.labelTitleBar.TabIndex = 0;
            this.labelTitleBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFormSpace
            // 
            this.panelFormSpace.BackColor = System.Drawing.Color.White;
            this.panelFormSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormSpace.Location = new System.Drawing.Point(163, 91);
            this.panelFormSpace.Name = "panelFormSpace";
            this.panelFormSpace.Size = new System.Drawing.Size(1087, 650);
            this.panelFormSpace.TabIndex = 16;
            // 
            // StudentsMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1250, 741);
            this.Controls.Add(this.panelFormSpace);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(1266, 780);
            this.Name = "StudentsMenuForm";
            this.Text = "Деканат";
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonMyInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonDissertation;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label labelTitleBar;
        private System.Windows.Forms.Panel panelFormSpace;
    }
}