using GestionDesAbsencesv1.Models;
using GestionDesAbsencesv1.Service;
using GestionDesAbsencesv1.Views;
using GestionDesAbsencesv1.Views.component;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GestionDesAbsencesv1.ViewModels
{
    class LoginViewModel : ObservableObject
    {
        string _loginId = Db.Bdd.Users.Find(1).Mail;
        string _password = "1234";
        User _user = Db.Bdd.Users.Find(1);

        public string LoginId { get => _loginId; set => OnPropertyChanged(ref _loginId, value); }
        public string Password { get => _password; set => OnPropertyChanged(ref _password, value); }
        public string FullName { get => $"{_user.FirstName + " " + _user.LastName.ToUpper()}"; }
        public User UserConnected { get => _user; }

        /// <summary>
        ///  Configure le code pin à inserer dans le mail pour envoi
        ///  Il update le password du user en param
        /// </summary>
        /// <param name="user"></param>
        static void ParamMailLogin(User user)
        {
            Random rand = new();
            int codePin = rand.Next(1000, 9999);
            user.Password = Passwords.Encrypt(codePin.ToString());
            Actions.ViewModel.User.Update();
        }

        public void Logout()
        {
            _loginId = null;
            _password = null;
            _user = null;

            MainWindow.Frame.Content = new Login();
            MainWindow.Frame.VerticalAlignment = VerticalAlignment.Center;
        }

        /// <summary>
        /// Permet de vérifier si un utilisateur exist avec son mail
        /// il set _user si l'utilisateur exist
        /// grace a la methode MailLogin il envoie un nouveau code pin à l'utilisateur
        /// </summary>
        public void VerifyLoginIdExist(Login ViewLogin)
        {
            var user = Actions.ViewModel.User.ListUsers.Where(c => c.Mail == _loginId);

            if(user.Count() != 1 )
            {
                MessageBox.Show(
                    "Aucun utilisateur est enregistré avec ce mail, merci de prendre contact avec admin@nothere.re", 
                    "Erreur Login", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error );
                return;
            }

            //MailLogin(user.First());
            //_user = user.First();

            DisplayConfigForPassword(ViewLogin);
        }

        /// <summary>
        ///  Modifie les elements de la view Login pour saisir le code pin
        /// </summary>
        /// <param name="ViewLogin"></param>
        static void DisplayConfigForPassword(Login ViewLogin)
        {
            ViewLogin.PasswordTextBox.Visibility = Visibility.Visible;
            ViewLogin.idLoginText.IsEnabled = false;
            ViewLogin.labelPassword.Visibility = Visibility.Visible;
            ViewLogin.ButtonLogin.Content = "VALIDER";
        }

        /// <summary>
        /// Grace aux informations du user il configure un mail et l'envoie à un utilisateur
        /// </summary>
        /// <param name="user"></param>
        static void MailLogin(User user)
        {
            ParamMailLogin(user);

            string message = $@"
                <html>
                    <body>
                        <p>Bonjour {user.FirstName} {user.LastName},</p>
                        <p>Merci pour votre demande, nous avons le plaisir de vous partager 
                           votre code pin pour accéder à votre application : <p>
                        <p> <strong> {Passwords.Decrypt(user.Password)} </strong> </p>
                        <p> Pour toutes questions techniques, merci de contacter 
                            l'administrateur : admin@nothere.re </p>
                        <p> Bien cordialement, </p>
                        <p>L'équipe de Not-Here</p>
                    <body>
                </html> ";

            Mail mail = new("noreply@nothere.re", user.Mail, "Votre login de connexion", message);
            MailSetting newMail = new(mail);

            newMail.SendMail();
        }

        /// <summary>
        /// permet le login d'un user
        /// affiche la vue en fonction du role du user
        /// verifie la propriété _user
        /// </summary>
        public void Login()
        {
            if(!VerifyUser())
            {
                MessageBox.Show(
                "Merci de vérifier l'utilisateur pour le login",
                "Erreur Login",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
                return;
            }
            
            if(!VerifyPassword())
            {
                MessageBox.Show(
                "Merci de vérifier votre code pin",
                "Erreur Login",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
                return;
            }

            NextViewAfterLogin();
        }

        /// <summary>
        /// verifie la propriété _password
        /// return true or false
        /// </summary>
        /// <returns>bool</returns>
        bool VerifyPassword()
        {
            if(_password.Length != 4)
            {
                return false;
            }
            else if(!IsNumber())
            {
                return false;
            }
            else if(_password != "1234")//Passwords.Decrypt(_user.Password))
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// verifie que password est bien un int pour composer le code pin
        /// return true or false
        /// </summary>
        /// <returns>bool</returns>
        bool IsNumber()
        {
            try
            {
                int nb = Int32.Parse(_password);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// Permet de mettre a jour la vue aprés un sucess login 
        /// </summary>
        void NextViewAfterLogin()
        {
            switch (_user.Role.Label.ToLower())
            {
                case "étudiant":
                    Actions.ViewModel.Student.UserConnected = _user;
                    MainWindow.Frame.Content = new LayoutHome();
                    LayoutHome.BtnList.ItemsSource = ButtonsViewModel.ListButtonsHomeStudent;
                    LayoutHome.HomeFrame.Content = new HomeFrameStudent();
                    break;
                case "formateur":
                    MainWindow.Frame.Content = new LayoutHome();
                    break;
                case "secrétaire":
                    MainWindow.Frame.Content = new LayoutHome();
                    break;
                case "admin":
                    MainWindow.Frame.Content = new LayoutHome();
                    break;
                default:
                    MessageBox.Show(
                    "Une erreur est survenu avec votre compte, merci de contacter l'admin",
                    "Erreur Login",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                    break;
            }
            
            MainWindow.Frame.VerticalAlignment = VerticalAlignment.Top;
        }

        /// <summary>
        /// verifie que l'objet user est instancié, test le UserID
        /// return true or false
        /// </summary>
        /// <returns>Bool</returns>
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
