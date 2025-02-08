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

namespace Bus_Sphere.Models
{
    public partial class SeatDesign : UserControl
    {
        const string connectionString = "server=localhost;user=root;database=bussphere;port=3306;password=";
        public SeatDesign()
        {
            InitializeComponent();
        }

        private void customBtn1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
