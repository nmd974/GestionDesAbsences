using GestionDesAbsencesv1.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace GestionDesAbsencesv1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly DataContextViewModel db = Actions.ViewModel;
        public MainWindow()
        {
            InitializeComponent();

            foreach (var role in Actions.ViewModel.Roles.ListRoles)
            {
                Debug.WriteLine($"Mon Id = {role.RoleId} et mon label = {role.Label}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MaterialDesignThemes.Wpf.ButtonProgressAssist.SetIsIndicatorVisible(ButtonLogin, true);
        }
    }
}
