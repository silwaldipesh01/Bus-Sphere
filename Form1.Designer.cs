namespace Bus_Sphere
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            LoginBtn = new CustomControls.CustomBtn();
            UsernameTxtBox = new TextBox();
            PasswordTxtBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ValidUserTxt = new Label();
            SignUpBtn = new CustomControls.CustomBtn();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(198, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(979, 190);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // LoginBtn
            // 
            LoginBtn.Anchor = AnchorStyles.None;
            LoginBtn.BackColor = Color.FromArgb(72, 131, 181);
            LoginBtn.BackgroundColor = Color.FromArgb(72, 131, 181);
            LoginBtn.BorderColor = Color.Black;
            LoginBtn.BorderRadius = 10;
            LoginBtn.BorderSize = 0;
            LoginBtn.FlatAppearance.BorderSize = 0;
            LoginBtn.FlatStyle = FlatStyle.Flat;
            LoginBtn.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginBtn.ForeColor = Color.Transparent;
            LoginBtn.Location = new Point(505, 470);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(284, 40);
            LoginBtn.TabIndex = 8;
            LoginBtn.Text = "Login";
            LoginBtn.TextColor = Color.Transparent;
            LoginBtn.UseVisualStyleBackColor = false;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // UsernameTxtBox
            // 
            UsernameTxtBox.Location = new Point(610, 332);
            UsernameTxtBox.Margin = new Padding(2);
            UsernameTxtBox.Name = "UsernameTxtBox";
            UsernameTxtBox.Size = new Size(179, 23);
            UsernameTxtBox.TabIndex = 9;
            // 
            // PasswordTxtBox
            // 
            PasswordTxtBox.ForeColor = SystemColors.Desktop;
            PasswordTxtBox.Location = new Point(610, 399);
            PasswordTxtBox.Name = "PasswordTxtBox";
            PasswordTxtBox.PasswordChar = '*';
            PasswordTxtBox.Size = new Size(179, 23);
            PasswordTxtBox.TabIndex = 10;
            PasswordTxtBox.TextChanged += textBox2_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(505, 399);
            label1.Name = "label1";
            label1.Size = new Size(76, 21);
            label1.TabIndex = 11;
            label1.Text = "Password";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(505, 334);
            label2.Name = "label2";
            label2.Size = new Size(81, 21);
            label2.TabIndex = 12;
            label2.Text = "Username";
            // 
            // ValidUserTxt
            // 
            ValidUserTxt.AutoSize = true;
            ValidUserTxt.BackColor = Color.Transparent;
            ValidUserTxt.Font = new Font("Arial", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            ValidUserTxt.ForeColor = Color.Red;
            ValidUserTxt.Location = new Point(505, 441);
            ValidUserTxt.Name = "ValidUserTxt";
            ValidUserTxt.Size = new Size(90, 16);
            ValidUserTxt.TabIndex = 13;
            ValidUserTxt.Text = "Authentication";
            ValidUserTxt.Click += ValidUserTxt_Click;
            // 
            // SignUpBtn
            // 
            SignUpBtn.Anchor = AnchorStyles.None;
            SignUpBtn.BackColor = Color.FromArgb(72, 131, 181);
            SignUpBtn.BackgroundColor = Color.FromArgb(72, 131, 181);
            SignUpBtn.BorderColor = Color.Black;
            SignUpBtn.BorderRadius = 10;
            SignUpBtn.BorderSize = 0;
            SignUpBtn.FlatAppearance.BorderSize = 0;
            SignUpBtn.FlatStyle = FlatStyle.Flat;
            SignUpBtn.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SignUpBtn.ForeColor = Color.Transparent;
            SignUpBtn.Location = new Point(1170, 565);
            SignUpBtn.Name = "SignUpBtn";
            SignUpBtn.Size = new Size(122, 40);
            SignUpBtn.TabIndex = 14;
            SignUpBtn.Text = "Sign Up!";
            SignUpBtn.TextColor = Color.Transparent;
            SignUpBtn.UseVisualStyleBackColor = false;
            SignUpBtn.Click += SignUpBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            CausesValidation = false;
            ClientSize = new Size(1324, 626);
            Controls.Add(SignUpBtn);
            Controls.Add(ValidUserTxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PasswordTxtBox);
            Controls.Add(UsernameTxtBox);
            Controls.Add(LoginBtn);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private CustomControls.CustomBtn LoginBtn;
        private TextBox UsernameTxtBox;
        private TextBox PasswordTxtBox;
        private Label label1;
        private Label label2;
        private Label ValidUserTxt;
        private CustomControls.CustomBtn SignUpBtn;
    }
}
