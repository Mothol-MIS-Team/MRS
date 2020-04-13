using System.ComponentModel;
using System.Windows;
using System;
using MRS_Store.Models;
using MRS_Store.Models.Services;
using System.Runtime.CompilerServices;

namespace MRS_Store.ViewModels
{
    /// <summary>
    /// Provides common functionality for ViewModel classes.
    /// </summary>
    public abstract class ViewModelBase : IViewModel, INotifyPropertyChanged
    {

        public string Title { get; }

        public bool IsInDesignMode()
        {
            return Application.Current.MainWindow == null
                ? true
                : DesignerProperties.GetIsInDesignMode(Application.Current.MainWindow);
        }
        public ViewModelBase(string title)
        {
            Title = title;
            if (!IsInDesignMode())
            {
                // runtime only code here...
                Title += " is alive!";
            }
        }
        //#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public event PropertyChangedEventHandler PropertyChanged;
        //#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
