namespace Billing_Customized
{
    partial class AdminLogin
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
            this.adminUserId_textBox = new System.Windows.Forms.TextBox();
            this.adminPassword_textBox = new System.Windows.Forms.TextBox();
            this.UserId_label = new System.Windows.Forms.Label();
            this.Password_label = new System.Windows.Forms.Label();
            this.Showpassword_checkBox = new System.Windows.Forms.CheckBox();
            this.Loginbutton = new System.Windows.Forms.Button();
            this.Exitbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // adminUserId_textBox
            // 
            this.adminUserId_textBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.adminUserId_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminUserId_textBox.Location = new System.Drawing.Point(161, 23);
            this.adminUserId_textBox.Name = "adminUserId_textBox";
            this.adminUserId_textBox.Size = new System.Drawing.Size(185, 30);
            this.adminUserId_textBox.TabIndex = 0;
            // 
            // adminPassword_textBox
            // 
            this.adminPassword_textBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.adminPassword_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminPassword_textBox.Location = new System.Drawing.Point(161, 70);
            this.adminPassword_textBox.Name = "adminPassword_textBox";
            this.adminPassword_textBox.Size = new System.Drawing.Size(185, 30);
            this.adminPassword_textBox.TabIndex = 1;
            this.adminPassword_textBox.TextChanged += new System.EventHandler(this.adminPassword_textBox_TextChanged);
            // 
            // UserId_label
            // 
            this.UserId_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserId_label.AutoSize = true;
            this.UserId_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserId_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UserId_label.Location = new System.Drawing.Point(31, 26);
            this.UserId_label.Name = "UserId_label";
            this.UserId_label.Size = new System.Drawing.Size(81, 25);
            this.UserId_label.TabIndex = 2;
            this.UserId_label.Text = "User Id";
            // 
            // Password_label
            // 
            this.Password_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Password_label.AutoSize = true;
            this.Password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Password_label.Location = new System.Drawing.Point(31, 75);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(106, 25);
            this.Password_label.TabIndex = 3;
            this.Password_label.Text = "Password";
            // 
            // Showpassword_checkBox
            // 
            this.Showpassword_checkBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Showpassword_checkBox.AutoSize = true;
            this.Showpassword_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Showpassword_checkBox.Location = new System.Drawing.Point(161, 121);
            this.Showpassword_checkBox.Name = "Showpassword_checkBox";
            this.Showpassword_checkBox.Size = new System.Drawing.Size(185, 29);
            this.Showpassword_checkBox.TabIndex = 4;
            this.Showpassword_checkBox.Text = "Show Password";
            this.Showpassword_checkBox.UseVisualStyleBackColor = true;
            this.Showpassword_checkBox.CheckedChanged += new System.EventHandler(this.Showpassword_checkBox_CheckedChanged);
            // 
            // Loginbutton
            // 
            this.Loginbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Loginbutton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Loginbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loginbutton.Location = new System.Drawing.Point(161, 166);
            this.Loginbutton.Name = "Loginbutton";
            this.Loginbutton.Size = new System.Drawing.Size(75, 40);
            this.Loginbutton.TabIndex = 5;
            this.Loginbutton.Text = "Login";
            this.Loginbutton.UseVisualStyleBackColor = false;
            this.Loginbutton.Click += new System.EventHandler(this.Loginbutton_Click);
            // 
            // Exitbutton
            // 
            this.Exitbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Exitbutton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Exitbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exitbutton.Location = new System.Drawing.Point(271, 166);
            this.Exitbutton.Name = "Exitbutton";
            this.Exitbutton.Size = new System.Drawing.Size(75, 40);
            this.Exitbutton.TabIndex = 7;
            this.Exitbutton.Text = "Exit";
            this.Exitbutton.UseVisualStyleBackColor = false;
            this.Exitbutton.Click += new System.EventHandler(this.Exitbutton_Click);
            // 
            // AdminLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(387, 227);
            this.ControlBox = false;
            this.Controls.Add(this.Exitbutton);
            this.Controls.Add(this.Loginbutton);
            this.Controls.Add(this.Showpassword_checkBox);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.UserId_label);
            this.Controls.Add(this.adminPassword_textBox);
            this.Controls.Add(this.adminUserId_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminLogin";
            this.Text = "AdminLogin";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AdminLogin_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox adminUserId_textBox;
        private System.Windows.Forms.TextBox adminPassword_textBox;
        private System.Windows.Forms.Label UserId_label;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.CheckBox Showpassword_checkBox;
        private System.Windows.Forms.Button Loginbutton;
        private System.Windows.Forms.Button Exitbutton;
    }
}