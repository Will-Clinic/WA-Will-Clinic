using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillClinic.Models;

namespace WillClinic.Services
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(string email, string subject, string htmlContent, string plainText);
    }
}
