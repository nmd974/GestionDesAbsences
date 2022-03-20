using GestionDesAbsencesv1.Models;
using GestionDesAbsencesv1.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesv1.ViewModels
{
    class LoginViewModel : ObservableObject
    {
        string _loginId;
        string _password;
        User _user;

        public string LoginId { get => _loginId; set => OnPropertyChanged(ref _loginId, value); }
        public string Password { get => _password; set => OnPropertyChanged(ref _password, value); }

        static void ParamMailLogin(User user)
        {
            Random rand = new();
            int codePin = rand.Next(1000, 9999);
            user.Password = codePin.ToString();
            Actions.ViewModel.User.Update();
        }

        public bool VerifyLoginIdExist(string loginId)
        {
            var user = Actions.ViewModel.User.ListUsers.Where(c => c.Mail == loginId);

            if(user.Count() != 1 )
            {
                return false;
            }

            MailLogin(user.First());
            _user = user.First();

            return true;
        }

        static void MailLogin(User user)
        {
            ParamMailLogin(user);
            string message = $@"
                <html>
                    <body>
                       <p>Bonjour {user.FirstName} {user.LastName},</p>
                       <p>Merci pour votre demande, nous avons le plaisir de vous partager votre code pin pour accéder à votre application : <p>
                        <p> <strong> {user.Password} </strong> </p>
                        <p> Pour toutes questions techniques, merci de contacter l'administrateur : admin@nothere.re </p>
                        <p> Bien cordialement, </p>
                        <p>L'équipe de Not-Here</p>
                    <body>
                </html>
            ";
            Mail mail = new("noreply@nothere.re", user.Mail, "Votre login de connexion", message);
            MailSetting newMail = new(mail);

            newMail.SendMail();
        }

        public bool Login(string password)
        {
            if(!VerifyUser())
            {
                return false;
            }
            else if (!(password == _user.Password))
            {
                return false;
            }

            return true;
        }

        bool VerifyUser()
        {
            try
            {
                int id = _user.UserId;

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}
