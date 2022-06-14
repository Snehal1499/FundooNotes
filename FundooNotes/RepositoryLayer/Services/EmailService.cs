﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmailService
    {
        public static void SendEmail(string Email, string token)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("nehu6779@gmail.com", "xtdxmydsfhncedwa");

                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(Email);
                mailMessage.From = new MailAddress("nehu6779@gmail.com");
                mailMessage.Subject = "Password Reset Link";
                mailMessage.Body = $"www.FundooNotes.com/reset-password/{token}";
                client.Send(mailMessage);
            }
        }
    }
}