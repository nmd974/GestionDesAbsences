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

namespace GestionDesAbsencesv1.Views.component.Roles
{
    /// <summary>
    /// Logique d'interaction pour AddRoleView.xaml
    /// </summary>
    public partial class AddRoleView : Page
    {
        readonly RoleViewModel db = Actions.ViewModel.Roles;
        public AddRoleView()
        {
            this.DataContext = db;
            InitializeComponent();
        }

        private void AddNewRole(object sender, EventArgs e)
        {
            db.Store(RoleLabel.Text);
            LayoutHome.HomeFrame.Content = new ListRoleView();
        }
    }
}
