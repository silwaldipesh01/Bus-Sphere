using Bus_Sphere.CustomControls;

namespace Bus_Sphere.CustomForm
{
    partial class SeatSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeatSelection));
            PassengerFormPanel = new Panel();
            panel1 = new Panel();
            btnConfirmBooking = new CustomControls.CustomBtn();
            label7 = new Label();
            label6 = new Label();
            selectedSeatLbl = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            customBtn1 = new CustomControls.CustomBtn();
            customBtn2 = new CustomControls.CustomBtn();
            customBtn3 = new CustomControls.CustomBtn();
            customBtn4 = new CustomControls.CustomBtn();
            customBtn5 = new CustomControls.CustomBtn();
            customBtn6 = new CustomControls.CustomBtn();
            customBtn7 = new CustomControls.CustomBtn();
            customBtn8 = new CustomControls.CustomBtn();
            customBtn9 = new CustomControls.CustomBtn();
            customBtn10 = new CustomControls.CustomBtn();
            customBtn11 = new CustomControls.CustomBtn();
            customBtn12 = new CustomControls.CustomBtn();
            customBtn13 = new CustomControls.CustomBtn();
            customBtn14 = new CustomControls.CustomBtn();
            customBtn15 = new CustomControls.CustomBtn();
            SeatPanel = new Panel();
            customBtn31 = new CustomControls.CustomBtn();
            customBtn30 = new CustomControls.CustomBtn();
            customBtn16 = new CustomControls.CustomBtn();
            customBtn17 = new CustomControls.CustomBtn();
            customBtn18 = new CustomControls.CustomBtn();
            customBtn19 = new CustomControls.CustomBtn();
            customBtn20 = new CustomControls.CustomBtn();
            customBtn21 = new CustomControls.CustomBtn();
            customBtn22 = new CustomControls.CustomBtn();
            customBtn23 = new CustomControls.CustomBtn();
            customBtn24 = new CustomControls.CustomBtn();
            customBtn25 = new CustomControls.CustomBtn();
            customBtn26 = new CustomControls.CustomBtn();
            customBtn27 = new CustomControls.CustomBtn();
            customBtn28 = new CustomControls.CustomBtn();
            customBtn29 = new CustomControls.CustomBtn();
            PassengerFormPanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SeatPanel.SuspendLayout();
            SuspendLayout();
            // 
            // PassengerFormPanel
            // 
            PassengerFormPanel.Controls.Add(panel1);
            PassengerFormPanel.Dock = DockStyle.Left;
            PassengerFormPanel.Location = new Point(0, 0);
            PassengerFormPanel.Name = "PassengerFormPanel";
            PassengerFormPanel.Size = new Size(919, 814);
            PassengerFormPanel.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnConfirmBooking);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(selectedSeatLbl);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(maskedTextBox1);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(165, 192);
            panel1.Name = "panel1";
            panel1.Size = new Size(603, 442);
            panel1.TabIndex = 0;
            // 
            // btnConfirmBooking
            // 
            btnConfirmBooking.BackColor = Color.MediumSlateBlue;
            btnConfirmBooking.BackgroundColor = Color.MediumSlateBlue;
            btnConfirmBooking.BorderColor = Color.PaleVioletRed;
            btnConfirmBooking.BorderRadius = 10;
            btnConfirmBooking.BorderSize = 0;
            btnConfirmBooking.FlatAppearance.BorderSize = 0;
            btnConfirmBooking.FlatStyle = FlatStyle.Flat;
            btnConfirmBooking.ForeColor = Color.White;
            btnConfirmBooking.Location = new Point(235, 336);
            btnConfirmBooking.Name = "btnConfirmBooking";
            btnConfirmBooking.Size = new Size(150, 40);
            btnConfirmBooking.TabIndex = 25;
            btnConfirmBooking.Text = "Confirm Booking";
            btnConfirmBooking.TextColor = Color.White;
            btnConfirmBooking.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(206, 274);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 24;
            label7.Text = "Payment";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(206, 236);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 23;
            label6.Text = "Total Price";
            // 
            // selectedSeatLbl
            // 
            selectedSeatLbl.AutoSize = true;
            selectedSeatLbl.Location = new Point(80, 72);
            selectedSeatLbl.Name = "selectedSeatLbl";
            selectedSeatLbl.Size = new Size(87, 15);
            selectedSeatLbl.TabIndex = 21;
            selectedSeatLbl.Text = "Selected Seats :";
            selectedSeatLbl.Click += selectedSeatLbl_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(403, 178);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(152, 23);
            textBox3.TabIndex = 20;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(133, 178);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(152, 23);
            textBox2.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(344, 186);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 18;
            label4.Text = "Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 186);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 17;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(344, 131);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 16;
            label2.Text = "Phone";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 128);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 15;
            label1.Text = "Full Name";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(403, 123);
            maskedTextBox1.Mask = "(999) 000-0000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.RejectInputOnFirstFailure = true;
            maskedTextBox1.Size = new Size(160, 23);
            maskedTextBox1.TabIndex = 14;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(133, 120);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(152, 23);
            textBox1.TabIndex = 13;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackColor = SystemColors.ActiveCaption;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(333, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(105, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // customBtn1
            // 
            customBtn1.Anchor = AnchorStyles.None;
            customBtn1.BackColor = Color.FromArgb(0, 192, 192);
            customBtn1.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn1.BorderColor = Color.PaleVioletRed;
            customBtn1.BorderRadius = 15;
            customBtn1.BorderSize = 0;
            customBtn1.FlatAppearance.BorderSize = 0;
            customBtn1.FlatStyle = FlatStyle.Flat;
            customBtn1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn1.ForeColor = Color.Transparent;
            customBtn1.Image = (Image)resources.GetObject("customBtn1.Image");
            customBtn1.Location = new Point(34, 230);
            customBtn1.Name = "customBtn1";
            customBtn1.Size = new Size(81, 76);
            customBtn1.TabIndex = 1;
            customBtn1.Text = "A1";
            customBtn1.TextColor = Color.Transparent;
            customBtn1.UseVisualStyleBackColor = false;
            customBtn1.Click += customBtn1_Click;
            // 
            // customBtn2
            // 
            customBtn2.Anchor = AnchorStyles.None;
            customBtn2.BackColor = Color.FromArgb(0, 192, 192);
            customBtn2.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn2.BorderColor = Color.PaleVioletRed;
            customBtn2.BorderRadius = 15;
            customBtn2.BorderSize = 0;
            customBtn2.FlatAppearance.BorderSize = 0;
            customBtn2.FlatStyle = FlatStyle.Flat;
            customBtn2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn2.ForeColor = Color.Transparent;
            customBtn2.Image = (Image)resources.GetObject("customBtn2.Image");
            customBtn2.Location = new Point(123, 230);
            customBtn2.Name = "customBtn2";
            customBtn2.Size = new Size(81, 76);
            customBtn2.TabIndex = 2;
            customBtn2.Text = "A2";
            customBtn2.TextColor = Color.Transparent;
            customBtn2.UseVisualStyleBackColor = false;
            // 
            // customBtn3
            // 
            customBtn3.Anchor = AnchorStyles.None;
            customBtn3.BackColor = Color.FromArgb(0, 192, 192);
            customBtn3.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn3.BorderColor = Color.PaleVioletRed;
            customBtn3.BorderRadius = 15;
            customBtn3.BorderSize = 0;
            customBtn3.FlatAppearance.BorderSize = 0;
            customBtn3.FlatStyle = FlatStyle.Flat;
            customBtn3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn3.ForeColor = Color.Transparent;
            customBtn3.Image = (Image)resources.GetObject("customBtn3.Image");
            customBtn3.Location = new Point(34, 312);
            customBtn3.Name = "customBtn3";
            customBtn3.Size = new Size(81, 76);
            customBtn3.TabIndex = 3;
            customBtn3.Text = "A3";
            customBtn3.TextColor = Color.Transparent;
            customBtn3.UseVisualStyleBackColor = false;
            // 
            // customBtn4
            // 
            customBtn4.Anchor = AnchorStyles.None;
            customBtn4.BackColor = Color.FromArgb(0, 192, 192);
            customBtn4.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn4.BorderColor = Color.PaleVioletRed;
            customBtn4.BorderRadius = 15;
            customBtn4.BorderSize = 0;
            customBtn4.FlatAppearance.BorderSize = 0;
            customBtn4.FlatStyle = FlatStyle.Flat;
            customBtn4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn4.ForeColor = Color.Transparent;
            customBtn4.Image = (Image)resources.GetObject("customBtn4.Image");
            customBtn4.Location = new Point(123, 312);
            customBtn4.Name = "customBtn4";
            customBtn4.Size = new Size(81, 76);
            customBtn4.TabIndex = 4;
            customBtn4.Text = "A4";
            customBtn4.TextColor = Color.Transparent;
            customBtn4.UseVisualStyleBackColor = false;
            // 
            // customBtn5
            // 
            customBtn5.Anchor = AnchorStyles.None;
            customBtn5.BackColor = Color.FromArgb(0, 192, 192);
            customBtn5.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn5.BorderColor = Color.PaleVioletRed;
            customBtn5.BorderRadius = 15;
            customBtn5.BorderSize = 0;
            customBtn5.FlatAppearance.BorderSize = 0;
            customBtn5.FlatStyle = FlatStyle.Flat;
            customBtn5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn5.ForeColor = Color.Transparent;
            customBtn5.Image = (Image)resources.GetObject("customBtn5.Image");
            customBtn5.Location = new Point(34, 394);
            customBtn5.Name = "customBtn5";
            customBtn5.Size = new Size(81, 76);
            customBtn5.TabIndex = 5;
            customBtn5.Text = "A5";
            customBtn5.TextColor = Color.Transparent;
            customBtn5.UseVisualStyleBackColor = false;
            // 
            // customBtn6
            // 
            customBtn6.Anchor = AnchorStyles.None;
            customBtn6.BackColor = Color.FromArgb(0, 192, 192);
            customBtn6.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn6.BorderColor = Color.PaleVioletRed;
            customBtn6.BorderRadius = 15;
            customBtn6.BorderSize = 0;
            customBtn6.FlatAppearance.BorderSize = 0;
            customBtn6.FlatStyle = FlatStyle.Flat;
            customBtn6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn6.ForeColor = Color.Transparent;
            customBtn6.Image = (Image)resources.GetObject("customBtn6.Image");
            customBtn6.Location = new Point(123, 394);
            customBtn6.Name = "customBtn6";
            customBtn6.Size = new Size(81, 76);
            customBtn6.TabIndex = 6;
            customBtn6.Text = "A6";
            customBtn6.TextColor = Color.Transparent;
            customBtn6.UseVisualStyleBackColor = false;
            // 
            // customBtn7
            // 
            customBtn7.Anchor = AnchorStyles.None;
            customBtn7.BackColor = Color.FromArgb(0, 192, 192);
            customBtn7.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn7.BorderColor = Color.PaleVioletRed;
            customBtn7.BorderRadius = 15;
            customBtn7.BorderSize = 0;
            customBtn7.FlatAppearance.BorderSize = 0;
            customBtn7.FlatStyle = FlatStyle.Flat;
            customBtn7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn7.ForeColor = Color.Transparent;
            customBtn7.Image = (Image)resources.GetObject("customBtn7.Image");
            customBtn7.Location = new Point(34, 476);
            customBtn7.Name = "customBtn7";
            customBtn7.Size = new Size(81, 76);
            customBtn7.TabIndex = 7;
            customBtn7.Text = "A7";
            customBtn7.TextColor = Color.Transparent;
            customBtn7.UseVisualStyleBackColor = false;
            // 
            // customBtn8
            // 
            customBtn8.Anchor = AnchorStyles.None;
            customBtn8.BackColor = Color.FromArgb(0, 192, 192);
            customBtn8.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn8.BorderColor = Color.PaleVioletRed;
            customBtn8.BorderRadius = 15;
            customBtn8.BorderSize = 0;
            customBtn8.FlatAppearance.BorderSize = 0;
            customBtn8.FlatStyle = FlatStyle.Flat;
            customBtn8.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn8.ForeColor = Color.Transparent;
            customBtn8.Image = (Image)resources.GetObject("customBtn8.Image");
            customBtn8.Location = new Point(123, 476);
            customBtn8.Name = "customBtn8";
            customBtn8.Size = new Size(81, 76);
            customBtn8.TabIndex = 8;
            customBtn8.Text = "A8";
            customBtn8.TextColor = Color.Transparent;
            customBtn8.UseVisualStyleBackColor = false;
            // 
            // customBtn9
            // 
            customBtn9.Anchor = AnchorStyles.None;
            customBtn9.BackColor = Color.FromArgb(0, 192, 192);
            customBtn9.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn9.BorderColor = Color.PaleVioletRed;
            customBtn9.BorderRadius = 15;
            customBtn9.BorderSize = 0;
            customBtn9.FlatAppearance.BorderSize = 0;
            customBtn9.FlatStyle = FlatStyle.Flat;
            customBtn9.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn9.ForeColor = Color.Transparent;
            customBtn9.Image = (Image)resources.GetObject("customBtn9.Image");
            customBtn9.Location = new Point(34, 558);
            customBtn9.Name = "customBtn9";
            customBtn9.Size = new Size(81, 76);
            customBtn9.TabIndex = 9;
            customBtn9.Text = "A9";
            customBtn9.TextColor = Color.Transparent;
            customBtn9.UseVisualStyleBackColor = false;
            // 
            // customBtn10
            // 
            customBtn10.Anchor = AnchorStyles.None;
            customBtn10.BackColor = Color.FromArgb(0, 192, 192);
            customBtn10.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn10.BorderColor = Color.PaleVioletRed;
            customBtn10.BorderRadius = 15;
            customBtn10.BorderSize = 0;
            customBtn10.FlatAppearance.BorderSize = 0;
            customBtn10.FlatStyle = FlatStyle.Flat;
            customBtn10.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn10.ForeColor = Color.Transparent;
            customBtn10.Image = (Image)resources.GetObject("customBtn10.Image");
            customBtn10.Location = new Point(123, 558);
            customBtn10.Name = "customBtn10";
            customBtn10.Size = new Size(81, 76);
            customBtn10.TabIndex = 10;
            customBtn10.Text = "A10";
            customBtn10.TextColor = Color.Transparent;
            customBtn10.UseVisualStyleBackColor = false;
            // 
            // customBtn11
            // 
            customBtn11.Anchor = AnchorStyles.None;
            customBtn11.BackColor = Color.FromArgb(0, 192, 192);
            customBtn11.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn11.BorderColor = Color.PaleVioletRed;
            customBtn11.BorderRadius = 15;
            customBtn11.BorderSize = 0;
            customBtn11.FlatAppearance.BorderSize = 0;
            customBtn11.FlatStyle = FlatStyle.Flat;
            customBtn11.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn11.ForeColor = Color.Transparent;
            customBtn11.Image = (Image)resources.GetObject("customBtn11.Image");
            customBtn11.Location = new Point(34, 640);
            customBtn11.Name = "customBtn11";
            customBtn11.Size = new Size(81, 76);
            customBtn11.TabIndex = 11;
            customBtn11.Text = "A11";
            customBtn11.TextColor = Color.Transparent;
            customBtn11.UseVisualStyleBackColor = false;
            // 
            // customBtn12
            // 
            customBtn12.Anchor = AnchorStyles.None;
            customBtn12.BackColor = Color.FromArgb(0, 192, 192);
            customBtn12.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn12.BorderColor = Color.PaleVioletRed;
            customBtn12.BorderRadius = 15;
            customBtn12.BorderSize = 0;
            customBtn12.FlatAppearance.BorderSize = 0;
            customBtn12.FlatStyle = FlatStyle.Flat;
            customBtn12.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn12.ForeColor = Color.Transparent;
            customBtn12.Image = (Image)resources.GetObject("customBtn12.Image");
            customBtn12.Location = new Point(123, 640);
            customBtn12.Name = "customBtn12";
            customBtn12.Size = new Size(81, 76);
            customBtn12.TabIndex = 12;
            customBtn12.Text = "A12";
            customBtn12.TextColor = Color.Transparent;
            customBtn12.UseVisualStyleBackColor = false;
            // 
            // customBtn13
            // 
            customBtn13.Anchor = AnchorStyles.None;
            customBtn13.BackColor = Color.FromArgb(0, 192, 192);
            customBtn13.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn13.BorderColor = Color.PaleVioletRed;
            customBtn13.BorderRadius = 15;
            customBtn13.BorderSize = 0;
            customBtn13.FlatAppearance.BorderSize = 0;
            customBtn13.FlatStyle = FlatStyle.Flat;
            customBtn13.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn13.ForeColor = Color.Transparent;
            customBtn13.Image = (Image)resources.GetObject("customBtn13.Image");
            customBtn13.Location = new Point(34, 722);
            customBtn13.Name = "customBtn13";
            customBtn13.Size = new Size(81, 76);
            customBtn13.TabIndex = 13;
            customBtn13.Text = "A13";
            customBtn13.TextColor = Color.Transparent;
            customBtn13.UseVisualStyleBackColor = false;
            // 
            // customBtn14
            // 
            customBtn14.Anchor = AnchorStyles.None;
            customBtn14.BackColor = Color.FromArgb(0, 192, 192);
            customBtn14.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn14.BorderColor = Color.PaleVioletRed;
            customBtn14.BorderRadius = 15;
            customBtn14.BorderSize = 0;
            customBtn14.FlatAppearance.BorderSize = 0;
            customBtn14.FlatStyle = FlatStyle.Flat;
            customBtn14.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn14.ForeColor = Color.Transparent;
            customBtn14.Image = (Image)resources.GetObject("customBtn14.Image");
            customBtn14.Location = new Point(123, 722);
            customBtn14.Name = "customBtn14";
            customBtn14.Size = new Size(81, 76);
            customBtn14.TabIndex = 14;
            customBtn14.Text = "A14";
            customBtn14.TextColor = Color.Transparent;
            customBtn14.UseVisualStyleBackColor = false;
            // 
            // customBtn15
            // 
            customBtn15.Anchor = AnchorStyles.None;
            customBtn15.BackColor = Color.FromArgb(0, 192, 192);
            customBtn15.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn15.BorderColor = Color.PaleVioletRed;
            customBtn15.BorderRadius = 15;
            customBtn15.BorderSize = 0;
            customBtn15.FlatAppearance.BorderSize = 0;
            customBtn15.FlatStyle = FlatStyle.Flat;
            customBtn15.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn15.ForeColor = Color.Transparent;
            customBtn15.Image = (Image)resources.GetObject("customBtn15.Image");
            customBtn15.Location = new Point(213, 722);
            customBtn15.Name = "customBtn15";
            customBtn15.Size = new Size(81, 76);
            customBtn15.TabIndex = 15;
            customBtn15.Text = "A15";
            customBtn15.TextColor = Color.Transparent;
            customBtn15.UseVisualStyleBackColor = false;
            // 
            // SeatPanel
            // 
            SeatPanel.Anchor = AnchorStyles.None;
            SeatPanel.BackgroundImageLayout = ImageLayout.Zoom;
            SeatPanel.Controls.Add(customBtn31);
            SeatPanel.Controls.Add(customBtn30);
            SeatPanel.Controls.Add(customBtn16);
            SeatPanel.Controls.Add(customBtn17);
            SeatPanel.Controls.Add(customBtn18);
            SeatPanel.Controls.Add(customBtn19);
            SeatPanel.Controls.Add(customBtn20);
            SeatPanel.Controls.Add(customBtn21);
            SeatPanel.Controls.Add(customBtn22);
            SeatPanel.Controls.Add(customBtn23);
            SeatPanel.Controls.Add(customBtn24);
            SeatPanel.Controls.Add(customBtn25);
            SeatPanel.Controls.Add(customBtn26);
            SeatPanel.Controls.Add(customBtn27);
            SeatPanel.Controls.Add(customBtn28);
            SeatPanel.Controls.Add(customBtn29);
            SeatPanel.Controls.Add(customBtn15);
            SeatPanel.Controls.Add(customBtn14);
            SeatPanel.Controls.Add(customBtn13);
            SeatPanel.Controls.Add(customBtn12);
            SeatPanel.Controls.Add(customBtn11);
            SeatPanel.Controls.Add(customBtn10);
            SeatPanel.Controls.Add(customBtn9);
            SeatPanel.Controls.Add(customBtn8);
            SeatPanel.Controls.Add(customBtn7);
            SeatPanel.Controls.Add(customBtn6);
            SeatPanel.Controls.Add(customBtn5);
            SeatPanel.Controls.Add(customBtn4);
            SeatPanel.Controls.Add(customBtn3);
            SeatPanel.Controls.Add(customBtn2);
            SeatPanel.Controls.Add(customBtn1);
            SeatPanel.Controls.Add(pictureBox1);
            SeatPanel.Location = new Point(925, 0);
            SeatPanel.Name = "SeatPanel";
            SeatPanel.Size = new Size(494, 814);
            SeatPanel.TabIndex = 0;
            SeatPanel.Paint += SeatPanel_Paint;
            // 
            // customBtn31
            // 
            customBtn31.Anchor = AnchorStyles.None;
            customBtn31.BackColor = Color.FromArgb(0, 192, 192);
            customBtn31.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn31.BorderColor = Color.PaleVioletRed;
            customBtn31.BorderRadius = 15;
            customBtn31.BorderSize = 0;
            customBtn31.FlatAppearance.BorderSize = 0;
            customBtn31.FlatStyle = FlatStyle.Flat;
            customBtn31.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn31.ForeColor = Color.Transparent;
            customBtn31.Image = (Image)resources.GetObject("customBtn31.Image");
            customBtn31.Location = new Point(390, 148);
            customBtn31.Name = "customBtn31";
            customBtn31.Size = new Size(81, 76);
            customBtn31.TabIndex = 31;
            customBtn31.Text = "KHA";
            customBtn31.TextColor = Color.Transparent;
            customBtn31.UseVisualStyleBackColor = false;
            // 
            // customBtn30
            // 
            customBtn30.Anchor = AnchorStyles.None;
            customBtn30.BackColor = Color.FromArgb(0, 192, 192);
            customBtn30.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn30.BorderColor = Color.PaleVioletRed;
            customBtn30.BorderRadius = 15;
            customBtn30.BorderSize = 0;
            customBtn30.FlatAppearance.BorderSize = 0;
            customBtn30.FlatStyle = FlatStyle.Flat;
            customBtn30.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn30.ForeColor = Color.Transparent;
            customBtn30.Image = (Image)resources.GetObject("customBtn30.Image");
            customBtn30.Location = new Point(303, 148);
            customBtn30.Name = "customBtn30";
            customBtn30.Size = new Size(81, 76);
            customBtn30.TabIndex = 30;
            customBtn30.Text = "KA";
            customBtn30.TextColor = Color.Transparent;
            customBtn30.UseVisualStyleBackColor = false;
            // 
            // customBtn16
            // 
            customBtn16.Anchor = AnchorStyles.None;
            customBtn16.BackColor = Color.FromArgb(0, 192, 192);
            customBtn16.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn16.BorderColor = Color.PaleVioletRed;
            customBtn16.BorderRadius = 15;
            customBtn16.BorderSize = 0;
            customBtn16.FlatAppearance.BorderSize = 0;
            customBtn16.FlatStyle = FlatStyle.Flat;
            customBtn16.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn16.ForeColor = Color.Transparent;
            customBtn16.Image = (Image)resources.GetObject("customBtn16.Image");
            customBtn16.Location = new Point(390, 722);
            customBtn16.Name = "customBtn16";
            customBtn16.Size = new Size(81, 76);
            customBtn16.TabIndex = 29;
            customBtn16.Text = "B14";
            customBtn16.TextColor = Color.Transparent;
            customBtn16.UseVisualStyleBackColor = false;
            // 
            // customBtn17
            // 
            customBtn17.Anchor = AnchorStyles.None;
            customBtn17.BackColor = Color.FromArgb(0, 192, 192);
            customBtn17.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn17.BorderColor = Color.PaleVioletRed;
            customBtn17.BorderRadius = 15;
            customBtn17.BorderSize = 0;
            customBtn17.FlatAppearance.BorderSize = 0;
            customBtn17.FlatStyle = FlatStyle.Flat;
            customBtn17.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn17.ForeColor = Color.Transparent;
            customBtn17.Image = (Image)resources.GetObject("customBtn17.Image");
            customBtn17.Location = new Point(303, 722);
            customBtn17.Name = "customBtn17";
            customBtn17.Size = new Size(81, 76);
            customBtn17.TabIndex = 28;
            customBtn17.Text = "B13";
            customBtn17.TextColor = Color.Transparent;
            customBtn17.UseVisualStyleBackColor = false;
            // 
            // customBtn18
            // 
            customBtn18.Anchor = AnchorStyles.None;
            customBtn18.BackColor = Color.FromArgb(0, 192, 192);
            customBtn18.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn18.BorderColor = Color.PaleVioletRed;
            customBtn18.BorderRadius = 15;
            customBtn18.BorderSize = 0;
            customBtn18.FlatAppearance.BorderSize = 0;
            customBtn18.FlatStyle = FlatStyle.Flat;
            customBtn18.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn18.ForeColor = Color.Transparent;
            customBtn18.Image = (Image)resources.GetObject("customBtn18.Image");
            customBtn18.Location = new Point(392, 640);
            customBtn18.Name = "customBtn18";
            customBtn18.Size = new Size(81, 76);
            customBtn18.TabIndex = 27;
            customBtn18.Text = "B12";
            customBtn18.TextColor = Color.Transparent;
            customBtn18.UseVisualStyleBackColor = false;
            // 
            // customBtn19
            // 
            customBtn19.Anchor = AnchorStyles.None;
            customBtn19.BackColor = Color.FromArgb(0, 192, 192);
            customBtn19.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn19.BorderColor = Color.PaleVioletRed;
            customBtn19.BorderRadius = 15;
            customBtn19.BorderSize = 0;
            customBtn19.FlatAppearance.BorderSize = 0;
            customBtn19.FlatStyle = FlatStyle.Flat;
            customBtn19.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn19.ForeColor = Color.Transparent;
            customBtn19.Image = (Image)resources.GetObject("customBtn19.Image");
            customBtn19.Location = new Point(303, 640);
            customBtn19.Name = "customBtn19";
            customBtn19.Size = new Size(81, 76);
            customBtn19.TabIndex = 26;
            customBtn19.Text = "B11";
            customBtn19.TextColor = Color.Transparent;
            customBtn19.UseVisualStyleBackColor = false;
            // 
            // customBtn20
            // 
            customBtn20.Anchor = AnchorStyles.None;
            customBtn20.BackColor = Color.FromArgb(0, 192, 192);
            customBtn20.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn20.BorderColor = Color.PaleVioletRed;
            customBtn20.BorderRadius = 15;
            customBtn20.BorderSize = 0;
            customBtn20.FlatAppearance.BorderSize = 0;
            customBtn20.FlatStyle = FlatStyle.Flat;
            customBtn20.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn20.ForeColor = Color.Transparent;
            customBtn20.Image = (Image)resources.GetObject("customBtn20.Image");
            customBtn20.Location = new Point(392, 558);
            customBtn20.Name = "customBtn20";
            customBtn20.Size = new Size(81, 76);
            customBtn20.TabIndex = 25;
            customBtn20.Text = "B10";
            customBtn20.TextColor = Color.Transparent;
            customBtn20.UseVisualStyleBackColor = false;
            // 
            // customBtn21
            // 
            customBtn21.Anchor = AnchorStyles.None;
            customBtn21.BackColor = Color.FromArgb(0, 192, 192);
            customBtn21.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn21.BorderColor = Color.PaleVioletRed;
            customBtn21.BorderRadius = 15;
            customBtn21.BorderSize = 0;
            customBtn21.FlatAppearance.BorderSize = 0;
            customBtn21.FlatStyle = FlatStyle.Flat;
            customBtn21.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn21.ForeColor = Color.Transparent;
            customBtn21.Image = (Image)resources.GetObject("customBtn21.Image");
            customBtn21.Location = new Point(303, 558);
            customBtn21.Name = "customBtn21";
            customBtn21.Size = new Size(81, 76);
            customBtn21.TabIndex = 24;
            customBtn21.Text = "B9";
            customBtn21.TextColor = Color.Transparent;
            customBtn21.UseVisualStyleBackColor = false;
            // 
            // customBtn22
            // 
            customBtn22.Anchor = AnchorStyles.None;
            customBtn22.BackColor = Color.FromArgb(0, 192, 192);
            customBtn22.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn22.BorderColor = Color.PaleVioletRed;
            customBtn22.BorderRadius = 15;
            customBtn22.BorderSize = 0;
            customBtn22.FlatAppearance.BorderSize = 0;
            customBtn22.FlatStyle = FlatStyle.Flat;
            customBtn22.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn22.ForeColor = Color.Transparent;
            customBtn22.Image = (Image)resources.GetObject("customBtn22.Image");
            customBtn22.Location = new Point(392, 476);
            customBtn22.Name = "customBtn22";
            customBtn22.Size = new Size(81, 76);
            customBtn22.TabIndex = 23;
            customBtn22.Text = "B8";
            customBtn22.TextColor = Color.Transparent;
            customBtn22.UseVisualStyleBackColor = false;
            // 
            // customBtn23
            // 
            customBtn23.Anchor = AnchorStyles.None;
            customBtn23.BackColor = Color.FromArgb(0, 192, 192);
            customBtn23.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn23.BorderColor = Color.PaleVioletRed;
            customBtn23.BorderRadius = 15;
            customBtn23.BorderSize = 0;
            customBtn23.FlatAppearance.BorderSize = 0;
            customBtn23.FlatStyle = FlatStyle.Flat;
            customBtn23.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn23.ForeColor = Color.Transparent;
            customBtn23.Image = (Image)resources.GetObject("customBtn23.Image");
            customBtn23.Location = new Point(303, 476);
            customBtn23.Name = "customBtn23";
            customBtn23.Size = new Size(81, 76);
            customBtn23.TabIndex = 22;
            customBtn23.Text = "B7";
            customBtn23.TextColor = Color.Transparent;
            customBtn23.UseVisualStyleBackColor = false;
            // 
            // customBtn24
            // 
            customBtn24.Anchor = AnchorStyles.None;
            customBtn24.BackColor = Color.FromArgb(0, 192, 192);
            customBtn24.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn24.BorderColor = Color.PaleVioletRed;
            customBtn24.BorderRadius = 15;
            customBtn24.BorderSize = 0;
            customBtn24.FlatAppearance.BorderSize = 0;
            customBtn24.FlatStyle = FlatStyle.Flat;
            customBtn24.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn24.ForeColor = Color.Transparent;
            customBtn24.Image = (Image)resources.GetObject("customBtn24.Image");
            customBtn24.Location = new Point(392, 394);
            customBtn24.Name = "customBtn24";
            customBtn24.Size = new Size(81, 76);
            customBtn24.TabIndex = 21;
            customBtn24.Text = "B6";
            customBtn24.TextColor = Color.Transparent;
            customBtn24.UseVisualStyleBackColor = false;
            // 
            // customBtn25
            // 
            customBtn25.Anchor = AnchorStyles.None;
            customBtn25.BackColor = Color.FromArgb(0, 192, 192);
            customBtn25.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn25.BorderColor = Color.PaleVioletRed;
            customBtn25.BorderRadius = 15;
            customBtn25.BorderSize = 0;
            customBtn25.FlatAppearance.BorderSize = 0;
            customBtn25.FlatStyle = FlatStyle.Flat;
            customBtn25.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn25.ForeColor = Color.Transparent;
            customBtn25.Image = (Image)resources.GetObject("customBtn25.Image");
            customBtn25.Location = new Point(303, 394);
            customBtn25.Name = "customBtn25";
            customBtn25.Size = new Size(81, 76);
            customBtn25.TabIndex = 20;
            customBtn25.Text = "B5";
            customBtn25.TextColor = Color.Transparent;
            customBtn25.UseVisualStyleBackColor = false;
            // 
            // customBtn26
            // 
            customBtn26.Anchor = AnchorStyles.None;
            customBtn26.BackColor = Color.FromArgb(0, 192, 192);
            customBtn26.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn26.BorderColor = Color.PaleVioletRed;
            customBtn26.BorderRadius = 15;
            customBtn26.BorderSize = 0;
            customBtn26.FlatAppearance.BorderSize = 0;
            customBtn26.FlatStyle = FlatStyle.Flat;
            customBtn26.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn26.ForeColor = Color.Transparent;
            customBtn26.Image = (Image)resources.GetObject("customBtn26.Image");
            customBtn26.Location = new Point(392, 312);
            customBtn26.Name = "customBtn26";
            customBtn26.Size = new Size(81, 76);
            customBtn26.TabIndex = 19;
            customBtn26.Text = "B4";
            customBtn26.TextColor = Color.Transparent;
            customBtn26.UseVisualStyleBackColor = false;
            // 
            // customBtn27
            // 
            customBtn27.Anchor = AnchorStyles.None;
            customBtn27.BackColor = Color.FromArgb(0, 192, 192);
            customBtn27.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn27.BorderColor = Color.PaleVioletRed;
            customBtn27.BorderRadius = 15;
            customBtn27.BorderSize = 0;
            customBtn27.FlatAppearance.BorderSize = 0;
            customBtn27.FlatStyle = FlatStyle.Flat;
            customBtn27.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn27.ForeColor = Color.Transparent;
            customBtn27.Image = (Image)resources.GetObject("customBtn27.Image");
            customBtn27.Location = new Point(303, 312);
            customBtn27.Name = "customBtn27";
            customBtn27.Size = new Size(81, 76);
            customBtn27.TabIndex = 18;
            customBtn27.Text = "B3";
            customBtn27.TextColor = Color.Transparent;
            customBtn27.UseVisualStyleBackColor = false;
            // 
            // customBtn28
            // 
            customBtn28.Anchor = AnchorStyles.None;
            customBtn28.BackColor = Color.FromArgb(0, 192, 192);
            customBtn28.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn28.BorderColor = Color.PaleVioletRed;
            customBtn28.BorderRadius = 15;
            customBtn28.BorderSize = 0;
            customBtn28.FlatAppearance.BorderSize = 0;
            customBtn28.FlatStyle = FlatStyle.Flat;
            customBtn28.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn28.ForeColor = Color.Transparent;
            customBtn28.Image = (Image)resources.GetObject("customBtn28.Image");
            customBtn28.Location = new Point(392, 230);
            customBtn28.Name = "customBtn28";
            customBtn28.Size = new Size(81, 76);
            customBtn28.TabIndex = 17;
            customBtn28.Text = "B2";
            customBtn28.TextColor = Color.Transparent;
            customBtn28.UseVisualStyleBackColor = false;
            // 
            // customBtn29
            // 
            customBtn29.Anchor = AnchorStyles.None;
            customBtn29.BackColor = Color.FromArgb(0, 192, 192);
            customBtn29.BackgroundColor = Color.FromArgb(0, 192, 192);
            customBtn29.BorderColor = Color.PaleVioletRed;
            customBtn29.BorderRadius = 15;
            customBtn29.BorderSize = 0;
            customBtn29.FlatAppearance.BorderSize = 0;
            customBtn29.FlatStyle = FlatStyle.Flat;
            customBtn29.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            customBtn29.ForeColor = Color.Transparent;
            customBtn29.Image = (Image)resources.GetObject("customBtn29.Image");
            customBtn29.Location = new Point(303, 230);
            customBtn29.Name = "customBtn29";
            customBtn29.Size = new Size(81, 76);
            customBtn29.TabIndex = 16;
            customBtn29.Text = "B1";
            customBtn29.TextColor = Color.Transparent;
            customBtn29.UseVisualStyleBackColor = false;
            // 
            // SeatSelection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PassengerFormPanel);
            Controls.Add(SeatPanel);
            Name = "SeatSelection";
            Size = new Size(1419, 814);
            PassengerFormPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            SeatPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel PassengerFormPanel;
        private PictureBox pictureBox1;
        private CustomBtn customBtn1;
        private CustomBtn customBtn2;
        private CustomBtn customBtn3;
        private CustomBtn customBtn4;
        private CustomBtn customBtn5;
        private CustomBtn customBtn6;
        private CustomBtn customBtn7;
        private CustomBtn customBtn8;
        private CustomBtn customBtn9;
        private CustomBtn customBtn10;
        private CustomBtn customBtn11;
        private CustomBtn customBtn12;
        private CustomBtn customBtn13;
        private CustomBtn customBtn14;
        private CustomBtn customBtn15;
        private Panel SeatPanel;
        private CustomBtn customBtn16;
        private CustomBtn customBtn17;
        private CustomBtn customBtn18;
        private CustomBtn customBtn19;
        private CustomBtn customBtn20;
        private CustomBtn customBtn21;
        private CustomBtn customBtn22;
        private CustomBtn customBtn23;
        private CustomBtn customBtn24;
        private CustomBtn customBtn25;
        private CustomBtn customBtn26;
        private CustomBtn customBtn27;
        private CustomBtn customBtn28;
        private CustomBtn customBtn29;
        private CustomBtn customBtn31;
        private CustomBtn customBtn30;
        private Panel panel1;
        private CustomBtn btnConfirmBooking;
        private Label label7;
        private Label label6;
        public static  Label selectedSeatLbl;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private MaskedTextBox maskedTextBox1;
        private TextBox textBox1;
    }
}
