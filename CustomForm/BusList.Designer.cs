using Bus_Sphere.CustomControls;

namespace Bus_Sphere.CustomForm
{
    partial class BusList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusList));
            panel1 = new Panel();
            panel3 = new Panel();
            BtnUpdateBooking = new CustomBtn();
            BtnCancelBooking = new CustomBtn();
            BtnAddBooking = new CustomBtn();
            GoBackbtn = new CustomBtn();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1197, 814);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(BtnUpdateBooking);
            panel3.Controls.Add(BtnCancelBooking);
            panel3.Controls.Add(BtnAddBooking);
            panel3.Controls.Add(GoBackbtn);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1197, 53);
            panel3.TabIndex = 3;
            // 
            // BtnUpdateBooking
            // 
            BtnUpdateBooking.BackColor = Color.FromArgb(30, 129, 176);
            BtnUpdateBooking.BackgroundColor = Color.FromArgb(30, 129, 176);
            BtnUpdateBooking.BorderColor = Color.PaleVioletRed;
            BtnUpdateBooking.BorderRadius = 10;
            BtnUpdateBooking.BorderSize = 0;
            BtnUpdateBooking.FlatAppearance.BorderSize = 0;
            BtnUpdateBooking.FlatStyle = FlatStyle.Flat;
            BtnUpdateBooking.ForeColor = Color.White;
            BtnUpdateBooking.Image = (Image)resources.GetObject("BtnUpdateBooking.Image");
            BtnUpdateBooking.ImageAlign = ContentAlignment.MiddleRight;
            BtnUpdateBooking.Location = new Point(377, 2);
            BtnUpdateBooking.Name = "BtnUpdateBooking";
            BtnUpdateBooking.Size = new Size(366, 47);
            BtnUpdateBooking.TabIndex = 6;
            BtnUpdateBooking.Text = "Update/Cancel Booking";
            BtnUpdateBooking.TextColor = Color.White;
            BtnUpdateBooking.UseVisualStyleBackColor = false;
            BtnUpdateBooking.Click += BtnUpdateBooking_Click;
            BtnUpdateBooking.MouseHover += BtnUpdateBooking_MouseHover;
            // 
            // BtnCancelBooking
            // 
            BtnCancelBooking.BackColor = Color.FromArgb(30, 129, 176);
            BtnCancelBooking.BackgroundColor = Color.FromArgb(30, 129, 176);
            BtnCancelBooking.BorderColor = Color.PaleVioletRed;
            BtnCancelBooking.BorderRadius = 10;
            BtnCancelBooking.BorderSize = 0;
            BtnCancelBooking.FlatAppearance.BorderSize = 0;
            BtnCancelBooking.FlatStyle = FlatStyle.Flat;
            BtnCancelBooking.ForeColor = Color.White;
            BtnCancelBooking.Location = new Point(749, 2);
            BtnCancelBooking.Name = "BtnCancelBooking";
            BtnCancelBooking.Size = new Size(366, 47);
            BtnCancelBooking.TabIndex = 5;
            BtnCancelBooking.Text = "Cancel Booking";
            BtnCancelBooking.TextColor = Color.White;
            BtnCancelBooking.UseVisualStyleBackColor = false;
            BtnCancelBooking.Click += BtnCancelBooking_Click;
            // 
            // BtnAddBooking
            // 
            BtnAddBooking.BackColor = Color.FromArgb(30, 129, 176);
            BtnAddBooking.BackgroundColor = Color.FromArgb(30, 129, 176);
            BtnAddBooking.BorderColor = Color.PaleVioletRed;
            BtnAddBooking.BorderRadius = 10;
            BtnAddBooking.BorderSize = 0;
            BtnAddBooking.FlatAppearance.BorderSize = 0;
            BtnAddBooking.FlatStyle = FlatStyle.Flat;
            BtnAddBooking.ForeColor = Color.White;
            BtnAddBooking.Image = (Image)resources.GetObject("BtnAddBooking.Image");
            BtnAddBooking.ImageAlign = ContentAlignment.MiddleRight;
            BtnAddBooking.Location = new Point(9, 2);
            BtnAddBooking.Name = "BtnAddBooking";
            BtnAddBooking.Size = new Size(362, 47);
            BtnAddBooking.TabIndex = 4;
            BtnAddBooking.Text = "Add Booking";
            BtnAddBooking.TextColor = Color.White;
            BtnAddBooking.UseVisualStyleBackColor = false;
            BtnAddBooking.Click += BtnAddBooking_Click;
            // 
            // GoBackbtn
            // 
            GoBackbtn.Anchor = AnchorStyles.None;
            GoBackbtn.BackColor = Color.FromArgb(30, 129, 176);
            GoBackbtn.BackgroundColor = Color.FromArgb(30, 129, 176);
            GoBackbtn.BorderColor = Color.PaleVioletRed;
            GoBackbtn.BorderRadius = 10;
            GoBackbtn.BorderSize = 0;
            GoBackbtn.FlatAppearance.BorderSize = 0;
            GoBackbtn.FlatStyle = FlatStyle.Flat;
            GoBackbtn.ForeColor = Color.White;
            GoBackbtn.Image = (Image)resources.GetObject("GoBackbtn.Image");
            GoBackbtn.Location = new Point(1125, 3);
            GoBackbtn.Name = "GoBackbtn";
            GoBackbtn.Size = new Size(69, 47);
            GoBackbtn.TabIndex = 3;
            GoBackbtn.TextColor = Color.White;
            GoBackbtn.UseVisualStyleBackColor = false;
            GoBackbtn.Click += GoBackbtn_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 55);
            panel2.Name = "panel2";
            panel2.Size = new Size(1197, 759);
            panel2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1197, 755);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // BusList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "BusList";
            Size = new Size(1197, 814);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DataGridView dataGridView1;
        private CustomBtn GoBackbtn;
        private Panel panel3;
        private CustomBtn BtnUpdateBooking;
        private CustomBtn BtnCancelBooking;
        private CustomBtn BtnAddBooking;
    }
}
