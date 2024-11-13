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
            customToggleButton1 = new CustomControls.CustomToggleButton();
            customDatePicker1 = new CustomControls.CustomDatePicker();
            customBtn1 = new CustomControls.CustomBtn();
            customTextBox1 = new CustomControls.CustomTextBox();
            customTextBox2 = new CustomControls.CustomTextBox();
            SuspendLayout();
            // 
            // customToggleButton1
            // 
            customToggleButton1.AutoSize = true;
            customToggleButton1.Location = new Point(105, 44);
            customToggleButton1.MinimumSize = new Size(45, 22);
            customToggleButton1.Name = "customToggleButton1";
            customToggleButton1.OffBackColor = Color.Gray;
            customToggleButton1.OffToggleColor = Color.Gainsboro;
            customToggleButton1.OnBackColor = Color.MediumSlateBlue;
            customToggleButton1.OnToggleColor = Color.WhiteSmoke;
            customToggleButton1.Size = new Size(45, 22);
            customToggleButton1.TabIndex = 0;
            customToggleButton1.UseVisualStyleBackColor = true;
            // 
            // customDatePicker1
            // 
            customDatePicker1.BorderColor = Color.PaleVioletRed;
            customDatePicker1.BorderSize = 0;
            customDatePicker1.Font = new Font("Segoe UI", 9.5F);
            customDatePicker1.Location = new Point(93, 86);
            customDatePicker1.MinimumSize = new Size(0, 35);
            customDatePicker1.Name = "customDatePicker1";
            customDatePicker1.Size = new Size(272, 35);
            customDatePicker1.SkinColor = Color.MediumSlateBlue;
            customDatePicker1.TabIndex = 1;
            customDatePicker1.TextColor = Color.White;
            customDatePicker1.ValueChanged += customDatePicker1_ValueChanged;
            // 
            // customBtn1
            // 
            customBtn1.BackColor = Color.MediumSlateBlue;
            customBtn1.BackgroundColor = Color.MediumSlateBlue;
            customBtn1.BorderColor = Color.PaleVioletRed;
            customBtn1.BorderRadius = 0;
            customBtn1.BorderSize = 0;
            customBtn1.FlatAppearance.BorderSize = 0;
            customBtn1.FlatStyle = FlatStyle.Flat;
            customBtn1.ForeColor = Color.White;
            customBtn1.Location = new Point(93, 127);
            customBtn1.Name = "customBtn1";
            customBtn1.Size = new Size(272, 40);
            customBtn1.TabIndex = 2;
            customBtn1.Text = "customBtn1";
            customBtn1.TextColor = Color.White;
            customBtn1.UseVisualStyleBackColor = false;
            // 
            // customTextBox1
            // 
            customTextBox1.BackColor = SystemColors.Window;
            customTextBox1.BorderColor = Color.MediumSlateBlue;
            customTextBox1.BorderRadius = 0;
            customTextBox1.BorderSize = 2;
            customTextBox1.Font = new Font("Segoe UI", 9.5F);
            customTextBox1.Location = new Point(93, 174);
            customTextBox1.Margin = new Padding(4);
            customTextBox1.Multiline = false;
            customTextBox1.Name = "customTextBox1";
            customTextBox1.Padding = new Padding(7);
            customTextBox1.PasswordChar = false;
            customTextBox1.PlaceholderColor = Color.DarkGray;
            customTextBox1.PlaceholderText = "";
            customTextBox1.PlaceholderText1 = "";
            customTextBox1.Size = new Size(260, 32);
            customTextBox1.TabIndex = 3;
            customTextBox1.Texts = "";
            customTextBox1.UnderlinedStyle = true;
            // 
            // customTextBox2
            // 
            customTextBox2.BackColor = SystemColors.Window;
            customTextBox2.BorderColor = Color.MediumSlateBlue;
            customTextBox2.BorderRadius = 5;
            customTextBox2.BorderSize = 2;
            customTextBox2.Font = new Font("Segoe UI", 9.5F);
            customTextBox2.Location = new Point(93, 214);
            customTextBox2.Margin = new Padding(4);
            customTextBox2.Multiline = false;
            customTextBox2.Name = "customTextBox2";
            customTextBox2.Padding = new Padding(7);
            customTextBox2.PasswordChar = false;
            customTextBox2.PlaceholderColor = Color.DarkGray;
            customTextBox2.PlaceholderText = "";
            customTextBox2.PlaceholderText1 = "";
            customTextBox2.Size = new Size(250, 32);
            customTextBox2.TabIndex = 4;
            customTextBox2.Texts = "";
            customTextBox2.UnderlinedStyle = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 570);
            Controls.Add(customTextBox2);
            Controls.Add(customTextBox1);
            Controls.Add(customBtn1);
            Controls.Add(customDatePicker1);
            Controls.Add(customToggleButton1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.CustomToggleButton customToggleButton1;
        private CustomControls.CustomDatePicker customDatePicker1;
        private CustomControls.CustomBtn customBtn1;
        private CustomControls.CustomTextBox customTextBox1;
        private CustomControls.CustomTextBox customTextBox2;
    }
}
