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
using System.Windows.Shapes;
using GestionDesAbsencesv1.ViewModels;
using GestionDesAbsencesv1.Models;

namespace GestionDesAbsencesv1.Views
{
    /// <summary>
    /// Logique d'interaction pour AddUserView.xaml
    /// </summary>
    public partial class AddUserView : Window
    {
        RoleViewModel ltsrole;

        readonly UserViewModel db = Actions.ViewModel.User;

        public AddUserView()
        {
            this.DataContext = db;
            InitializeComponent();
            ltsrole = new RoleViewModel();
            this.DataContext = ltsrole;
        }

        private void AddNewUser(object sender, EventArgs e)
        {

            db.Store(tbFirstName.Text, tbLastName.Text, tbMail.Text, (Role)cbxRole.SelectedItem);
            tbFirstName.Clear();
            tbLastName.Clear();
            tbMail.Clear();


            MessageBox.Show("Nouvel utilisateur enregister !");

        }
    }
}
