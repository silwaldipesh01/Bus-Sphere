using Bus_Sphere.CustomControls;

namespace Bus_Sphere.packages
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            MenuPanel = new Panel();
            customBtn9 = new CustomBtn();
            customBtn8 = new CustomBtn();
            customBtn7 = new CustomBtn();
            customBtn6 = new CustomBtn();
            customBtn4 = new CustomBtn();
            pictureBox1 = new PictureBox();
            MainPanel = new Panel();
            busList1 = new CustomForm.BusList();
            MenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MenuPanel
            // 
            MenuPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MenuPanel.BackColor = Color.Transparent;
            MenuPanel.Controls.Add(customBtn9);
            MenuPanel.Controls.Add(customBtn8);
            MenuPanel.Controls.Add(customBtn7);
            MenuPanel.Controls.Add(customBtn6);
            MenuPanel.Controls.Add(customBtn4);
            MenuPanel.Controls.Add(pictureBox1);
            MenuPanel.Dock = DockStyle.Left;
            MenuPanel.Location = new Point(0, 0);
            MenuPanel.Name = "MenuPanel";
            MenuPanel.Size = new Size(278, 814);
            MenuPanel.TabIndex = 1;
            // 
            // customBtn9
            // 
            customBtn9.BackColor = Color.MediumSlateBlue;
            customBtn9.BackgroundColor = Color.MediumSlateBlue;
            customBtn9.BorderColor = Color.PaleVioletRed;
            customBtn9.BorderRadius = 0;
            customBtn9.BorderSize = 0;
            customBtn9.FlatAppearance.BorderSize = 0;
            customBtn9.FlatStyle = FlatStyle.Flat;
            customBtn9.ForeColor = Color.White;
            customBtn9.Location = new Point(3, 428);
            customBtn9.Name = "customBtn9";
            customBtn9.Size = new Size(270, 40);
            customBtn9.TabIndex = 10;
            customBtn9.Text = "Bus Details";
            customBtn9.TextColor = Color.White;
            customBtn9.UseVisualStyleBackColor = false;
            // 
            // customBtn8
            // 
            customBtn8.BackColor = Color.MediumSlateBlue;
            customBtn8.BackgroundColor = Color.MediumSlateBlue;
            customBtn8.BorderColor = Color.PaleVioletRed;
            customBtn8.BorderRadius = 0;
            customBtn8.BorderSize = 0;
            customBtn8.FlatAppearance.BorderSize = 0;
            customBtn8.FlatStyle = FlatStyle.Flat;
            customBtn8.ForeColor = Color.White;
            customBtn8.Location = new Point(3, 566);
            customBtn8.Name = "customBtn8";
            customBtn8.Size = new Size(270, 40);
            customBtn8.TabIndex = 9;
            customBtn8.Text = "staffs";
            customBtn8.TextColor = Color.White;
            customBtn8.UseVisualStyleBackColor = false;
            // 
            // customBtn7
            // 
            customBtn7.BackColor = Color.MediumSlateBlue;
            customBtn7.BackgroundColor = Color.MediumSlateBlue;
            customBtn7.BorderColor = Color.PaleVioletRed;
            customBtn7.BorderRadius = 0;
            customBtn7.BorderSize = 0;
            customBtn7.FlatAppearance.BorderSize = 0;
            customBtn7.FlatStyle = FlatStyle.Flat;
            customBtn7.ForeColor = Color.White;
            customBtn7.Location = new Point(3, 520);
            customBtn7.Name = "customBtn7";
            customBtn7.Size = new Size(270, 40);
            customBtn7.TabIndex = 8;
            customBtn7.Text = "Reports";
            customBtn7.TextColor = Color.White;
            customBtn7.UseVisualStyleBackColor = false;
            // 
            // customBtn6
            // 
            customBtn6.BackColor = Color.MediumSlateBlue;
            customBtn6.BackgroundColor = Color.MediumSlateBlue;
            customBtn6.BorderColor = Color.PaleVioletRed;
            customBtn6.BorderRadius = 0;
            customBtn6.BorderSize = 0;
            customBtn6.FlatAppearance.BorderSize = 0;
            customBtn6.FlatStyle = FlatStyle.Flat;
            customBtn6.ForeColor = Color.White;
            customBtn6.Location = new Point(3, 474);
            customBtn6.Name = "customBtn6";
            customBtn6.Size = new Size(270, 40);
            customBtn6.TabIndex = 7;
            customBtn6.Text = "Routes";
            customBtn6.TextColor = Color.White;
            customBtn6.UseVisualStyleBackColor = false;
            // 
            // customBtn4
            // 
            customBtn4.BackColor = Color.MediumSlateBlue;
            customBtn4.BackgroundColor = Color.MediumSlateBlue;
            customBtn4.BorderColor = Color.PaleVioletRed;
            customBtn4.BorderRadius = 0;
            customBtn4.BorderSize = 0;
            customBtn4.FlatAppearance.BorderSize = 0;
            customBtn4.FlatStyle = FlatStyle.Flat;
            customBtn4.ForeColor = Color.White;
            customBtn4.Location = new Point(3, 382);
            customBtn4.Name = "customBtn4";
            customBtn4.Size = new Size(270, 40);
            customBtn4.TabIndex = 6;
            customBtn4.Text = "bookigns";
            customBtn4.TextColor = Color.White;
            customBtn4.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(264, 269);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // MainPanel
            // 
            MainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MainPanel.BackColor = Color.Transparent;
            MainPanel.Controls.Add(busList1);
            MainPanel.Dock = DockStyle.Right;
            MainPanel.Location = new Point(284, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1170, 814);
            MainPanel.TabIndex = 2;
            MainPanel.Paint += MainPanel_Paint;
            // 
            // busList1
            // 
            busList1.Dock = DockStyle.Fill;
            busList1.Location = new Point(0, 0);
            busList1.Name = "busList1";
            busList1.Size = new Size(1170, 814);
            busList1.TabIndex = 0;
            busList1.Load += busList1_Load;
            // 
            // MainPage
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1454, 814);
            Controls.Add(MainPanel);
            Controls.Add(MenuPanel);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainPage";
            Text = "BusSphere";
            MenuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            MainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel MenuPanel;
        private CustomBtn customBtn5;
        private CustomBtn SeeRevenueBtn;
        private CustomBtn customBtn3;
        private CustomBtn customBtn2;
        private PictureBox pictureBox1;
        private Panel MainPanel;
        private CustomBtn customBtn9;
        private CustomBtn customBtn8;
        private CustomBtn customBtn7;
        private CustomBtn customBtn6;
        private CustomBtn customBtn4;
        private CustomForm.BusList busList1;
    }
}