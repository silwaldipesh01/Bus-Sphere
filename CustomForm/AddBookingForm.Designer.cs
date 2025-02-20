namespace Bus_Sphere
{
    partial class AddBookingForm
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
            DateTimePicker StartDateTimePicker;
            panel1 = new Panel();
            BusNameGridView = new DataGridView();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            panel2 = new Panel();
            EndDateTimePicker = new DateTimePicker();
            lblEndDate = new Label();
            lblStartDate = new Label();
            label2 = new Label();
            TxtBusNumber = new TextBox();
            lblTicketPrice = new Label();
            label1 = new Label();
            lblthrough = new Label();
            lblStart = new Label();
            BtnAddRoute = new CustomControls.CustomBtn();
            TxtBxTicketPrice = new TextBox();
            TxtBxThrough = new TextBox();
            TxtBxDestination = new TextBox();
            TxtBxSource = new TextBox();
            StartDateTimePicker = new DateTimePicker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BusNameGridView).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // StartDateTimePicker
            // 
            StartDateTimePicker.CalendarMonthBackground = Color.Beige;
            StartDateTimePicker.CustomFormat = " yyyy-MM-dd HH:mm:ss";
            StartDateTimePicker.Format = DateTimePickerFormat.Custom;
            StartDateTimePicker.Location = new Point(150, 374);
            StartDateTimePicker.MaxDate = new DateTime(2028, 12, 31, 0, 0, 0, 0);
            StartDateTimePicker.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            StartDateTimePicker.Name = "StartDateTimePicker";
            StartDateTimePicker.RightToLeftLayout = true;
            StartDateTimePicker.ShowUpDown = true;
            StartDateTimePicker.Size = new Size(200, 23);
            StartDateTimePicker.TabIndex = 16;
            StartDateTimePicker.Value = new DateTime(2025, 2, 20, 5, 40, 36, 0);
            // 
            // panel1
            // 
            panel1.Controls.Add(BusNameGridView);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(756, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(260, 599);
            panel1.TabIndex = 0;
            // 
            // BusNameGridView
            // 
            BusNameGridView.BackgroundColor = Color.Beige;
            BusNameGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BusNameGridView.Dock = DockStyle.Fill;
            BusNameGridView.GridColor = Color.White;
            BusNameGridView.Location = new Point(0, 0);
            BusNameGridView.Name = "BusNameGridView";
            BusNameGridView.Size = new Size(260, 599);
            BusNameGridView.TabIndex = 0;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(EndDateTimePicker);
            panel2.Controls.Add(StartDateTimePicker);
            panel2.Controls.Add(lblEndDate);
            panel2.Controls.Add(lblStartDate);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(TxtBusNumber);
            panel2.Controls.Add(lblTicketPrice);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(lblthrough);
            panel2.Controls.Add(lblStart);
            panel2.Controls.Add(BtnAddRoute);
            panel2.Controls.Add(TxtBxTicketPrice);
            panel2.Controls.Add(TxtBxThrough);
            panel2.Controls.Add(TxtBxDestination);
            panel2.Controls.Add(TxtBxSource);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(756, 599);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // EndDateTimePicker
            // 
            EndDateTimePicker.CalendarMonthBackground = Color.Beige;
            EndDateTimePicker.CustomFormat = " yyyy-MM-dd HH:mm:ss";
            EndDateTimePicker.Format = DateTimePickerFormat.Custom;
            EndDateTimePicker.Location = new Point(469, 374);
            EndDateTimePicker.Name = "EndDateTimePicker";
            EndDateTimePicker.ShowUpDown = true;
            EndDateTimePicker.Size = new Size(200, 23);
            EndDateTimePicker.TabIndex = 17;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(383, 380);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(54, 15);
            lblEndDate.TabIndex = 15;
            lblEndDate.Text = "End Date";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(72, 380);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(58, 15);
            lblStartDate.TabIndex = 14;
            lblStartDate.Text = "Start Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(327, 233);
            label2.Name = "label2";
            label2.Size = new Size(151, 15);
            label2.TabIndex = 12;
            label2.Text = "Choose bus From the Table";
            // 
            // TxtBusNumber
            // 
            TxtBusNumber.BackColor = Color.Beige;
            TxtBusNumber.Location = new Point(492, 230);
            TxtBusNumber.Name = "TxtBusNumber";
            TxtBusNumber.Size = new Size(162, 23);
            TxtBusNumber.TabIndex = 11;
            // 
            // lblTicketPrice
            // 
            lblTicketPrice.AutoSize = true;
            lblTicketPrice.Location = new Point(62, 233);
            lblTicketPrice.Name = "lblTicketPrice";
            lblTicketPrice.Size = new Size(68, 15);
            lblTicketPrice.TabIndex = 10;
            lblTicketPrice.Text = "Ticekt Price";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(492, 126);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 9;
            label1.Text = "Destination";
            // 
            // lblthrough
            // 
            lblthrough.AutoSize = true;
            lblthrough.Location = new Point(284, 126);
            lblthrough.Name = "lblthrough";
            lblthrough.Size = new Size(53, 15);
            lblthrough.TabIndex = 8;
            lblthrough.Text = "Through";
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new Point(62, 126);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(31, 15);
            lblStart.TabIndex = 7;
            lblStart.Text = "Start";
            // 
            // BtnAddRoute
            // 
            BtnAddRoute.BackColor = Color.FromArgb(30, 129, 176);
            BtnAddRoute.BackgroundColor = Color.FromArgb(30, 129, 176);
            BtnAddRoute.BorderColor = Color.PaleVioletRed;
            BtnAddRoute.BorderRadius = 0;
            BtnAddRoute.BorderSize = 0;
            BtnAddRoute.FlatAppearance.BorderSize = 0;
            BtnAddRoute.FlatAppearance.MouseDownBackColor = Color.FromArgb(36, 154, 211);
            BtnAddRoute.FlatAppearance.MouseOverBackColor = Color.FromArgb(36, 154, 211);
            BtnAddRoute.FlatStyle = FlatStyle.Flat;
            BtnAddRoute.ForeColor = Color.White;
            BtnAddRoute.Location = new Point(328, 501);
            BtnAddRoute.Name = "BtnAddRoute";
            BtnAddRoute.Size = new Size(150, 40);
            BtnAddRoute.TabIndex = 6;
            BtnAddRoute.Text = "Add Booking";
            BtnAddRoute.TextColor = Color.White;
            BtnAddRoute.UseVisualStyleBackColor = false;
            BtnAddRoute.Click += BtnAddRoute_Click_1;
            // 
            // TxtBxTicketPrice
            // 
            TxtBxTicketPrice.BackColor = Color.Beige;
            TxtBxTicketPrice.ForeColor = Color.Black;
            TxtBxTicketPrice.Location = new Point(150, 230);
            TxtBxTicketPrice.Name = "TxtBxTicketPrice";
            TxtBxTicketPrice.Size = new Size(100, 23);
            TxtBxTicketPrice.TabIndex = 3;
            // 
            // TxtBxThrough
            // 
            TxtBxThrough.BackColor = Color.Beige;
            TxtBxThrough.ForeColor = Color.Black;
            TxtBxThrough.Location = new Point(360, 118);
            TxtBxThrough.Name = "TxtBxThrough";
            TxtBxThrough.Size = new Size(100, 23);
            TxtBxThrough.TabIndex = 2;
            // 
            // TxtBxDestination
            // 
            TxtBxDestination.BackColor = Color.Beige;
            TxtBxDestination.ForeColor = Color.Black;
            TxtBxDestination.Location = new Point(587, 118);
            TxtBxDestination.Name = "TxtBxDestination";
            TxtBxDestination.Size = new Size(100, 23);
            TxtBxDestination.TabIndex = 1;
            // 
            // TxtBxSource
            // 
            TxtBxSource.BackColor = Color.Beige;
            TxtBxSource.ForeColor = Color.Black;
            TxtBxSource.Location = new Point(150, 118);
            TxtBxSource.Name = "TxtBxSource";
            TxtBxSource.Size = new Size(100, 23);
            TxtBxSource.TabIndex = 0;
            // 
            // AddBookingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "AddBookingForm";
            Size = new Size(1016, 599);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)BusNameGridView).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private DataGridView BusNameGridView;
        private Panel panel2;
        private TextBox TxtBxTicketPrice;
        private TextBox TxtBxThrough;
        private TextBox TxtBxDestination;
        private TextBox TxtBxSource;
        private CustomControls.CustomBtn BtnAddRoute;
        private Label label1;
        private Label lblthrough;
        private Label lblStart;
        private Label label2;
        private TextBox TxtBusNumber;
        private Label lblTicketPrice;
        private Label lblEndDate;
        private Label lblStartDate;
        private DateTimePicker EndDateTimePicker;
        private DateTimePicker StartDateTimePicker;
    }
}
