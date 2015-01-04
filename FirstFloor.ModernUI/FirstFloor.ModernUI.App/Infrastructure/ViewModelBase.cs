using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataContext;

namespace FirstFloor.ModernUI.App.Infrastructure
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public DatabaseContext DatabaseContext { get; set; }

        public ViewModelBase()
        {
            //TODO: this should be done by the Ioc and should be one instance created when the application start
            DatabaseContext = new DatabaseContext();
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