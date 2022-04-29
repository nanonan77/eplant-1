using Microsoft.Exchange.WebServices.Data;
using Microsoft.Extensions.Options;
using Sketec.Core.Interfaces;
using Sketec.Core.Resources.Email;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sketec.Infrastructure.Services
{
    public class ExchangeEmailService : IEmailService
    {
        EmailSettings setting;
        ExchangeService exchangeService;
        public ExchangeEmailService(EmailSettings emailSettings)
        {
            setting = emailSettings;
            exchangeService = new ExchangeService();
            exchangeService.Credentials = new WebCredentials(setting.Email, setting.Password);
            exchangeService.Url = new System.Uri("https://outlook.office365.com/EWS/Exchange.asmx");
        }

        public System.Threading.Tasks.Task SendEmailAsync(SendEmailRequest sendEmailRequest)
        {
            try
            {
                var msg = new EmailMessage(exchangeService)
                {
                    Subject = sendEmailRequest.Subject,
                    Body = new MessageBody(BodyType.HTML, sendEmailRequest.Content),
                    From = new EmailAddress(setting.Email)
                };

                if (setting.Environment != "prod")
                {
                    msg.Subject = $"[Test] {msg.Subject}";
                    msg.ToRecipients.Add("parinya.champ@gmail.com");
                    msg.ToRecipients.Add("pcchai456@gmail.com");
                    msg.ToRecipients.Add("yuttana.mac@gmail.com");
                    msg.ToRecipients.Add("veeraya.nan@gmail.com");
                    msg.ToRecipients.Add("atthawadee@sketecthailand.com");
                }
                else
                {
                    if (sendEmailRequest.EmailsTo != null)
                    {
                        foreach (var mail in sendEmailRequest.EmailsTo)
                        {
                            msg.ToRecipients.Add(mail);
                        }
                    }

                    if (sendEmailRequest.EmailsCC != null)
                    {
                        foreach (var mail in sendEmailRequest.EmailsCC)
                        {
                            msg.CcRecipients.Add(mail);
                        }
                    }
                }

                if (sendEmailRequest.Attachments != null)
                {
                    foreach (var item in sendEmailRequest.Attachments)
                    {
                        msg.Attachments.AddFileAttachment(item.Name, item.Data);
                    }
                }

                msg.Send();
            }
            catch (Exception ex)
            {

            }

            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
