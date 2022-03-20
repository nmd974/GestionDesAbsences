using GestionDesAbsencesv1.Models;
using GestionDesAbsencesv1.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionDesAbsencesv1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly DataContextViewModel db = Actions.ViewModel;
        public MainWindow()
        {
            this.DataContext = Actions.ViewModel.Login;
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MaterialDesignThemes.Wpf.ButtonProgressAssist.SetIsIndicatorVisible(ButtonLogin, true);

            if (ButtonLogin.Content.ToString() == "VALIDER")
            {
                Login();
            }
            else
            {
                ProcessLoginEmail();
            }

            MaterialDesignThemes.Wpf.ButtonProgressAssist.SetIsIndicatorVisible(ButtonLogin, false);
        }


        void ProcessLoginEmail()
        {
            if (db.Login.VerifyLoginIdExist(idLoginText.Text.ToLower().Trim()))
            {
                PasswordTextBox.Visibility = Visibility.Visible;
                idLoginText.IsEnabled = false;
                labelPassword.Visibility = Visibility.Visible;
                ButtonLogin.Content = "VALIDER";
            }
            else
            {
                MessageBox.Show(
                    "Merci de vérifier votre identifiant ou de contacteur l'admin par mail admin@nothere.re"
                );
            }
        }
        void Login()
        {
            if(PasswordTextBox.Password.Length < 4)
            {
                MessageBox.Show(
                    "Merci de vérifier le nombre charatère de votre code");
                return;
            } else if (!IsValid(PasswordTextBox.Password))
            {
                MessageBox.Show(
                   "Votre saisie n'est pas un code pin");
                return;
            } else if (!db.Login.Login(PasswordTextBox.Password.Trim()))
            {
                MessageBox.Show(
                "Votre code pin est invalide");
                return;
            }

            MessageBox.Show(
                "Félicitation, login réussi");
        }
        static bool IsValid(string number)
        {
            try
            {
                int nb = Int32.Parse(number);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}
