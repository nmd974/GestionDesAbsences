using GestionDesAbsencesv1.Models;
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
    /// Logique d'interaction pour UpdateRoleView.xaml
    /// </summary>
    public partial class UpdateRoleView : Page
    {
        readonly RoleViewModel db = Actions.ViewModel.Roles;
        public Role role;
        public UpdateRoleView()
        {
            this.DataContext = db;
            role = db.ListRoles.Where(c => c.RoleId == db.IdConcerned).First();
            InitializeComponent();
            RoleLabel.Text = role.Label;
        }

        private void UpdateRole(object sender, EventArgs e)
        {
            role.Label = this.RoleLabel.Text;
            db.Update();
            LayoutHome.HomeFrame.Content = new ListRoleView();
        }
    }
}
