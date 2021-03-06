﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace FirstFloor.ModernUI.App.Infrastructure
{
    public class UserControlBase : UserControl
    {
        public UserControlBase()
        {
            FlowDirection = FlowDirection.RightToLeft;

            //Execute Lod Command in each view 
            Loaded+= (sender, e) =>
            {
                var viewModel = DataContext as ViewModelBase;
                if (viewModel == null)
                    return;

                if (viewModel.Load == null)
                    return;

                viewModel.Load.Execute(null);
            };
        }

        public T ViewModel<T>()
        {
            return (T) DataContext;
        }
    }
}