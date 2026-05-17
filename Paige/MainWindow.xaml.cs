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

namespace Paige
{
    // Basically just setting the data context to the appropriate viewmodel
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Initialize and set appropriate data context
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}