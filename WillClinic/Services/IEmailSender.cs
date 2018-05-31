using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillClinic.Models;

namespace WillClinic.Services
{
    /// <summary>
    /// Service responsible for sending emails for users for verification, notifications, and administrative communications
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends an email to the specified recipient with the provided subject, HTML body content, and plaintext body content
        /// </summary>
        /// <param name="recipientAddress">The email address for the recipient of the email</param>
        /// <param name="subject">The subject line text for the email</param>
        /// <param name="htmlContent">The HTML body content if the recipicient has HTML email support</param>
        /// <param name="plainText">The plaintext body content if the recipient does not have HTML email support</param>
        /// <returns>True on a successful response from SendGrid; otherwise, false</returns>
        Task<bool> SendEmailAsync(string recipientAddress, string subject, string htmlContent, string plainText);
    }
}
