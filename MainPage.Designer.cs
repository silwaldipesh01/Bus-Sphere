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
            customBtn7 = new CustomBtn();
            customBtn6 = new CustomBtn();
            customBtn4 = new CustomBtn();
            pictureBox1 = new PictureBox();
            MainPanel = new Panel();
            busList1 = new CustomForm.BusList();
            BtnMgmtSaff = new CustomBtn();
            MenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MenuPanel
            // 
            MenuPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MenuPanel.BackColor = Color.Transparent;
            MenuPanel.Controls.Add(BtnMgmtSaff);
            MenuPanel.Controls.Add(customBtn9);
            MenuPanel.Controls.Add(customBtn7);
            MenuPanel.Controls.Add(customBtn6);
            MenuPanel.Controls.Add(customBtn4);
            MenuPanel.Controls.Add(pictureBox1);
            MenuPanel.Dock = DockStyle.Left;
            MenuPanel.Location = new Point(0, 0);
            MenuPanel.Name = "MenuPanel";
            MenuPanel.Size = new Size(258, 814);
            MenuPanel.TabIndex = 1;
            MenuPanel.Paint += MenuPanel_Paint;
            // 
            // customBtn9
            // 
            customBtn9.BackColor = Color.FromArgb(30, 129, 176);
            customBtn9.BackgroundColor = Color.FromArgb(30, 129, 176);
            customBtn9.BorderColor = Color.White;
            customBtn9.BorderRadius = 10;
            customBtn9.BorderSize = 0;
            customBtn9.FlatAppearance.BorderSize = 0;
            customBtn9.FlatStyle = FlatStyle.Flat;
            customBtn9.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            customBtn9.ForeColor = Color.White;
            customBtn9.Location = new Point(3, 509);
            customBtn9.Name = "customBtn9";
            customBtn9.Size = new Size(252, 65);
            customBtn9.TabIndex = 10;
            customBtn9.Text = "Bus Details";
            customBtn9.TextColor = Color.White;
            customBtn9.UseVisualStyleBackColor = false;
            // 
            // customBtn7
            // 
            customBtn7.BackColor = Color.FromArgb(30, 129, 176);
            customBtn7.BackgroundColor = Color.FromArgb(30, 129, 176);
            customBtn7.BorderColor = Color.White;
            customBtn7.BorderRadius = 10;
            customBtn7.BorderSize = 0;
            customBtn7.FlatAppearance.BorderSize = 0;
            customBtn7.FlatStyle = FlatStyle.Flat;
            customBtn7.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            customBtn7.ForeColor = Color.White;
            customBtn7.Location = new Point(3, 722);
            customBtn7.Name = "customBtn7";
            customBtn7.Size = new Size(252, 65);
            customBtn7.TabIndex = 8;
            customBtn7.Text = "Reports";
            customBtn7.TextColor = Color.White;
            customBtn7.UseVisualStyleBackColor = false;
            // 
            // customBtn6
            // 
            customBtn6.BackColor = Color.FromArgb(30, 129, 176);
            customBtn6.BackgroundColor = Color.FromArgb(30, 129, 176);
            customBtn6.BorderColor = Color.White;
            customBtn6.BorderRadius = 10;
            customBtn6.BorderSize = 0;
            customBtn6.FlatAppearance.BorderSize = 0;
            customBtn6.FlatStyle = FlatStyle.Flat;
            customBtn6.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            customBtn6.ForeColor = Color.White;
            customBtn6.Location = new Point(3, 580);
            customBtn6.Name = "customBtn6";
            customBtn6.Size = new Size(252, 65);
            customBtn6.TabIndex = 7;
            customBtn6.Text = "Routes";
            customBtn6.TextColor = Color.White;
            customBtn6.UseVisualStyleBackColor = false;
            // 
            // customBtn4
            // 
            customBtn4.BackColor = Color.FromArgb(30, 129, 176);
            customBtn4.BackgroundColor = Color.FromArgb(30, 129, 176);
            customBtn4.BorderColor = Color.White;
            customBtn4.BorderRadius = 10;
            customBtn4.BorderSize = 0;
            customBtn4.FlatAppearance.BorderSize = 0;
            customBtn4.FlatStyle = FlatStyle.Flat;
            customBtn4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            customBtn4.ForeColor = Color.White;
            customBtn4.Location = new Point(3, 438);
            customBtn4.Name = "customBtn4";
            customBtn4.Size = new Size(252, 65);
            customBtn4.TabIndex = 6;
            customBtn4.Text = "Bookings ";
            customBtn4.TextColor = Color.White;
            customBtn4.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(248, 248);
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
            MainPanel.Location = new Point(257, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1197, 814);
            MainPanel.TabIndex = 2;
            MainPanel.Paint += MainPanel_Paint;
            // 
            // busList1
            // 
            busList1.Dock = DockStyle.Fill;
            busList1.Location = new Point(0, 0);
            busList1.Name = "busList1";
            busList1.Size = new Size(1197, 814);
            busList1.TabIndex = 0;
            busList1.Load += busList1_Load;
            // 
            // BtnMgmtSaff
            // 
            BtnMgmtSaff.BackColor = Color.FromArgb(30, 129, 176);
            BtnMgmtSaff.BackgroundColor = Color.FromArgb(30, 129, 176);
            BtnMgmtSaff.BorderColor = Color.White;
            BtnMgmtSaff.BorderRadius = 10;
            BtnMgmtSaff.BorderSize = 0;
            BtnMgmtSaff.FlatAppearance.BorderSize = 0;
            BtnMgmtSaff.FlatStyle = FlatStyle.Flat;
            BtnMgmtSaff.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            BtnMgmtSaff.ForeColor = Color.White;
            BtnMgmtSaff.Location = new Point(3, 651);
            BtnMgmtSaff.Name = "BtnMgmtSaff";
            BtnMgmtSaff.Size = new Size(252, 65);
            BtnMgmtSaff.TabIndex = 11;
            BtnMgmtSaff.Text = "staffs";
            BtnMgmtSaff.TextColor = Color.White;
            BtnMgmtSaff.UseVisualStyleBackColor = false;
            BtnMgmtSaff.Click += BtnMgmtSaff_Click;
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
            StartPosition = FormStartPosition.CenterScreen;
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
        private CustomBtn customBtn7;
        private CustomBtn customBtn6;
        private CustomBtn customBtn4;
        private CustomForm.BusList busList1;
        private CustomBtn BtnMgmtSaff;
    }
}