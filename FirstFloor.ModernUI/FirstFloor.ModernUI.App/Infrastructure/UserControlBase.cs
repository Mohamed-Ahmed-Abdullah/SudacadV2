using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FirstFloor.ModernUI.App.Infrastructure
{
    public class UserControlBase : UserControl
    {
        public UserControlBase()
        {
            FlowDirection = FlowDirection.RightToLeft;
        }
    }
}