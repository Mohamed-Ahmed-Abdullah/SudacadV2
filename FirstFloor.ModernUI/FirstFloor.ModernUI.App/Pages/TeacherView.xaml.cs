using System;
using System.Collections.Generic;
using System.Linq;
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
using DataAccess.DbEntities;
using FirstFloor.ModernUI.App.Infrastructure;
using FirstFloor.ModernUI.App.ParametersDtos;

namespace FirstFloor.ModernUI.App.Pages
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

        public TeacherViewModel()
        {
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