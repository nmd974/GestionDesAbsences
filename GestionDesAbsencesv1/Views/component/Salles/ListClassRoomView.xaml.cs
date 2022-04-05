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

namespace GestionDesAbsencesv1.Views.component.Salles
{
    /// <summary>
    /// Logique d'interaction pour ListRoleView.xaml
    /// </summary>
    public partial class ListClassRoomView : Page
    {
        readonly ClassroomViewModel db = Actions.ViewModel.Classroom;
        public ListClassRoomView()
        {
            this.DataContext = db;
            InitializeComponent();
        }
        private void NavigateToAddClassRoom(object sender, EventArgs e)
        {
            LayoutHome.HomeFrame.Content = new AddClassRoomView();
        }

        private void NavigateToUpdateClassRoom(object sender, EventArgs e)
        {
            var element = sender as FrameworkElement;
            db.IdConcerned = int.Parse(element.Uid);
            LayoutHome.HomeFrame.Content = new UpdateClassRoomView();
        }

        private void NavigateToDeleteClassRoom(object sender, EventArgs e)
        {
            var element = sender as FrameworkElement;
            db.IdConcerned = int.Parse(element.Uid);
            LayoutHome.HomeFrame.Content = new DeleteClassRoomView();
        }
    }
}
