using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Mail;
using GestionDesAbsencesv1.Models;
using GestionDesAbsencesv1.ViewModels;

namespace GestionDesAbsencesv1.Service
{
    class MailSetting
    {
        readonly SmtpClient _client = new(Db.Config.getConfig("MailSettings", "Smtp"));
        MailMessage _mail;
        public MailSetting(Mail mail)
        {
           _mail = new MailMessage(mail.MailOf, mail.MailTo, mail.Object, mail.Message);   
            ConfigMail();
        }

        void ConfigMail()
        {
            _client.Port = Int32.Parse(Db.Config.getConfig("MailSettings", "Port"));
            _client.Credentials = new System.Net.NetworkCredential(Db.Config.GetConnection("UserNameMail"), Db.Config.GetConnection("PasswordMail"));
            _client.EnableSsl = true;
            _mail.IsBodyHtml = true;
        }

        public void SendMail()
        {
            _client.Send(_mail);
        }
    }
}
