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
        public ICommand UpdateTeacherCources { get; set; }

        public TeacherViewModel()
        {
            AddTeacherCources = new DelegateCommand(() => SaveTeacherCources(null));

            UpdateTeacherCources = new DelegateCommand<TeacherCource>(SaveTeacherCources);

            Load = new DelegateCommand(LoadMethod);
            Save = new DelegateCommand(() =>
            {
                if (Entity.TeacherId == 0)
                    DatabaseContext.Teachers.Add(Entity);

                DatabaseContext.SaveChanges();
            });
        }

        public void SaveTeacherCources(TeacherCource teacherCource)
        {
            var result = ShowDialog(new AddTeacherCource(teacherCource)) as TeacherCource;

            if (result != null)
            {
                if(result.Id == 0)
                    Entity.Cources.Add(result);

                DatabaseContext.SaveChanges();
            }
            else
            {
                //uer press cancel in the dialog box
            }
        }

        private void LoadMethod()
        {
            var intId = GetParameter<IntegerId>();

            //Bug: hardcoded id for testing 
            intId = new IntegerId {Id = 1};

            if (intId != null && intId.Id.HasValue)
            {
                var entity = DatabaseContext.Teachers
                    .Include("Cources").FirstOrDefault(f => f.TeacherId == intId.Id);
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