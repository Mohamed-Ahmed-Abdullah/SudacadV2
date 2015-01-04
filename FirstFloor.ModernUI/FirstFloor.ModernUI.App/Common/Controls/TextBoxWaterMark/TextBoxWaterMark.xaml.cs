using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirstFloor.ModernUI.App.Common.Controls.TextBoxWaterMark
{
    public partial class TextBoxWaterMark : INotifyPropertyChanged
    {
        public static readonly DependencyProperty TextProperty =
             DependencyProperty.Register("Text", typeof(string),
             typeof(TextBoxWaterMark));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); NotifyPropertyChanged(); }
        }

        public static readonly DependencyProperty WaterMarkTextProperty =
     DependencyProperty.Register("WaterMarkText", typeof(string),
     typeof(TextBoxWaterMark));
        public string WaterMarkText
        {
            get { return (string)GetValue(WaterMarkTextProperty); }
            set { SetValue(WaterMarkTextProperty, value); NotifyPropertyChanged(); }
        }


        public TextBoxWaterMark()
        {
            InitializeComponent();
            DataContext = this;
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