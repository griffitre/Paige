using System.Windows.Input;
using Paige.commands;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for mainwindowview
    public class MainWindowViewModel : ViewModelBase
    {
        // Commands
        // Declare navigation command
        public ICommand UpdateViewCommand { get; }


        // Properties to expose + make them bindable
        // ActiveMenu. Used to keep track of and change the current menu on screen, also make it bindable
        private object _activeMenu;
        public object ActiveMenu
        {
            get { return _activeMenu; }
            set 
            { 
                _activeMenu = value;
                OnPropertyChanged(nameof(ActiveMenu));
            }
        }
        

        // Constructor. Sets the main menu to the active menu by default
        public MainWindowViewModel() 
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            ActiveMenu = new MainMenuViewModel(UpdateViewCommand);
        }
    }
}
