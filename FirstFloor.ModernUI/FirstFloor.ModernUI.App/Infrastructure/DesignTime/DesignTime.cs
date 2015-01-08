using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FirstFloor.ModernUI.App.Infrastructure.DesignTime
{
    public static class DesignTime
    {
        static bool? _inDesignMode;

        /// <summary>
        /// Indicates whether or not the framework is in design-time mode. (Caliburn.Micro implementation)
        /// </summary>
        private static bool InDesignMode
        {
            get
            {
                if (_inDesignMode == null)
                {
                    var prop = DesignerProperties.IsInDesignModeProperty;
                    _inDesignMode = (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;

                    if (!_inDesignMode.GetValueOrDefault(false) && System.Diagnostics.Process.GetCurrentProcess()
                            .ProcessName.StartsWith("devenv", System.StringComparison.Ordinal))
                        _inDesignMode = true;
                }

                return _inDesignMode.GetValueOrDefault(false);
            }
        }

        public static DependencyProperty BackgroundProperty = DependencyProperty.RegisterAttached(
            "Background", typeof(System.Windows.Media.Brush), typeof(DesignTime),
            new PropertyMetadata(new PropertyChangedCallback(BackgroundChanged)));

        public static System.Windows.Media.Brush GetBackground(DependencyObject dependencyObject)
        {
            return (System.Windows.Media.Brush)dependencyObject.GetValue(BackgroundProperty);
        }
        public static void SetBackground(DependencyObject dependencyObject, System.Windows.Media.Brush value)
        {
            dependencyObject.SetValue(BackgroundProperty, value);
        }
        private static void BackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!InDesignMode)
                return;

            d.GetType().GetProperty("Background").SetValue(d, e.NewValue, null);
        }
    }
}
