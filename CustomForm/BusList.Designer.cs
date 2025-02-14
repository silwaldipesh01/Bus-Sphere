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
            GoBackbtn = new CustomBtn();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(GoBackbtn);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1138, 814);
            panel1.TabIndex = 0;
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
            GoBackbtn.Location = new Point(1063, 13);
            GoBackbtn.Name = "GoBackbtn";
            GoBackbtn.Size = new Size(46, 37);
            GoBackbtn.TabIndex = 3;
            GoBackbtn.TextColor = Color.White;
            GoBackbtn.UseVisualStyleBackColor = false;
            GoBackbtn.Click += GoBackbtn_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 56);
            panel2.Name = "panel2";
            panel2.Size = new Size(1138, 758);
            panel2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1109, 696);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // BusList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "BusList";
            Size = new Size(1138, 814);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DataGridView dataGridView1;
        private CustomBtn GoBackbtn;
    }
}
