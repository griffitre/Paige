using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for savedmenuview
    public class SavedMenuViewModel : ViewModelBase
    {
        // Constructor
        public SavedMenuViewModel(ICommand updateViewCommand)
        {
            // Wait 3 seconds, then send the user back to the main menu
            Thread.Sleep(3000);
            updateViewCommand.Execute("main");
        }
    }
}
