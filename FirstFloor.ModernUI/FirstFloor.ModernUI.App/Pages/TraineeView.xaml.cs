using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using FirstFloor.ModernUI.App.Common;
using FirstFloor.ModernUI.App.Infrastructure;

namespace FirstFloor.ModernUI.App.Pages
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
            var viewModel = ((TraineeViewModel) DataContext);
            viewModel.Entity = new Trainee
            {
                Identity = new Identity(),
                //Sudatel = new TraineeSudatel(),
                //TraineeOrganizations = new TraineeOrganizations()
            };
            viewModel.DatabaseContext.Trainees.Add(viewModel.Entity);
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
        public ICommand Load { get; set; }
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

            Save = new DelegateCommand(() => DatabaseContext.SaveChanges());
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
    }
}