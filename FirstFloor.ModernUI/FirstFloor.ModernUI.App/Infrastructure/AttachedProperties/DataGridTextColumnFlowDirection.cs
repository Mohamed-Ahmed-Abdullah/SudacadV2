using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FirstFloor.ModernUI.App.Common;

namespace FirstFloor.ModernUI.App.Infrastructure.AttachedProperties
{
    public class DataGridTextColumnFlowDirection
    {
        public DataGridTextColumnFlowDirection()
        {
            //FlowDirection
        }

        public static readonly DependencyProperty FlowDirectionProperty = DependencyProperty.RegisterAttached(
              "FlowDirection",
              typeof(FlowDirection),
              typeof(DataGridTextColumnFlowDirection),
              new PropertyMetadata(FlowDirection.RightToLeft, new PropertyChangedCallback(PropertyChanged)));

        public static void SetFlowDirection(UIElement element, FlowDirection value)
        {
            element.SetValue(FlowDirectionProperty, value);
        }

        public static FlowDirection GetFlowDirection(UIElement element)
        {
            return (FlowDirection)element.GetValue(FlowDirectionProperty);
        }


        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textColumn = d as DataGridTextColumn;
            if (textColumn == null)
                return;

           //var textBlock =  FindChildren<TextBlock>(d);
        }

        internal static T FindChildren<T>(DependencyObject startNode) where T : DependencyObject
        {
            var count = VisualTreeHelper.GetChildrenCount(startNode);
            for (var i = 0; i < count; i++)
            {
                var current = VisualTreeHelper.GetChild(startNode, i);
                if (current.GetType() == typeof(T))
                {
                    return (T)current;
                }
                FindChildren<T>(current);
            }
            return null;
        }
    }
}