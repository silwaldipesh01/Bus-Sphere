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
            customBtn3 = new CustomBtn();
            customBtn2 = new CustomBtn();
            customBtn1 = new CustomBtn();
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
            panel3.Controls.Add(customBtn3);
            panel3.Controls.Add(customBtn2);
            panel3.Controls.Add(customBtn1);
            panel3.Controls.Add(GoBackbtn);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1197, 53);
            panel3.TabIndex = 3;
            // 
            // customBtn3
            // 
            customBtn3.BackColor = Color.MediumSlateBlue;
            customBtn3.BackgroundColor = Color.MediumSlateBlue;
            customBtn3.BorderColor = Color.PaleVioletRed;
            customBtn3.BorderRadius = 0;
            customBtn3.BorderSize = 0;
            customBtn3.FlatAppearance.BorderSize = 0;
            customBtn3.FlatStyle = FlatStyle.Flat;
            customBtn3.ForeColor = Color.White;
            customBtn3.Location = new Point(418, 3);
            customBtn3.Name = "customBtn3";
            customBtn3.Size = new Size(350, 47);
            customBtn3.TabIndex = 6;
            customBtn3.Text = "Update Booking";
            customBtn3.TextColor = Color.White;
            customBtn3.UseVisualStyleBackColor = false;
            // 
            // customBtn2
            // 
            customBtn2.BackColor = Color.MediumSlateBlue;
            customBtn2.BackgroundColor = Color.MediumSlateBlue;
            customBtn2.BorderColor = Color.PaleVioletRed;
            customBtn2.BorderRadius = 0;
            customBtn2.BorderSize = 0;
            customBtn2.FlatAppearance.BorderSize = 0;
            customBtn2.FlatStyle = FlatStyle.Flat;
            customBtn2.ForeColor = Color.White;
            customBtn2.Location = new Point(774, 3);
            customBtn2.Name = "customBtn2";
            customBtn2.Size = new Size(350, 47);
            customBtn2.TabIndex = 5;
            customBtn2.Text = "Cancel Booking";
            customBtn2.TextColor = Color.White;
            customBtn2.UseVisualStyleBackColor = false;
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
            customBtn1.Location = new Point(67, 3);
            customBtn1.Name = "customBtn1";
            customBtn1.Size = new Size(346, 47);
            customBtn1.TabIndex = 4;
            customBtn1.Text = "ADD Booking";
            customBtn1.TextColor = Color.White;
            customBtn1.UseVisualStyleBackColor = false;
            // 
            // GoBackbtn
            // 
            GoBackbtn.Anchor = AnchorStyles.None;
            GoBackbtn.BackColor = Color.MediumSlateBlue;
            GoBackbtn.BackgroundColor = Color.MediumSlateBlue;
            GoBackbtn.BorderColor = Color.PaleVioletRed;
            GoBackbtn.BorderRadius = 0;
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
        private CustomBtn customBtn3;
        private CustomBtn customBtn2;
        private CustomBtn customBtn1;
    }
}
