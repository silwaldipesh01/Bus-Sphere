using Bus_Sphere.CustomForm;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_Sphere.packages
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            //  LoadBuses loadBuses = new LoadBuses();

            //  loadform(loadBuses);
            //loadform(new FormCstm.LoadBusesControl());
            //LoadBusesFormControl loadBusesFormControl = new LoadBusesFormControl();
            //LoadUserControl(loadBusesFormControl);
            //SeatSelection seatSelection = new SeatSelection();
            //LoadUserControl(seatSelection);
            BusList busList = new BusList();
            LoadUserControl(busList);
        }
        //    public void loadform(object Form)
        public void loadform(object Form)

        {
            if (this.MainPanel.Controls.Count > 0)
                this.MainPanel.Controls.RemoveAt(0);
            Form f = Form as Form;

            f.TopLevel = false;
            f.Dock = DockStyle.Fill;

            //  f.DragDrop = false;
            this.MainPanel.Controls.Add(f);
            this.MainPanel.Tag = f;
            f.Show();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }
        public void LoadUserControl(UserControl userControl)
        {
            // Clear existing controls
            MainPanel.BringToFront();
            MainPanel.Controls.Clear();

            // Add the UserControl to the panel
            userControl.Dock = DockStyle.Fill;  // Dock to fill the panel
            MainPanel.Controls.Add(userControl);  // Add UserControl to the panel
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
