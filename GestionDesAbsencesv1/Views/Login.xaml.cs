using GestionDesAbsencesv1.ViewModels;
using System;
using System.Collections.Generic;
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

namespace GestionDesAbsencesv1.Views
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        readonly LoginViewModel db = Actions.ViewModel.Login;
        public Login()
        {
            this.DataContext = db;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MaterialDesignThemes.Wpf.ButtonProgressAssist.SetIsIndicatorVisible(ButtonLogin, true);

            if (ButtonLogin.Content.ToString() == "VALIDER")
            {
                db.Login();
            }
            else
            {
                db.VerifyLoginIdExist(this);
            }

            MaterialDesignThemes.Wpf.ButtonProgressAssist.SetIsIndicatorVisible(ButtonLogin, false);
        }

        private void PasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //db.Password = PasswordTextBox.Password;
        }
    }
}
