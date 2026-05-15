using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace Paige.viewmodels
{
    // Base class for all view models
    public class ViewModelBase : INotifyPropertyChanged
    {

        // The event that is raised when a property's value changes
        public event PropertyChangedEventHandler PropertyChanged;

        // Fires property changed event to notify WPF bindings that a property has changed
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            // Automatically pass the name of the property that called this method using name (function parameter)
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
