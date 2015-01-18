using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DataAccess.DbEntities;
using FirstFloor.ModernUI.App.Infrastructure;
using FirstFloor.ModernUI.App.ParametersDtos;
using FirstFloor.ModernUI.Windows.Controls;

namespace FirstFloor.ModernUI.App.Pages.Teachers
{
    public partial class AddTeacherCource : IDialog
    {
        public AddTeacherCourceViewModel ViewModel {
            get { return (AddTeacherCourceViewModel) DataContext; }
        }

        public AddTeacherCource(TeacherCource teacherCource)
        {
            InitializeComponent();
            DataContext = new AddTeacherCourceViewModel();

            if (teacherCource != null)
                ViewModel.TeacherCoursePrice = teacherCource;
        }

        public object DialogResult
        {
            get { return ViewModel.TeacherCoursePrice; }
        }

        public string Title
        {
            get { return "اضافة كورس لاستاذ"; }
        }

        public void Close()
        {
            FindUpVisualTree<ModernDialog>(this).Close();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
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
            //TODO: if you make execute parameter less it will be better
            ViewModel.SelectIt.Execute(null);
            Close();
        }
    }

    public class AddTeacherCourceViewModel : ViewModelBase
    {
        public TeacherCource TeacherCoursePrice { get; set; }

        public Course Course { get; set; }
        public decimal Price { get; set; }

        public ICommand SelectIt { get; set; }

        public AddTeacherCourceViewModel()
        {
            SelectIt = new DelegateCommand(() =>
            {
                TeacherCoursePrice = new TeacherCource
                {
                    Course = Course,
                    Price = Price
                };
            });
        }

    }
}