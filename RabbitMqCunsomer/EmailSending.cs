using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using RFM.Entities.Conrete;
using Business.Interfaces;
using static RFM.Helper.Enums.Enums;
using RFM.Helper.Enums;
using RFM.Data.Entity.ResponseModels;
using Newtonsoft.Json;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RFM.Data.Context;

namespace RabbitMqCunsomer
{
    public class EmailSending
    {
        public async Task sendmail(string request)
        {
            RecommendationRequest mailrequest = JsonConvert.DeserializeObject<RecommendationRequest>(request);
            var appSettingsJson = AppSettingsJson.GetAppSettings();
            EmailConfiguration emailConfig = new EmailConfiguration();

            emailConfig.From = appSettingsJson["EmailConfiguration:From"];
            emailConfig.SmtpServer = appSettingsJson["EmailConfiguration:SmtpServer"];
            emailConfig.Port = int.Parse(appSettingsJson["EmailConfiguration:Port"]);
            emailConfig.UserName = appSettingsJson["EmailConfiguration:Username"];
            emailConfig.Password = appSettingsJson["EmailConfiguration:Password"];

            SmtpClient client = new SmtpClient(emailConfig.SmtpServer, 587);
            NetworkCredential AccountInfo = new NetworkCredential(emailConfig.UserName, emailConfig.Password);
            client.UseDefaultCredentials = false;
            client.Credentials = AccountInfo;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

                try
                {
                    MailMessage msg = new MailMessage();
                    msg.Subject = "Movie Recommendation";
                    msg.From = new MailAddress(emailConfig.From, "Movie Recommendation");
                    msg.To.Add(new MailAddress(mailrequest.Email));
                    msg.Body = "Movies Id = <br>" + mailrequest.MovieId;
                    msg.IsBodyHtml = true;
                    msg.Priority = MailPriority.High;
                    client.Send(msg);
                   
                }
                catch (Exception)
                {

                    throw;
                }

            }

    }

}
