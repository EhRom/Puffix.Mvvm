using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Puffix.Mvvm.Models
{
    /// <summary>
    /// Base class for INotifyPropertyChanged implementation
    /// </summary>
    public abstract class BaseNotifyPropertyChanged : INotifyPropertyChanged, IModel
    {
        /// <summary>
        /// Event to notify when a property value changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Set the property value.
        /// </summary>
        /// <typeparam name="ValueT">Type of the property value.</typeparam>
        /// <param name="backingStore">Reference to the background field.</param>
        /// <param name="value">New value.</param>
        /// <param name="propertyName">Name of the property (name of the memeber which called the method).</param>
        /// <param name="onChanged">Action on change.</param>
        /// <returns></returns>
        protected bool SetProperty<ValueT>(ref ValueT backingStore, ValueT value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<ValueT>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Fire the OnPropertyChanged event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
