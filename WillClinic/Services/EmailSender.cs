using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SendGrid;
using SendGrid.Helpers.Mail;
using WillClinic.Data;
using WillClinic.Models;
using WillClinic.Services;
using Microsoft.Extensions.Configuration;
using WillClinic.Pages.Accounts;
using Microsoft.AspNetCore.Http;

namespace WillClinic.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public EmailSender (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        public async Task<bool> SendEmailAsync(string email, string subject, string htmlContent, string plainText)
        {
            var message = new SendGridMessage()
            {
                From = new EmailAddress("donotreply@wavetswillclinic.com/", "Washington Veteran Will Clinic"),
                Subject = subject,
                HtmlContent = htmlContent,
                PlainTextContent = plainText
            };
            message.AddTo(new EmailAddress (email));

            var client = new SendGridClient(_configuration["SendGridAPIKey"]);

            var response = await client.SendEmailAsync(message);


            return (int)response.StatusCode < 400;
        }
    }
}
