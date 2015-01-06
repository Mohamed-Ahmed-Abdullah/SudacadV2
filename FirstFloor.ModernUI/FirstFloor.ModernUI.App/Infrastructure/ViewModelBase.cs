using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAccess.DataContext;
using FirstFloor.ModernUI.Windows.Navigation;

namespace FirstFloor.ModernUI.App.Infrastructure
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public DatabaseContext DatabaseContext { get; set; }

        /// <summary>
        /// will be called when UserControlBase Loaded
        /// </summary>
        public ICommand Load { get; set; }

        public ViewModelBase()
        {
            //TODO: this should be done by the Ioc and should be one instance created when the application start
            DatabaseContext = new DatabaseContext();
        }

        public void Navigate(string to, object parameter = null)
        {
            LinkCommands.NavigateLink.Execute(to, null);
            ApplicationController.Parameter = parameter;
        }

        public T GetParameter<T>()
        {
            return (T)ApplicationController.Parameter;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}