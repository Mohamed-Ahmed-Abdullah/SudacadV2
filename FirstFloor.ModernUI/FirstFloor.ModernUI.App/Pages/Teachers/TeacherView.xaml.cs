using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using DataAccess.DbEntities;
using FirstFloor.ModernUI.App.Infrastructure;
using FirstFloor.ModernUI.App.ParametersDtos;
using FirstFloor.ModernUI.Windows.Controls;

namespace FirstFloor.ModernUI.App.Pages.Teachers
{
    public partial class TeacherView
    {
        public TeacherView()
        {
            InitializeComponent();
            DataContext = new TeacherViewModel();
        }
    }

    public class TeacherViewModel : ViewModelBase
    {
        private Teacher _entity;
        public Teacher Entity
        {
            get { return _entity; }
            set { _entity = value; NotifyPropertyChanged(); }
        }

        public ICommand Save { get; set; }
        public ICommand AddTeacherCources { get; set; }

        public TeacherViewModel()
        {
            AddTeacherCources = new DelegateCommand(() =>
            {
                var result = ShowDialog(new AddTeacherCource());
                Debug.WriteLine("");
            });

            Load = new DelegateCommand(LoadMethod);
            Save = new DelegateCommand(() =>
            {
                if (Entity.TeacherId == 0)
                    DatabaseContext.Teachers.Add(Entity);

                DatabaseContext.SaveChanges();
            });
        }

        private void LoadMethod()
        {
            var intId = GetParameter<IntegerId>();
            if (intId != null && intId.Id.HasValue)
            {
                var entity = DatabaseContext.Teachers.FirstOrDefault(f => f.TeacherId == intId.Id);
                if (entity == null)
                    NewEntity();
                else
                    Entity = entity;
            }
            else
                NewEntity();
        }

        private void NewEntity()
        {
            Entity = new Teacher
            {
                Identity = new Identity(),
            };
        }

    }
}