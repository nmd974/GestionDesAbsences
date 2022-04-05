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
    /// Logique d'interaction pour ListRoleView.xaml
    /// </summary>
    public partial class ListRoleView : Page
    {
        readonly RoleViewModel db = Actions.ViewModel.Roles;
        public ListRoleView()
        {
            this.DataContext = db;
            InitializeComponent();
        }
        private void NavigateToAddRole(object sender, EventArgs e)
        {
            LayoutHome.HomeFrame.Content = new AddRoleView();
        }

        private void NavigateToUpdateRole(object sender, EventArgs e)
        {
            var element = sender as FrameworkElement;
            db.IdConcerned = int.Parse(element.Uid);
            LayoutHome.HomeFrame.Content = new UpdateRoleView();
        }

        private void NavigateToDeleteRole(object sender, EventArgs e)
        {
            var element = sender as FrameworkElement;
            db.IdConcerned = int.Parse(element.Uid);
            LayoutHome.HomeFrame.Content = new DeleteRoleView();
        }
    }
}
