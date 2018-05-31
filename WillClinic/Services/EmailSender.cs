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
using Microsoft.Extensions.Logging;
using System.Net;

namespace WillClinic.Services
{
    /// <summary>
    /// Service responsible for sending emails for users for verification, notifications, and administrative communications
    /// using the SendGrid API
    /// </summary>
    public class EmailSender : IEmailSender
    {
        public EmailSender (IConfiguration configuration, ILogger<EmailSender> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailSender> _logger;

        /// <summary>
        /// Sends an email to the specified recipient with the provided subject, HTML body content, and plaintext body content
        /// </summary>
        /// <param name="recipientAddress">The email address for the recipient of the email</param>
        /// <param name="subject">The subject line text for the email</param>
        /// <param name="htmlContent">The HTML body content if the recipicient has HTML email support</param>
        /// <param name="plainText">The plaintext body content if the recipient does not have HTML email support</param>
        /// <returns>True on a successful response from SendGrid; otherwise, false</returns>
        public async Task<bool> SendEmailAsync(string recipientAddress, string subject, string htmlContent, string plainText)
        {
            // Compose the email message to be sent to the recipient using the provided arguments
            var message = new SendGridMessage()
            {
                From = new EmailAddress("donotreply@washingtonwillclinic.com", "Washington Veteran Will Clinic"),
                Subject = subject,
                HtmlContent = htmlContent,
                PlainTextContent = plainText
            };
            message.AddTo(recipientAddress, recipientAddress);

            // Instantiate a client for the SendGrid API using the SendGrid API Key from Azure Key Vault
            var client = new SendGridClient(_configuration["SendGridAPIKey"]);

            // Try to send the email out to the recipient
            var response = await client.SendEmailAsync(message);

            // Make sure the e-mail was sent successfully
            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                // Log the successful response from SendGrid and return true to indicate success to the caller
                _logger.LogInformation($"Sent email to {recipientAddress} successfully via SendGrid");
                return true;
            }

            // SendGrid was not able to complete our request. Log the status code and return false to indicate failure to the caller
            _logger.LogError($"Received the following status code from SendGrid when attempting to send an email to {recipientAddress}: {response.StatusCode}");
            return false;
        }
    }
}
