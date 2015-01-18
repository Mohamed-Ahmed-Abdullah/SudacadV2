using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAccess.DataContext;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;

namespace FirstFloor.ModernUI.App.Infrastructure
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        //TODO: This is super wrong you have to change it to Ioc, to see why i did this keep reading 
        // if makes the development faster and the appication performance faster, for instance the lookups, 
        //if you don't retreve them from the same DbContext Exception will be thrown
        /// <summary>
        /// one instance from the DbContext to the wholw application
        /// </summary>
        public static readonly DatabaseContext Database = new DatabaseContext();

        public DatabaseContext DatabaseContext { get; set; }

        /// <summary>
        /// will be called when UserControlBase Loaded
        /// </summary>
        public ICommand Load { get; set; }

        public ViewModelBase()
        {
            //TODO: this should be done by the Ioc and should be one instance created when the application start
            DatabaseContext = Database;
        }

        public void Navigate(string to, object parameter = null)
        {
            LinkCommands.NavigateLink.Execute(to, null);
            ApplicationController.Parameter = parameter;
        }

        public object ShowDialog(IDialog view)
        {
            var dialog = new ModernDialog
            {
                Title = view.Title,
                Content = view,
                Buttons = null
            };

            dialog.ShowDialog();
            
            return view.DialogResult;
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