using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;   

namespace Bus_Sphere.CustomForm
{
    public partial class SeatSelection : UserControl
    {
        public string busid;
        string connectionString = "server=localhost;user=root;database=bussphere;port=3306;password=";  
        public SeatSelection(string busid)
        {
            InitializeComponent();
            this.busid = busid;
            SelectBus();

        }
        public void SeatBtnPressed(string seatNumber)
        {
          
        }
        public void SelectBus()
        {
            try
            {
                string query = "SELECT * FROM Bus WHERE bus_id = " + busid;
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.ConnectionString = connectionString;
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string busid = reader["bus_id"].ToString();
                        MessageBox.Show(busid);
                    }
                    reader.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error "+ ex);
            }
        }
    }
}
