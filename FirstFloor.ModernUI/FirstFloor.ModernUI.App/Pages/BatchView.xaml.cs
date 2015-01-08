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
    public partial class BatchView
    {
        public BatchView()
        {
            InitializeComponent();
            DataContext = new BatchViewModel();
        }
    }

    public class BatchViewModel : ViewModelBase
    {
        private Batch _entity;
        public Batch Entity
        {
            get { return _entity; }
            set
            {
                _entity = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand Save { get; set; }
        public ICommand Delete { get; set; }

        public BatchViewModel()
        {
            Load = new DelegateCommand(LoadMethod);
            Save = new DelegateCommand(() =>
            {
                if (Entity.BatchId == 0)
                    DatabaseContext.Batchs.Add(Entity);

                DatabaseContext.SaveChanges();
            });
            Delete = new DelegateCommand(() =>
            {
                //TODO: check the business Logic here then delete it
            });
        }

        private void LoadMethod()
        {
            var intId = GetParameter<IntegerId>();
            if (intId != null && intId.Id.HasValue)
            {
                var entity = DatabaseContext.Batchs
                    .Include("Organizations")
                    .Include("Teachers")
                    .Include("Trainees")
                    .FirstOrDefault(f => f.BatchId == intId.Id);
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
            Entity = new Batch
            {
                Organizations = new List<Organization>(),
                Teachers = new List<Teacher>(),
                Trainees = new List<Trainee>(),
            };
        }
    }
}