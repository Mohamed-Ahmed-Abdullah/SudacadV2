using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FirstFloor.ModernUI.App.Common
{
    public class LookupComboBox : ComboBox
    {
        public LookupTypes LookupType
        {
            get { return (LookupTypes)GetValue(LookupComboBoxProperty); }
            set { SetValue(LookupComboBoxProperty, value); }
        }

        public static readonly DependencyProperty LookupComboBoxProperty = DependencyProperty.Register(
          "LookupType", typeof(LookupTypes), typeof(LookupComboBox), new PropertyMetadata(false));

        public LookupComboBox()
        {
            Loaded += (s, e) =>
            {
            };


        }
    }

    public enum LookupTypes
    {
        Job,

    }
}