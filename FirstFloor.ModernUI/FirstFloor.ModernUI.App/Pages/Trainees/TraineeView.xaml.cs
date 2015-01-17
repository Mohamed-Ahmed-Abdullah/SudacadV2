using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataAccess.DbEntities;
using FirstFloor.ModernUI.App.Infrastructure;
using FirstFloor.ModernUI.App.ParametersDtos;

namespace FirstFloor.ModernUI.App.Pages.Trainees
{
    public partial class TraineeView
    {
        public TraineeView()
        {
            InitializeComponent();

            //TODO: should be changed to reflection
            DataContext = new TraineeViewModel();

            Loaded += TraineeView_Loaded;
        }

        void TraineeView_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }

    public class TraineeViewModel : ViewModelBase 
    {
        private Trainee _entity;
        public Trainee Entity
        {
            get { return _entity; }
            set { _entity = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand Save { get; set; }
        public ICommand Delete { get; set; }
        public ICommand TraineeTypeChanged { get; set; }

        private bool _alone;
        public bool Alone
        {
            get { return _alone; }
            set { _alone = value;
            if (TraineeTypeChanged!=null)
                TraineeTypeChanged.Execute(null);
                NotifyPropertyChanged();
            }
        }

        private bool _withSudatel;
        public bool WithSudatel
        {
            get { return _withSudatel; }
            set
            {
                _withSudatel = value;
                if (TraineeTypeChanged != null) TraineeTypeChanged.Execute(null);
                NotifyPropertyChanged();
            }
        }

        private bool _withOrganization;
        public bool WithOrganization
        {
            get { return _withOrganization; }
            set
            {
                _withOrganization = value; 
                if (TraineeTypeChanged != null) TraineeTypeChanged.Execute(null);
                NotifyPropertyChanged();
            }
        }

        public TraineeViewModel()
        {
            Alone = true;

            Load = new DelegateCommand(LoadMethod);
            Save = new DelegateCommand(() =>
            {
                //if(is insert new) we need to add it to the collection first, if update just save the new
                if (Entity.TraineeId == 0)
                    DatabaseContext.Trainees.Add(Entity);

                DatabaseContext.SaveChanges();
            });
            Delete = new DelegateCommand(() =>
            {
                //TODO: delete checks
                //TODO: delete it or conferm the error
            });
            
            TraineeTypeChanged = new DelegateCommand(() =>
            {
                Entity.Sudatel = null;
                Entity.TraineeOrganizations = null;
                Entity.TraineeType = null;

                if (WithSudatel)
                {
                    Entity.Sudatel  = new TraineeSudatel();
                    Entity.TraineeType = DatabaseContext.TraineeTypes
                        .First(f=>f.Id == (int)TraineeTypeEnum.Sudatel);
                }

                if (WithOrganization)
                {
                    Entity.TraineeOrganizations = new TraineeOrganizations();
                    Entity.TraineeType = DatabaseContext.TraineeTypes
                        .First(f => f.Id == (int)TraineeTypeEnum.Organization);
                }

                if (Alone)
                {
                    Entity.TraineeType = DatabaseContext.TraineeTypes
                        .First(f => f.Id == (int)TraineeTypeEnum.Individual);
                }

            });
        }

        private void LoadMethod()
        {
            var intId = GetParameter<IntegerId>();
            if (intId != null && intId.Id.HasValue)
            {
                var entity = DatabaseContext.Trainees.FirstOrDefault(f => f.TraineeId == intId.Id);
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
            Entity = new Trainee
            {
                Identity = new Identity(),
            };
        }
    }
}