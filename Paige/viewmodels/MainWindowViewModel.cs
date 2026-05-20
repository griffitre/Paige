using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using Paige.commands;
using Paige.views;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for
    public class MainWindowViewModel : ViewModelBase
    {
        // Declare the ActiveMenu object. Used to keep track of and change the current menu on screen, also make it bindable
        private object _activeMenu;
        public object ActiveMenu
        {
            get { return _activeMenu; }
            set { _activeMenu = value; OnPropertyChanged(nameof(ActiveMenu)); }
        }

        // Declare navigation command
        public ICommand UpdateViewCommand { get; set; }

        // Constructor. Sets the main menu to the active menu by default
        public MainWindowViewModel() 
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            ActiveMenu = new MainMenuViewModel(UpdateViewCommand);
        }
    }
}
