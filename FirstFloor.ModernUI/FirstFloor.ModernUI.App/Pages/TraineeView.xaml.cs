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
            viewModel.Entity = new Trainee();
            viewModel.DatabaseContext.Trainees.Add(viewModel.Entity);
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            //TODO: this should be command 
            ((TraineeViewModel) DataContext).DatabaseContext.SaveChanges();
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

        public TraineeViewModel()
        {
            Save = new DelegateCommand(() => DatabaseContext.SaveChanges());
        }

    }
}