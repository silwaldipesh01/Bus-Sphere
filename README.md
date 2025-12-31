# Bus Sphere

A comprehensive bus ticket booking and management system built with C# and Windows Forms.

## Features

- **Bus Management**: Add, update, and manage bus information
- **Route Management**: Define routes with departure/arrival times and pricing
- **Seat Booking**: Interactive seat selection and booking system
- **Passenger Management**: Track passenger information and booking history
- **Email Notifications**: Automated ticket confirmation emails
- **PDF Ticket Generation**: Professional PDF tickets with branding
- **User Authentication**: Secure login system with role-based access

## New Services

### EmailService
A reusable service for sending emails with attachments. Located in `Services/EmailService.cs`.

**Features:**
- Send ticket confirmation emails with PDF attachments
- Generic email sending with optional attachments
- SMTP configuration support
- Async/await support

**Basic Usage:**
```csharp
var emailService = new EmailService();
await emailService.SendTicketEmailAsync(passengerDetail, ticketPath);
```

See [Services/README.md](Services/README.md) for detailed documentation.

### PdfService
A reusable service for generating PDF documents, specifically bus tickets. Located in `Services/PdfService.cs`.

**Features:**
- Generate formatted bus tickets as PDF documents
- Customizable logo and branding
- Professional table-based layout
- Support for custom PDF generation

**Basic Usage:**
```csharp
var pdfService = new PdfService();
string ticketPath = pdfService.CreateTicket(passengerDetail);
```

See [Services/README.md](Services/README.md) for detailed documentation and examples.

## Database Schema

These are the database designs used in this application


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

## Dependencies

The project requires the following NuGet packages:

- **BCrypt.Net-Next** (4.0.3) - Password hashing
- **iTextSharp** (5.5.13.4) - PDF generation
- **MySql.Data** (9.2.0) - MySQL database connectivity
- **Newtonsoft.Json** (13.0.3) - JSON serialization
- **PDFsharp-MigraDoc** (6.1.1) - Additional PDF utilities
- **System.Text.Json** (9.0.2) - JSON processing

## Setup

1. **Prerequisites:**
   - .NET 8.0 SDK or later
   - Visual Studio 2022 or later
   - XAMPP (for MySQL database)
   - Windows operating system

2. **Database Setup:**
   - Install and start XAMPP
   - The application will automatically create the database and tables on first run
   - Default connection: `localhost:3306`, database: `bussphere`, user: `root`, no password

3. **Email Configuration:**
   - Update SMTP credentials in `Services/EmailService.cs` or pass them to the constructor
   - For Gmail, you need to:
     - Enable 2-factor authentication
     - Generate an App Password
     - Use the App Password in the EmailService

4. **Build and Run:**
   ```bash
   dotnet restore
   dotnet build
   dotnet run
   ```

## Project Structure

```
Bus-Sphere/
├── CustomControls/       # Custom UI controls
├── CustomForm/           # Form controls (Seat Layout, Bus List, etc.)
├── Models/               # Data models (PassengerDetail, Seat)
├── Services/             # Business logic services
│   ├── EmailService.cs   # Email sending functionality
│   ├── PdfService.cs     # PDF generation functionality
│   ├── README.md         # Services documentation
│   └── ServiceUsageExamples.cs  # Usage examples
├── Images/               # Application images and logos
├── TicketStorage/        # Generated PDF tickets (auto-created)
└── Properties/           # Application properties

```

## Usage Examples

See [Services/ServiceUsageExamples.cs](Services/ServiceUsageExamples.cs) for comprehensive examples of using the EmailService and PdfService.

## Contributing

When contributing to this project:
1. Follow the existing code style and conventions
2. Update documentation for any new features
3. Test thoroughly before submitting changes
4. Use the existing services for email and PDF functionality

## License

This project is part of a learning exercise for bus booking system development.
