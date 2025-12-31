using System;
using System.Threading.Tasks;
using Bus_Sphere.Models;
using Bus_Sphere.Services;

namespace Bus_Sphere.Examples
{
    /// <summary>
    /// Example class demonstrating the usage of EmailService and PdfService
    /// This class is for reference only and should not be used in production
    /// </summary>
    public class ServiceUsageExamples
    {
        /// <summary>
        /// Example 1: Basic ticket generation and email sending
        /// </summary>
        public async Task Example1_BasicTicketGeneration()
        {
            // Create sample passenger detail
            var passengerDetail = new PassengerDetail
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890",
                Address = "123 Main St, City",
                Seats = "A1,A2",
                noOfSeats = 2,
                BusNo = "BUS-001",
                BusName = "Express Deluxe",
                BusType = "AC",
                Source = "New York",
                Destination = "Boston",
                Through = "Hartford",
                Date = DateTime.Now.ToString(),
                DepartureTime = "09:00 AM",
                ArrivalTime = "02:00 PM",
                TicketPrice = 50.00m
            };

            // Initialize services
            var pdfService = new PdfService();
            var emailService = new EmailService();

            try
            {
                // Generate PDF ticket
                string ticketPath = pdfService.CreateTicket(passengerDetail);
                Console.WriteLine($"Ticket generated at: {ticketPath}");

                // Send email with ticket
                await emailService.SendTicketEmailAsync(passengerDetail, ticketPath);
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Example 2: Custom SMTP configuration
        /// </summary>
        public async Task Example2_CustomSmtpConfiguration()
        {
            // Create email service with custom configuration
            var emailService = new EmailService(
                smtpHost: "smtp.gmail.com",
                smtpPort: 587,
                senderEmail: "your-custom-email@gmail.com",
                senderPassword: "your-app-password"
            );

            try
            {
                await emailService.SendEmailAsync(
                    recipientEmail: "recipient@example.com",
                    subject: "Test Email",
                    body: "This is a test email from Bus Sphere"
                );
                Console.WriteLine("Custom email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Example 3: Custom PDF generation
        /// </summary>
        public void Example3_CustomPdfGeneration()
        {
            // Create PDF service with custom output directory
            var pdfService = new PdfService(
                outputDirectory: @"C:\CustomTickets",
                logoPath: @"C:\CustomLogo\logo.png"
            );

            string[] content = new string[]
            {
                "Bus Sphere - Travel Receipt",
                "",
                "Thank you for traveling with us!",
                "",
                "Journey Details:",
                "- From: New York",
                "- To: Boston",
                "- Date: " + DateTime.Now.ToShortDateString(),
                "",
                "We hope you had a pleasant journey."
            };

            try
            {
                string pdfPath = pdfService.CreatePdf("receipt.pdf", content);
                Console.WriteLine($"Custom PDF created at: {pdfPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Example 4: Error handling best practices
        /// </summary>
        public async Task Example4_ErrorHandling()
        {
            var pdfService = new PdfService();
            var emailService = new EmailService();

            PassengerDetail passengerDetail = null;

            try
            {
                // This will throw ArgumentNullException
                string ticketPath = pdfService.CreateTicket(passengerDetail);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Passenger detail cannot be null: {ex.Message}");
            }

            try
            {
                // This will throw FileNotFoundException
                await emailService.SendTicketEmailAsync(
                    new PassengerDetail { Email = "test@test.com", Name = "Test" },
                    "non-existent-file.pdf"
                );
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine($"Ticket file not found: {ex.Message}");
            }
        }

        /// <summary>
        /// Example 5: Complete booking workflow
        /// </summary>
        public async Task Example5_CompleteBookingWorkflow()
        {
            var pdfService = new PdfService();
            var emailService = new EmailService();

            // Simulate a booking
            var passengerDetail = new PassengerDetail
            {
                Id = 101,
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                PhoneNumber = "9876543210",
                Address = "456 Park Ave, City",
                Seats = "B5",
                noOfSeats = 1,
                BusNo = "BUS-002",
                BusName = "Comfort Plus",
                BusType = "Non-AC",
                Source = "Chicago",
                Destination = "Detroit",
                Through = "Ann Arbor",
                Date = DateTime.Now.ToString(),
                DepartureTime = "06:00 AM",
                ArrivalTime = "11:00 AM",
                TicketPrice = 35.00m
            };

            try
            {
                Console.WriteLine("Processing booking...");

                // Step 1: Generate ticket
                Console.WriteLine("Generating ticket PDF...");
                string ticketPath = pdfService.CreateTicket(passengerDetail);

                // Step 2: Send confirmation email
                Console.WriteLine("Sending confirmation email...");
                await emailService.SendTicketEmailAsync(passengerDetail, ticketPath);

                // Step 3: Confirm success
                Console.WriteLine("Booking completed successfully!");
                Console.WriteLine($"Ticket saved at: {ticketPath}");
                Console.WriteLine($"Confirmation email sent to: {passengerDetail.Email}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Booking failed: {ex.Message}");
                // In production: Log error, notify user, rollback transaction
            }
        }

        /// <summary>
        /// Example 6: Sending email with generic attachment
        /// </summary>
        public async Task Example6_GenericEmailWithAttachment()
        {
            var emailService = new EmailService();

            try
            {
                await emailService.SendEmailAsync(
                    recipientEmail: "customer@example.com",
                    subject: "Monthly Travel Summary",
                    body: "Dear Customer,\n\nPlease find attached your monthly travel summary.\n\nBest regards,\nBus Sphere Team",
                    attachmentPath: @"C:\Reports\monthly-summary.pdf"
                );
                Console.WriteLine("Email with attachment sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}
