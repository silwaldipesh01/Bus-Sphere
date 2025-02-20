namespace Bus_Sphere
{
    partial class BookingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookingForm));
            panel1 = new Panel();
            addBookingForm1 = new AddBookingForm();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(addBookingForm1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1016, 599);
            panel1.TabIndex = 0;
            // 
            // addBookingForm1
            // 
            addBookingForm1.BackgroundImage = (Image)resources.GetObject("addBookingForm1.BackgroundImage");
            addBookingForm1.BackgroundImageLayout = ImageLayout.Stretch;
            addBookingForm1.Dock = DockStyle.Fill;
            addBookingForm1.Location = new Point(0, 0);
            addBookingForm1.Name = "addBookingForm1";
            addBookingForm1.Size = new Size(1016, 599);
            addBookingForm1.TabIndex = 0;
            // 
            // BookingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 599);
            Controls.Add(panel1);
            Name = "BookingForm";
            Text = "BookingForm";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private AddBookingForm addBookingForm1;
    }
}