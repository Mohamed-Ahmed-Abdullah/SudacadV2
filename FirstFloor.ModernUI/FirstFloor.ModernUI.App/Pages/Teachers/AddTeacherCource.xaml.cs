using System.Windows;
using System.Windows.Media;
using FirstFloor.ModernUI.App.Infrastructure;
using FirstFloor.ModernUI.Windows.Controls;

namespace FirstFloor.ModernUI.App.Pages.Teachers
{
    public partial class AddTeacherCource : IDialog
    {
        public AddTeacherCource()
        {
            InitializeComponent();
            //DataContext = new AddTeacherCourceViewModel();
        }

        public object DialogResult
        {
            get { return null; }
        }

        public string Title
        {
            get { return "اضافة كورس لاستاذ"; }
        }

        public void Close()
        {
            FindUpVisualTree<ModernDialog>(this).Close();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private static T FindUpVisualTree<T>(DependencyObject initial) where T : DependencyObject
        {
            var current = initial;
            while (current != null && current.GetType() != typeof(T))
            {
                current = VisualTreeHelper.GetParent(current);
            }
            return current as T;
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }

     //public class AddTeacherCourceViewModel : ViewModelBase
    //{
    //    public AddTeacherCourceViewModel()
    //    {

    //    }
    //}
}