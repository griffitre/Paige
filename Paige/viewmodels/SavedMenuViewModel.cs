using System.Windows.Input;
using System.Windows.Threading;

namespace Paige.viewmodels
{
    // Definition of the viewmodel for savedmenuview
    public class SavedMenuViewModel : ViewModelBase
    {
        // Constructor
        public SavedMenuViewModel(ICommand updateViewCommand)
        {
            // Create a timer that fires off every 2 seconds
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(2)
            };

            // Once the timer fires off once, stop it and navigate back to the main menu
            timer.Tick += (sender, e) =>
            {
                timer.Stop();
                updateViewCommand.Execute("main");
            };

            // Start the timer
            timer.Start();
        }
    }
}
