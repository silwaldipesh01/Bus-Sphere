
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//namespace for email   
using System.Net;
using System.Net.Mail;
//namespace for pdf generation
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Bus_Sphere.Models
{
    public class EmailSender
    {
        private readonly string smtpHost = "smtp.gmail.com";
        private readonly int smtpPort = 587;
        private readonly string smtpUser = "esp32alertdipesh@gmail.com";
        private readonly string smtpPass = "****************"; // Change this to your actual password

        public void SendEmail(string recipientEmail, string subject, string body, string attachmentPath)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(smtpUser);
            mail.To.Add(recipientEmail);
            mail.Subject = subject;
            mail.Body = body;

            if (File.Exists(attachmentPath))
            {
                Attachment attachment = new Attachment(attachmentPath);
                mail.Attachments.Add(attachment);
            }
            else
            {
                Console.WriteLine("Attachment file not found: " + attachmentPath);
                return;
            }

            try
            {
                SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(smtpUser, smtpPass);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
                Console.WriteLine("Email sent successfully to " + recipientEmail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void CreateTicket(string outputPath)
        {
            Document doc = new Document();

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(outputPath, FileMode.Create));
                writer.PageEvent = new PdfPageEvents(); // Assigning custom page event handler

                doc.Open();
                doc.Add(new Paragraph("\n\n\n\n"));

                doc.Add(new Paragraph("This is Topic "));
                doc.Add(new Paragraph("Hi\n\n"));

                PdfPTable table = new PdfPTable(3);
                table.AddCell("1"); table.AddCell("2"); table.AddCell("3");
                table.AddCell("4"); table.AddCell("5"); table.AddCell("6");
                table.AddCell("7"); table.AddCell("8"); table.AddCell("9");

                doc.Add(table);

                doc.Close();
                Console.WriteLine("PDF created successfully at " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public class PdfPageEvents : PdfPageEventHelper
        {
            //public override void OnEndPage(PdfWriter writer, Document document)
            //{
            //    PdfPTable headerTable = new PdfPTable(1); // constructor with 1 column  
            //    headerTable.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;// set the width of the table to be the same as the document  

            //    headerTable.HorizontalAlignment = Element.ALIGN_CENTER;
            //    string imagePath = "C:\\Users\\silwa\\source\\repos\\Bus Sphere\\Images\\busLogo.png";
            //    System.Drawing.Image image = Image.GetInstance(imagePath);
            //    image.ScaleToFit(474f, 87f); // Scale image to fit within specified dimensions
            //    PdfPCell imageCell = new PdfPCell(image);
            //    imageCell.Border = Rectangle.NO_BORDER;
            //    imageCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //    headerTable.AddCell(imageCell);


            //    // Add text to the header
            //    Font font = FontFactory.GetFont(FontFactory.HELVETICA, 44, BaseColor.BLACK);
            //    PdfPCell headerCell = new PdfPCell(new Phrase("Bus Sphere", font));
            //    //headerCell.Border = Rectangle.NO_BORDER;
            //    headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //    headerTable.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 15, writer.DirectContent);

            //}
        }
    }
}
