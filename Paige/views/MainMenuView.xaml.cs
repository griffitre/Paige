using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Paige.viewmodels;

namespace Paige.views
{
    // Basically just setting the data context to the appropriate viewmodel
    public partial class MainMenuView : UserControl
    {
        public MainMenuView()
        {
            // Initialize and set data context to the appropriate view model
            InitializeComponent();
            DataContext = new MainMenuViewModel();
        }
    }
}
