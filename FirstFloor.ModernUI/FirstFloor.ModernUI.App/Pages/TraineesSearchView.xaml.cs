using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DataAccess.DbEntities;
using FirstFloor.ModernUI.App.Infrastructure;
using FirstFloor.ModernUI.App.ParametersDtos;

namespace FirstFloor.ModernUI.App.Pages
{
    public partial class TraineesSearchView
    {

        public TraineesSearchView()
        {
            InitializeComponent();

            //TODO: should be changed to reflection
            DataContext = new TraineesSearchViewModel();
        }

        private void DataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ViewModel<TraineesSearchViewModel>().OpenTrainee.Execute(DataGrid.SelectedItem);
        }
    }

    public class TraineesSearchViewModel : ViewModelBase
    {
        public string ArabicNameContains { get; set; }
        public string EnglishNameContains { get; set; }

        public string IdentityNumber { get; set; }
        public IdentityType IdentityType { get; set; }
        public Nationality Nationality { get; set; }
        public Job Job { get; set; }
        public string TelephoneNumberContains { get; set; }
        public string EmailContains { get; set; }
        public string NotesContains { get; set; }
        public bool Alone { get; set; }
        public bool WithSudatel { get; set; }
        public bool WithOrganization { get; set; }


        private List<Trainee> _resultSet;
        public List<Trainee> ResultSet
        {
            get { return _resultSet; }
            set
            {_resultSet = value; NotifyPropertyChanged(); }
        }

        public ICommand Search { get; set; }
        public ICommand NewSearch { get; set; }
        public ICommand NewTrainee { get; set; }
        public ICommand OpenTrainee { get; set; }

        public TraineesSearchViewModel()
        {
            OpenTrainee = new DelegateCommand<Trainee>( (trainee) => 
                Navigate("/Pages/TraineeView.xaml", new IntegerId() {Id = trainee.TraineeId}));

            NewTrainee = new DelegateCommand(() => Navigate("/Pages/TraineeView.xaml"));

            Search = new DelegateCommand(() =>
            {
                var query = DatabaseContext.Trainees.Include("Identity").AsQueryable();

                if (!string.IsNullOrWhiteSpace(ArabicNameContains))
                    query = query.Where(w =>
                        (
                            (w.ArabicFirstName + " " + w.ArabicSecondName + " " + w.ArabicThirdName + " " + w.ArabicLastName)
                            .Contains(ArabicNameContains)
                        ));

                if (!string.IsNullOrWhiteSpace(EnglishNameContains))
                    query = query.Where(w =>
                        ((w.EnglishFirstName + " " + w.EnglishSecondName + " " + w.EnglishThirdName + " " + w.EnglishLastName)
                        .Contains(EnglishNameContains)));

                if (!string.IsNullOrWhiteSpace(IdentityNumber))
                    query = query.Where(w =>
                        ((w.Identity != null && w.Identity.IdentityNumber != null &&
                          w.Identity.IdentityNumber.Contains(IdentityNumber))));

                if (IdentityType != null)
                    query = query.Where(w =>
                        (w != null && w.Identity != null && w.Identity.IdentityType != null &&
                            w.Identity.IdentityType.Id == IdentityType.Id
                            ));

                if (Nationality != null)
                    query = query.Where( w =>
                                w.Identity != null && w.Identity.Nationality != null &&
                                w.Identity.Nationality.Id == (Nationality == null ? null : (int?) Nationality.Id));

                if (Job != null)
                    query = query.Where( w =>
                                w.Job != null && w.Job.Id != Job.Id);

                if (!string.IsNullOrWhiteSpace(TelephoneNumberContains))
                    query = query.Where(w =>
                                w.PhoneNumber != null && w.PhoneNumber.Contains(TelephoneNumberContains));

                if (!string.IsNullOrWhiteSpace(EmailContains))
                    query = query.Where(w =>
                                w.EmailAddress != null && w.EmailAddress.Contains(EmailContains));

                if (!string.IsNullOrWhiteSpace(NotesContains))
                    query = query.Where(w =>
                                w.Notes != null && w.Notes.Contains(NotesContains));

                ResultSet = query.ToList();
            });


            NewSearch = new DelegateCommand(() =>
            {
                
            });            
        }
    }
}