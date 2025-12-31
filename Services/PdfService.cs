using System;
using System.IO;
using System.Windows.Forms;
using Bus_Sphere.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Rectangle = iTextSharp.text.Rectangle;
using Font = iTextSharp.text.Font;

namespace Bus_Sphere.Services
{
    /// <summary>
    /// Service for generating PDF tickets
    /// </summary>
    public class PdfService
    {
        private readonly string _outputDirectory;
        private readonly string _logoPath;

        /// <summary>
        /// Initializes a new instance of the PdfService
        /// </summary>
        /// <param name="outputDirectory">Directory where PDFs will be saved (default: TicketStorage)</param>
        /// <param name="logoPath">Path to the logo image</param>
        public PdfService(string outputDirectory = null, string logoPath = null)
        {
            // Use a more portable default path
            _outputDirectory = outputDirectory ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TicketStorage");
            
            // Create directory if it doesn't exist
            if (!Directory.Exists(_outputDirectory))
            {
                Directory.CreateDirectory(_outputDirectory);
            }

            // Set logo path if provided, otherwise use default
            _logoPath = logoPath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "BusLogoNewest_enhanced.png");
        }

        /// <summary>
        /// Creates a PDF ticket for a passenger
        /// </summary>
        /// <param name="passengerDetail">Passenger details</param>
        /// <returns>Path to the created PDF file</returns>
        public string CreateTicket(PassengerDetail passengerDetail)
        {
            if (passengerDetail == null)
            {
                throw new ArgumentNullException(nameof(passengerDetail));
            }

            string fileName = $"ticket_{passengerDetail.Id}_{passengerDetail.Name.Replace(" ", "_")}.pdf";
            string outputPath = Path.Combine(_outputDirectory, fileName);

            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(outputPath, FileMode.Create));
            writer.PageEvent = new PdfPageEvents(_logoPath);

            try
            {
                doc.Open();
                doc.Add(new Paragraph("\n\n\n\n\n\n"));

                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
                Font regularFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                doc.Add(new Paragraph("Bus Sphere Ticket", titleFont) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph(" "));

                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;
                table.HorizontalAlignment = Element.ALIGN_CENTER;
                table.SetWidths(new float[] { 1, 2 });

                // Add passenger details
                AddTableRow(table, "Passenger Name:", passengerDetail.Name, regularFont);
                AddTableRow(table, "Passenger Email:", passengerDetail.Email, regularFont);
                AddTableRow(table, "Phone Number:", passengerDetail.PhoneNumber, regularFont);
                AddTableRow(table, "Address:", passengerDetail.Address, regularFont);

                // Add bus details
                AddTableRow(table, "Bus Number:", passengerDetail.BusNo, regularFont);
                AddTableRow(table, "Bus Name:", passengerDetail.BusName, regularFont);
                AddTableRow(table, "Bus Type:", passengerDetail.BusType, regularFont);

                // Add seat details
                AddTableRow(table, "No of Seats", passengerDetail.Seats.Length.ToString(), regularFont);
                AddTableRow(table, "Seat Numbers:", string.Join(", ", passengerDetail.Seats), regularFont);

                // Add journey details
                AddTableRow(table, "Departure Date:", passengerDetail.Date, regularFont);
                AddTableRow(table, "Departure Time:", passengerDetail.DepartureTime, regularFont);
                AddTableRow(table, "Departure Location:", passengerDetail.Source, regularFont);
                AddTableRow(table, "Arrival Time:", passengerDetail.ArrivalTime, regularFont);
                AddTableRow(table, "Arrival Location:", passengerDetail.Destination, regularFont);

                // Add pricing details
                string ticketPrice = Convert.ToInt32(passengerDetail.TicketPrice).ToString();
                AddTableRow(table, "Ticket Price:", "Rs : " + ticketPrice, regularFont);

                string total = (Convert.ToInt32(passengerDetail.TicketPrice * passengerDetail.Seats.Length)).ToString();
                AddTableRow(table, "Total Price : ", "Rs : " + total, regularFont);

                doc.Add(table);
                doc.Add(new Paragraph("\n\n"));
                doc.Add(new Paragraph("Thank you for choosing Bus Sphere. We wish you a pleasant journey!", regularFont) { Alignment = Element.ALIGN_CENTER });

                doc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating ticket: " + ex.Message);
                throw;
            }

            return outputPath;
        }

        /// <summary>
        /// Helper method to add a row to the PDF table
        /// </summary>
        private void AddTableRow(PdfPTable table, string label, string value, Font font)
        {
            table.AddCell(new PdfPCell(new Phrase(label, font)) { Border = Rectangle.NO_BORDER });
            table.AddCell(new PdfPCell(new Phrase(value, font)) { Border = Rectangle.NO_BORDER });
        }

        /// <summary>
        /// Creates a PDF with custom content
        /// </summary>
        /// <param name="fileName">Output file name</param>
        /// <param name="content">PDF content as paragraphs</param>
        /// <returns>Path to the created PDF file</returns>
        public string CreatePdf(string fileName, string[] content)
        {
            string outputPath = Path.Combine(_outputDirectory, fileName);

            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(outputPath, FileMode.Create));
            writer.PageEvent = new PdfPageEvents(_logoPath);

            try
            {
                doc.Open();
                Font regularFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                foreach (string paragraph in content)
                {
                    doc.Add(new Paragraph(paragraph, regularFont));
                    doc.Add(new Paragraph(" "));
                }

                doc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating PDF: " + ex.Message);
                throw;
            }

            return outputPath;
        }

        /// <summary>
        /// PDF page event handler for adding headers with logo
        /// </summary>
        public class PdfPageEvents : PdfPageEventHelper
        {
            private readonly string _logoPath;

            public PdfPageEvents(string logoPath)
            {
                _logoPath = logoPath;
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                PdfPTable headerTable = new PdfPTable(1);
                headerTable.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                headerTable.HorizontalAlignment = Element.ALIGN_CENTER;

                // Add logo if it exists
                if (!string.IsNullOrWhiteSpace(_logoPath) && File.Exists(_logoPath))
                {
                    try
                    {
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(_logoPath);
                        image.ScaleToFit(474f, 87f);
                        PdfPCell imageCell = new PdfPCell(image);
                        imageCell.Border = Rectangle.NO_BORDER;
                        imageCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerTable.AddCell(imageCell);
                    }
                    catch
                    {
                        // If logo fails to load, just add the text header
                    }
                }

                Font font = FontFactory.GetFont(FontFactory.HELVETICA, 44, BaseColor.BLACK);
                PdfPCell headerCell = new PdfPCell(new Phrase("Bus Sphere", font));
                headerCell.Border = Rectangle.NO_BORDER;
                headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTable.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 15, writer.DirectContent);
            }
        }
    }
}
