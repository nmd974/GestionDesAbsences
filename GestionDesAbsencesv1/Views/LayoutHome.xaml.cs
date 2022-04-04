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
    /// Logique d'interaction pour LayoutHome.xaml
    /// </summary>
    public partial class LayoutHome : Page
    {
        static public ListBox BtnList { get; set; }
        public static Frame HomeFrame { get; set; }
        public LayoutHome()
        { 
            InitializeComponent();
            BtnList = ListButtonsHome;
            HomeFrame = homeFrame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
