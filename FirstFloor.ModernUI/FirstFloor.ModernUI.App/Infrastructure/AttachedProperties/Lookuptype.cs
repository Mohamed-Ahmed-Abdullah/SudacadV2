using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DataAccess.DataContext;
using FirstFloor.ModernUI.App.Common;

namespace FirstFloor.ModernUI.App.Infrastructure.AttachedProperties
{
    public class LookupTypeAttached : FrameworkElement
    {
        public static readonly DependencyProperty LookupTypeProperty = DependencyProperty.RegisterAttached(
          "LookupType",
          typeof(LookupTypes),
          typeof(LookupTypeAttached),
          new PropertyMetadata(LookupTypes.None, new PropertyChangedCallback(PropertyChanged)));

        public static void SetLookupType(UIElement element, LookupTypes value)
        {
            element.SetValue(LookupTypeProperty, value);
        }

        public static LookupTypes GetLookupType(UIElement element)
        {
            return (LookupTypes)element.GetValue(LookupTypeProperty);
        }


        private static void PropertyChanged (DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var comboBox = d as ComboBox;
            if (comboBox == null)
                return;

            new LookupService().SetLookup(comboBox,(LookupTypes)e.NewValue);
        }
    }
}