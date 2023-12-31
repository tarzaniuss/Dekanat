namespace Dekanat
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_login = new System.Windows.Forms.Label();
            this.button_logIn = new System.Windows.Forms.Button();
            this.label_password = new System.Windows.Forms.Label();
            this.pictureBox_visible_pass = new System.Windows.Forms.PictureBox();
            this.pictureBox_unvisible_pass = new System.Windows.Forms.PictureBox();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_visible_pass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_unvisible_pass)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label_login);
            this.groupBox1.Controls.Add(this.button_logIn);
            this.groupBox1.Controls.Add(this.label_password);
            this.groupBox1.Controls.Add(this.pictureBox_visible_pass);
            this.groupBox1.Controls.Add(this.pictureBox_unvisible_pass);
            this.groupBox1.Controls.Add(this.textBox_login);
            this.groupBox1.Controls.Add(this.textBox_password);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(91, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 258);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вхід";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Dekanat.Properties.Resources.user__1_;
            this.pictureBox2.Location = new System.Drawing.Point(6, 49);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Dekanat.Properties.Resources.padlock;
            this.pictureBox1.Location = new System.Drawing.Point(6, 112);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_login.Location = new System.Drawing.Point(42, 53);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(64, 25);
            this.label_login.TabIndex = 1;
            this.label_login.Text = "Логін";
            // 
            // button_logIn
            // 
            this.button_logIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_logIn.Location = new System.Drawing.Point(152, 190);
            this.button_logIn.Name = "button_logIn";
            this.button_logIn.Size = new System.Drawing.Size(101, 38);
            this.button_logIn.TabIndex = 7;
            this.button_logIn.Text = "Увійти";
            this.button_logIn.UseVisualStyleBackColor = true;
            this.button_logIn.Click += new System.EventHandler(this.button_logIn_Click);
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_password.Location = new System.Drawing.Point(42, 114);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(86, 25);
            this.label_password.TabIndex = 2;
            this.label_password.Text = "Пароль";
            // 
            // pictureBox_visible_pass
            // 
            this.pictureBox_visible_pass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_visible_pass.Image = global::Dekanat.Properties.Resources._2385421;
            this.pictureBox_visible_pass.Location = new System.Drawing.Point(319, 100);
            this.pictureBox_visible_pass.Name = "pictureBox_visible_pass";
            this.pictureBox_visible_pass.Size = new System.Drawing.Size(44, 44);
            this.pictureBox_visible_pass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_visible_pass.TabIndex = 5;
            this.pictureBox_visible_pass.TabStop = false;
            this.pictureBox_visible_pass.Click += new System.EventHandler(this.pictureBox_visible_pass_Click);
            // 
            // pictureBox_unvisible_pass
            // 
            this.pictureBox_unvisible_pass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_unvisible_pass.Image = global::Dekanat.Properties.Resources._5592884;
            this.pictureBox_unvisible_pass.Location = new System.Drawing.Point(319, 100);
            this.pictureBox_unvisible_pass.Name = "pictureBox_unvisible_pass";
            this.pictureBox_unvisible_pass.Size = new System.Drawing.Size(44, 44);
            this.pictureBox_unvisible_pass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_unvisible_pass.TabIndex = 6;
            this.pictureBox_unvisible_pass.TabStop = false;
            this.pictureBox_unvisible_pass.Click += new System.EventHandler(this.pictureBox_unvisible_pass_Click);
            // 
            // textBox_login
            // 
            this.textBox_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_login.Location = new System.Drawing.Point(134, 49);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(170, 29);
            this.textBox_login.TabIndex = 3;
            // 
            // textBox_password
            // 
            this.textBox_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_password.Location = new System.Drawing.Point(134, 112);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(170, 29);
            this.textBox_password.TabIndex = 4;
            // 
            // LoginPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(604, 361);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(620, 400);
            this.MinimumSize = new System.Drawing.Size(620, 400);
            this.Name = "LoginPage";
            this.Text = "Авторизація";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_visible_pass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_unvisible_pass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.Button button_logIn;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.PictureBox pictureBox_visible_pass;
        private System.Windows.Forms.PictureBox pictureBox_unvisible_pass;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.TextBox textBox_password;
    }
}

