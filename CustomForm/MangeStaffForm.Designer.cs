namespace Bus_Sphere.CustomForm
{
    partial class MangeStaffForm
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
            panel1 = new Panel();
            txtBxName = new TextBox();
            txtBxEmail = new TextBox();
            txtBxPhone = new TextBox();
            cmbBxPostion = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            customBtn1 = new CustomControls.CustomBtn();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 174);
            panel1.Name = "panel1";
            panel1.Size = new Size(1197, 640);
            panel1.TabIndex = 0;
            // 
            // txtBxName
            // 
            txtBxName.Location = new Point(275, 47);
            txtBxName.Name = "txtBxName";
            txtBxName.Size = new Size(100, 23);
            txtBxName.TabIndex = 1;
            // 
            // txtBxEmail
            // 
            txtBxEmail.Location = new Point(275, 107);
            txtBxEmail.Name = "txtBxEmail";
            txtBxEmail.Size = new Size(100, 23);
            txtBxEmail.TabIndex = 2;
            // 
            // txtBxPhone
            // 
            txtBxPhone.Location = new Point(536, 47);
            txtBxPhone.Name = "txtBxPhone";
            txtBxPhone.Size = new Size(100, 23);
            txtBxPhone.TabIndex = 3;
            // 
            // cmbBxPostion
            // 
            cmbBxPostion.FormattingEnabled = true;
            cmbBxPostion.Items.AddRange(new object[] { "Bus Driver", "Conductor", "Other" });
            cmbBxPostion.Location = new Point(536, 107);
            cmbBxPostion.Name = "cmbBxPostion";
            cmbBxPostion.Size = new Size(121, 23);
            cmbBxPostion.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(176, 49);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 5;
            label1.Text = "Name :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(450, 55);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 6;
            label2.Text = "Phone :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(176, 115);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 7;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(450, 115);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 8;
            label4.Text = "Position";
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
            customBtn1.Location = new Point(818, 67);
            customBtn1.Name = "customBtn1";
            customBtn1.Size = new Size(150, 40);
            customBtn1.TabIndex = 9;
            customBtn1.Text = "Add staff";
            customBtn1.TextColor = Color.White;
            customBtn1.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1197, 640);
            dataGridView1.TabIndex = 0;
            // 
            // MangeStaffForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(customBtn1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbBxPostion);
            Controls.Add(txtBxPhone);
            Controls.Add(txtBxEmail);
            Controls.Add(txtBxName);
            Controls.Add(panel1);
            Name = "MangeStaffForm";
            Size = new Size(1197, 814);
            Load += MangeStaffForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox txtBxName;
        private TextBox txtBxEmail;
        private TextBox txtBxPhone;
        private ComboBox cmbBxPostion;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private CustomControls.CustomBtn customBtn1;
    }
}
