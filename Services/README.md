# Bus Sphere - Services Documentation

## Overview

This document describes the Email and PDF generation services available in the Bus Sphere application.

## EmailService

The `EmailService` class provides functionality for sending emails with attachments. It is located in the `Bus_Sphere.Services` namespace.

### Features

- Send ticket confirmation emails with PDF attachments
- Send generic emails with optional attachments
- SMTP configuration support
- Async/await support for non-blocking operations

### Usage

#### Basic Usage

```csharp
using Bus_Sphere.Services;
using Bus_Sphere.Models;

// Create an instance of EmailService
var emailService = new EmailService();

// Send a ticket email
await emailService.SendTicketEmailAsync(passengerDetail, ticketPath);
```

#### Custom SMTP Configuration

```csharp
var emailService = new EmailService(
    smtpHost: "smtp.gmail.com",
    smtpPort: 587,
    senderEmail: "your-email@gmail.com",
    senderPassword: "your-app-password"
);
```

#### Sending Generic Emails

```csharp
await emailService.SendEmailAsync(
    recipientEmail: "customer@example.com",
    subject: "Your Subject",
    body: "Your email body",
    attachmentPath: "/path/to/attachment.pdf"  // Optional
);
```

### Methods

#### SendTicketEmailAsync

Sends a ticket confirmation email to a passenger with a PDF attachment.

**Parameters:**
- `passengerDetail` (PassengerDetail): Passenger information
- `ticketPath` (string): Path to the ticket PDF file

**Returns:** Task representing the asynchronous operation

**Throws:** 
- `ArgumentNullException`: If passengerDetail is null
- `FileNotFoundException`: If ticket file doesn't exist

#### SendEmailAsync

Sends a generic email with optional attachment.

**Parameters:**
- `recipientEmail` (string): Recipient's email address
- `subject` (string): Email subject
- `body` (string): Email body text
- `attachmentPath` (string, optional): Path to attachment file

**Returns:** Task representing the asynchronous operation

**Throws:**
- `ArgumentException`: If recipientEmail is null or empty

### Configuration Notes

For Gmail SMTP:
- You need to enable "Less secure app access" or use an App Password
- Default port is 587 with TLS/SSL enabled
- Make sure to use your actual Gmail credentials

## PdfService

The `PdfService` class provides functionality for generating PDF documents, specifically bus ticket PDFs. It is located in the `Bus_Sphere.Services` namespace.

### Features

- Generate formatted bus tickets as PDF documents
- Customizable logo and branding
- Professional table-based layout
- Support for custom PDF generation
- Automatic directory creation

### Usage

#### Basic Usage

```csharp
using Bus_Sphere.Services;
using Bus_Sphere.Models;

// Create an instance of PdfService
var pdfService = new PdfService();

// Generate a ticket PDF
string ticketPath = pdfService.CreateTicket(passengerDetail);
```

#### Custom Configuration

```csharp
var pdfService = new PdfService(
    outputDirectory: @"C:\CustomPath\Tickets",
    logoPath: @"C:\CustomPath\logo.png"
);
```

#### Creating Custom PDFs

```csharp
string[] content = new string[] {
    "Line 1 of content",
    "Line 2 of content",
    "Line 3 of content"
};

string pdfPath = pdfService.CreatePdf("custom-document.pdf", content);
```

### Methods

#### CreateTicket

Creates a formatted bus ticket PDF for a passenger.

**Parameters:**
- `passengerDetail` (PassengerDetail): Complete passenger and journey information

**Returns:** String path to the created PDF file

**Throws:**
- `ArgumentNullException`: If passengerDetail is null

**PDF Contents:**
- Passenger information (name, email, phone, address)
- Bus information (number, name, type)
- Seat information (number of seats, seat numbers)
- Journey details (departure/arrival times and locations)
- Pricing information (ticket price, total cost)

#### CreatePdf

Creates a custom PDF document with provided content.

**Parameters:**
- `fileName` (string): Name of the output PDF file
- `content` (string[]): Array of paragraphs to include in the PDF

**Returns:** String path to the created PDF file

### Directory Structure

By default, PDFs are saved to:
- `{ApplicationDirectory}/TicketStorage/`

The logo is expected at:
- `{ApplicationDirectory}/Images/BusLogoNewest_enhanced.png`

Both paths can be customized in the constructor.

### PDF Customization

The `PdfService.PdfPageEvents` class handles page headers and branding:
- Automatically adds logo to each page
- Adds "Bus Sphere" header text
- Handles cases where logo file is missing

## Integration Example

Here's a complete example of using both services together:

```csharp
using Bus_Sphere.Services;
using Bus_Sphere.Models;

public class BookingHandler
{
    private readonly EmailService _emailService;
    private readonly PdfService _pdfService;

    public BookingHandler()
    {
        _emailService = new EmailService();
        _pdfService = new PdfService();
    }

    public async Task ProcessBookingAsync(PassengerDetail passengerDetail)
    {
        try
        {
            // Generate the ticket PDF
            string ticketPath = _pdfService.CreateTicket(passengerDetail);
            
            // Send the ticket via email
            await _emailService.SendTicketEmailAsync(passengerDetail, ticketPath);
            
            MessageBox.Show("Booking confirmed and ticket sent!");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error processing booking: " + ex.Message);
        }
    }
}
```

## Error Handling

Both services include comprehensive error handling:

1. **EmailService**
   - Validates email addresses
   - Checks for file existence before attaching
   - Shows user-friendly error messages
   - Throws exceptions for programmatic handling

2. **PdfService**
   - Validates passenger data
   - Creates directories automatically
   - Handles missing logo gracefully
   - Shows user-friendly error messages
   - Throws exceptions for programmatic handling

## Dependencies

Both services require the following NuGet packages:
- `iTextSharp` (v5.5.13.4 or compatible) - for PDF generation
- Built-in .NET libraries for email (System.Net.Mail)

## Security Considerations

⚠️ **Important Security Notes:**

1. **Email Credentials**: Never hardcode email credentials in production code. Use:
   - Environment variables
   - Configuration files (excluded from source control)
   - Azure Key Vault or similar secret management

2. **Email Passwords**: For Gmail, use App Passwords instead of your actual password:
   - Go to Google Account settings
   - Enable 2-factor authentication
   - Generate an App Password
   - Use the App Password in the EmailService

3. **File Paths**: Be cautious with file paths to prevent path traversal attacks

4. **Attachment Size**: Consider implementing file size limits for attachments

## Testing

To test the services:

1. **EmailService Testing**:
   - Use a test email account
   - Verify email delivery
   - Check attachment integrity
   - Test error handling with invalid inputs

2. **PdfService Testing**:
   - Generate sample tickets
   - Verify PDF content and formatting
   - Test with missing logo
   - Validate file creation and permissions

## Future Enhancements

Potential improvements for these services:

1. **EmailService**
   - Template-based email bodies (HTML)
   - Bulk email sending
   - Email queuing for better performance
   - Retry logic for failed sends

2. **PdfService**
   - QR code generation for tickets
   - Barcode support
   - Multiple ticket templates
   - Digital signatures
   - PDF encryption

## Support

For issues or questions about these services, please contact the development team or create an issue in the repository.
