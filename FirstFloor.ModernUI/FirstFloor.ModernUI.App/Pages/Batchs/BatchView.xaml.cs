using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DataAccess.DbEntities;
using FirstFloor.ModernUI.App.Common.Controls.TagControl;
using FirstFloor.ModernUI.App.Infrastructure;
using FirstFloor.ModernUI.App.ParametersDtos;

namespace FirstFloor.ModernUI.App.Pages.Batchs
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

        private List<TagItem> _selectedItems = new List<TagItem>();
        public List<TagItem> SelectedItems
        {
            get { return _selectedItems; }
            set
            {
                _selectedItems = value;
                NotifyPropertyChanged();
            }
        }

        public List<Tag> AllItems { get; set; }


        public BatchViewModel()
        {
            AllItems = new List<Tag>
            {
                new Tag {Id = 1, Name = "apple"    },
                new Tag {Id = 2, Name = "microsoft"},
                new Tag {Id = 3, Name = "orange"   },
                new Tag {Id = 4, Name = "banana"   },
                new Tag {Id = 5, Name = "moza"     },
            };

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
                Organizations = new List<BatchOrganization>(),
                Teachers = new List<Teacher>(),
                Trainees = new List<BatchTrainee>(),
            };
        }
    }
}