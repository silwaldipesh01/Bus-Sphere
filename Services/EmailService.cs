using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bus_Sphere.Models;

namespace Bus_Sphere.Services
{
    /// <summary>
    /// Service for sending emails with attachments
    /// </summary>
    public class EmailService
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _senderEmail;
        private readonly string _senderPassword;

        /// <summary>
        /// Initializes a new instance of the EmailService
        /// WARNING: Default credentials are for demonstration purposes only.
        /// In production, credentials should be loaded from:
        /// - Environment variables
        /// - Configuration files (not in source control)
        /// - Azure Key Vault or similar secret management systems
        /// </summary>
        /// <param name="smtpHost">SMTP server host (default: smtp.gmail.com)</param>
        /// <param name="smtpPort">SMTP server port (default: 587)</param>
        /// <param name="senderEmail">Sender email address</param>
        /// <param name="senderPassword">Sender email password or app-specific password</param>
        public EmailService(
            string smtpHost = "smtp.gmail.com",
            int smtpPort = 587,
            string senderEmail = "esp32alertdipesh@gmail.com",
            string senderPassword = "nouv lwqe ohkg menh")
        {
            _smtpHost = smtpHost;
            _smtpPort = smtpPort;
            _senderEmail = senderEmail;
            _senderPassword = senderPassword;
        }

        /// <summary>
        /// Sends an email with ticket attachment to a passenger
        /// </summary>
        /// <param name="passengerDetail">Passenger details</param>
        /// <param name="ticketPath">Path to the ticket PDF file</param>
        /// <returns>Task representing the asynchronous operation</returns>
        public async Task SendTicketEmailAsync(PassengerDetail passengerDetail, string ticketPath)
        {
            if (passengerDetail == null)
            {
                throw new ArgumentNullException(nameof(passengerDetail));
            }

            if (string.IsNullOrWhiteSpace(ticketPath) || !File.Exists(ticketPath))
            {
                throw new FileNotFoundException("Ticket file not found", ticketPath);
            }

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_senderEmail);
            mail.To.Add(passengerDetail.Email);
            mail.Subject = "Ticket Confirmation for " + passengerDetail.Name;
            mail.Body = "Dear " + passengerDetail.Name + ",\n\nPlease find attached your ticket.\n\nBest regards,\nBus Sphere";

            Attachment attachment = new Attachment(ticketPath);
            mail.Attachments.Add(attachment);

            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = _smtpHost;
                smtpClient.Port = _smtpPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_senderEmail, _senderPassword);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                await smtpClient.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Sends a generic email
        /// </summary>
        /// <param name="recipientEmail">Recipient email address</param>
        /// <param name="subject">Email subject</param>
        /// <param name="body">Email body</param>
        /// <param name="attachmentPath">Optional attachment path</param>
        /// <returns>Task representing the asynchronous operation</returns>
        public async Task SendEmailAsync(string recipientEmail, string subject, string body, string attachmentPath = null)
        {
            if (string.IsNullOrWhiteSpace(recipientEmail))
            {
                throw new ArgumentException("Recipient email cannot be null or empty", nameof(recipientEmail));
            }

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_senderEmail);
            mail.To.Add(recipientEmail);
            mail.Subject = subject;
            mail.Body = body;

            if (!string.IsNullOrWhiteSpace(attachmentPath) && File.Exists(attachmentPath))
            {
                Attachment attachment = new Attachment(attachmentPath);
                mail.Attachments.Add(attachment);
            }

            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = _smtpHost;
                smtpClient.Port = _smtpPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_senderEmail, _senderPassword);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                await smtpClient.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message);
                throw;
            }
        }
    }
}
