thse arre the data base designs used in this application


```csharp name=Program.cs
using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Bus_Sphere.packages;

namespace Bus_Sphere
{
    internal static class Program
    {
        private const string connectionString = "server=localhost;user=root;database=bussphere;port=3306;password=";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Start XAMPP with Apache and MySQL
            StartXAMPPServices();

            // Create the necessary tables if they do not exist
            CreateDatabaseAndTables();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            // ApplicationConfiguration.Initialize();
             //Application.Run(new LoginPage());
            // Application.Run(new LoadBuses());
            Application.Run(new MainPage());
        }

        private static void StartXAMPPServices()
        {
            try
            {
                Process xamppProcess = new Process();
                xamppProcess.StartInfo.FileName = "cmd.exe";
                xamppProcess.StartInfo.Arguments = "/C xampp_start";
                xamppProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                xamppProcess.Start();
                xamppProcess.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting XAMPP services: " + ex.Message);
            }
        }

        private static void CreateDatabaseAndTables()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string createDatabase = @"
                        CREATE DATABASE IF NOT EXISTS BusSphere;
                        USE BusSphere;
                    ";

                    string createBusTable = @"
                        CREATE TABLE IF NOT EXISTS bus (
                            bus_id INT AUTO_INCREMENT PRIMARY KEY,
                            bus_name VARCHAR(255) NOT NULL,
                            total_seats INT NOT NULL,
                            bus_type ENUM('AC', 'Non-AC', 'Sleeper', 'Luxury', 'Electric') NOT NULL,
                            bus_number VARCHAR(50) UNIQUE NOT NULL
                        );
                    ";

                    string createRoutingTable = @"
                        CREATE TABLE IF NOT EXISTS routing (
                            route_id INT AUTO_INCREMENT PRIMARY KEY,
                            bus_id INT NOT NULL,
                            departure_location VARCHAR(255) NOT NULL,
                            arrival_location VARCHAR(255) NOT NULL,
                            departure_time TIME NOT NULL,
                            arrival_time TIME NOT NULL,
                            ticket_price DECIMAL(10,2) NOT NULL,
                            through_location TEXT,
                            FOREIGN KEY (bus_id) REFERENCES bus(bus_id) ON DELETE CASCADE
                        );
                    ";

                    string createPassengersTable = @"
                        CREATE TABLE IF NOT EXISTS passengers (
                            passenger_id INT AUTO_INCREMENT PRIMARY KEY,
                            full_name VARCHAR(255) NOT NULL,
                            email VARCHAR(255) UNIQUE NOT NULL,
                            phone VARCHAR(20) NOT NULL
                        );
                    ";

                    string createSeatsTable = @"
                        CREATE TABLE IF NOT EXISTS seats (
                            bus_id INT NOT NULL,
                            seatNo INT NOT NULL,
                            Status ENUM('Available', 'Booked') DEFAULT 'Available',
                            PRIMARY KEY (bus_id, seatNo),
                            FOREIGN KEY (bus_id) REFERENCES bus(bus_id) ON DELETE CASCADE
                        );
                    ";

                    string createBookingsTable = @"
                        CREATE TABLE IF NOT EXISTS bookings (
                            booking_id INT AUTO_INCREMENT PRIMARY KEY,
                            passenger_id INT NOT NULL,
                            seatNo INT NOT NULL,
                            bus_id INT NOT NULL,
                            booking_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                            FOREIGN KEY (passenger_id) REFERENCES passengers(passenger_id) ON DELETE CASCADE,
                            FOREIGN KEY (bus_id, seatNo) REFERENCES seats(bus_id, seatNo) ON DELETE CASCADE
                        );
                    ";

                    string createUserpassTable = @"
                        CREATE TABLE IF NOT EXISTS userpass (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            Username VARCHAR(255) UNIQUE NOT NULL,
                            PasswordHash VARCHAR(255) NOT NULL,
                            Role ENUM('Admin', 'User') NOT NULL
                        );
                    ";

                    using (MySqlCommand cmd = new MySqlCommand(createDatabase, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    using (MySqlCommand cmd = new MySqlCommand(createBusTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    using (MySqlCommand cmd = new MySqlCommand(createRoutingTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    using (MySqlCommand cmd = new MySqlCommand(createPassengersTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    using (MySqlCommand cmd = new MySqlCommand(createSeatsTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    using (MySqlCommand cmd = new MySqlCommand(createBookingsTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    using (MySqlCommand cmd = new MySqlCommand(createUserpassTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating database/tables: " + ex.Message);
            }
        }
    }
}
```

The following tables are defined in the `CreateDatabaseAndTables` method:

1. **bus**
   - `bus_id INT AUTO_INCREMENT PRIMARY KEY`
   - `bus_name VARCHAR(255) NOT NULL`
   - `total_seats INT NOT NULL`
   - `bus_type ENUM('AC', 'Non-AC', 'Sleeper', 'Luxury', 'Electric') NOT NULL`
   - `bus_number VARCHAR(50) UNIQUE NOT NULL`

2. **routing**
   - `route_id INT AUTO_INCREMENT PRIMARY KEY`
   - `bus_id INT NOT NULL`
   - `departure_location VARCHAR(255) NOT NULL`
   - `arrival_location VARCHAR(255) NOT NULL`
   - `departure_time TIME NOT NULL`
   - `arrival_time TIME NOT NULL`
   - `ticket_price DECIMAL(10,2) NOT NULL`
   - `through_location TEXT`
   - `FOREIGN KEY (bus_id) REFERENCES bus(bus_id) ON DELETE CASCADE`

3. **passengers**
   - `passenger_id INT AUTO_INCREMENT PRIMARY KEY`
   - `full_name VARCHAR(255) NOT NULL`
   - `email VARCHAR(255) UNIQUE NOT NULL`
   - `phone VARCHAR(20) NOT NULL`

4. **seats**
   - `bus_id INT NOT NULL`
   - `seatNo INT NOT NULL`
   - `Status ENUM('Available', 'Booked') DEFAULT 'Available'`
   - `PRIMARY KEY (bus_id, seatNo)`
   - `FOREIGN KEY (bus_id) REFERENCES bus(bus_id) ON DELETE CASCADE`

5. **bookings**
   - `booking_id INT AUTO_INCREMENT PRIMARY KEY`
   - `passenger_id INT NOT NULL`
   - `seatNo INT NOT NULL`
   - `bus_id INT NOT NULL`
   - `booking_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP`
   - `FOREIGN KEY (passenger_id) REFERENCES passengers(passenger_id) ON DELETE CASCADE`
   - `FOREIGN KEY (bus_id, seatNo) REFERENCES seats(bus_id, seatNo) ON DELETE CASCADE`

6. **userpass**
   - `id INT AUTO_INCREMENT PRIMARY KEY`
   - `Username VARCHAR(255) UNIQUE NOT NULL`
   - `PasswordHash VARCHAR(255) NOT NULL`
   - `Role ENUM('Admin', 'User') NOT NULL`
