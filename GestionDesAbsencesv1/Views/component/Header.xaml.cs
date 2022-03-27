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

namespace GestionDesAbsencesv1.Views.component
{
    /// <summary>
    /// Logique d'interaction pour Header.xaml
    /// </summary>
    public partial class Header : Page
    {
        readonly LoginViewModel db = Actions.ViewModel.Login;
        public Header()
        {
            this.DataContext = db;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Actions.ViewModel.Login.Logout();
        }
    }
}
