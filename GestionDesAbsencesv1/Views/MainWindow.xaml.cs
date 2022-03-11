﻿using GestionDesAbsencesv1.Models;
using GestionDesAbsencesv1.Service;
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

namespace GestionDesAbsencesv1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var context = new AbsenceBddContext();

            context.Database.EnsureCreated();

            Role role = new() { Label = "admin" };

            context.Roles.Add(role);
            context.SaveChanges();
        }
    }
}