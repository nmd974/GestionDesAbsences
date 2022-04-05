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

namespace GestionDesAbsencesv1.Views.component.Salles
{
    /// <summary>
    /// Logique d'interaction pour UpdateRoleView.xaml
    /// </summary>
    public partial class UpdateClassRoomView : Page
    {
        readonly ClassroomViewModel db = Actions.ViewModel.Classroom;
        public Classroom classroom;
        public UpdateClassRoomView()
        {
            this.DataContext = db;
            classroom = db.ListClassroom.Where(c => c.ClassroomId == db.IdConcerned).First();
            InitializeComponent();
            ClassRoomLabel.Text = classroom.Label;
            TitleAction.Text = "Modification du nom de la salle";
        }

        private void UpdateRole(object sender, EventArgs e)
        {
            classroom.Label = ClassRoomLabel.Text;
            db.Update();
            LayoutHome.HomeFrame.Content = new ListClassRoomView();
        }
    }
}
