using Bus_Sphere.CustomControls;

namespace Bus_Sphere.Models
{
    partial class SeatDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeatDesign));
            customBtn1 = new CustomControls.CustomBtn();
            SuspendLayout();
            // 
            // customBtn1
            // 
            customBtn1.BackColor = Color.LightSeaGreen;
            customBtn1.BackgroundColor = Color.LightSeaGreen;
            customBtn1.BorderColor = Color.PaleVioletRed;
            customBtn1.BorderRadius = 15;
            customBtn1.BorderSize = 0;
            customBtn1.Dock = DockStyle.Fill;
            customBtn1.FlatAppearance.BorderSize = 0;
            customBtn1.FlatStyle = FlatStyle.Flat;
            customBtn1.Font = new Font("Segoe UI", 16F);
            customBtn1.ForeColor = Color.WhiteSmoke;
            customBtn1.Image = (Image)resources.GetObject("customBtn1.Image");
            customBtn1.Location = new Point(0, 0);
            customBtn1.Name = "customBtn1";
            customBtn1.Size = new Size(101, 102);
            customBtn1.TabIndex = 0;
            customBtn1.Text = "A1";
            customBtn1.TextColor = Color.WhiteSmoke;
            customBtn1.UseVisualStyleBackColor = false;
            customBtn1.Click += customBtn1_Click;
            // 
            // SeatDesign
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(customBtn1);
            Name = "SeatDesign";
            Size = new Size(101, 102);
            ResumeLayout(false);
        }

        #endregion

        private CustomBtn customBtn1;
    }
}
