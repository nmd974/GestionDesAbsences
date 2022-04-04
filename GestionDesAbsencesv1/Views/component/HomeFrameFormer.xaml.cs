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
using GestionDesAbsencesv1.ViewModels;

namespace GestionDesAbsencesv1.Views.component
{
    /// <summary>
    /// Logique d'interaction pour HomeFrameFormer.xaml
    /// </summary>
    public partial class HomeFrameFormer : Page
    {
        public static HomeFrameFormer frameFormer;
        public HomeFrameFormer()
        {
     
            InitializeComponent();
            DataContext = Actions.ViewModel.Promotion;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DG1.ItemsSource = Actions.ViewModel.Promotion.getPromotionsStudents();
        }
    }
}
