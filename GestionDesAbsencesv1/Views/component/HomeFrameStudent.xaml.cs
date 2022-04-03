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
    /// Logique d'interaction pour HomeFrameStudent.xaml
    /// </summary>
    public partial class HomeFrameStudent : Page
    {
        public static HomeFrameStudent frameStudent;
        public HomeFrameStudent()
        {
            InitializeComponent();
            Actions.ViewModel.Student.StartHomeStudent();
            DataContext = Actions.ViewModel.Student;
            GraphTxAbsent.Value = Actions.ViewModel.Student.TxAbsent; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Actions.ViewModel.Student.FilterDataDate();
            GraphTxAbsent.Value = Actions.ViewModel.Student.TxAbsent;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Actions.ViewModel.Student.GeneratePdf();
        }
    }
}
