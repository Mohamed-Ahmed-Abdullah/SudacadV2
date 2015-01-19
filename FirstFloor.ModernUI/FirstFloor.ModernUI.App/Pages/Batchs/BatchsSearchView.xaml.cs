using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DataAccess.DbEntities;
using FirstFloor.ModernUI.App.Infrastructure;
using FirstFloor.ModernUI.App.Pages.Trainees;
using FirstFloor.ModernUI.App.ParametersDtos;

namespace FirstFloor.ModernUI.App.Pages.Batchs
{
    public partial class BatchsSearchView
    {
        public BatchsSearchView()
        {
            InitializeComponent();
            DataContext = new BatchsSearchViewModel();
        }

        private void DataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ViewModel<TraineesSearchViewModel>().OpenTrainee.Execute(DataGrid.SelectedItem);
        }
    }

    public class BatchsSearchViewModel : ViewModelBase
    {
        public string ArabicNameContains { get; set; }
        public string EnglishNameContains { get; set; }

        public DateTime StartDateFrom { get; set; }
        public DateTime StartDateTo { get; set; }

        public DateTime EndDateFrom { get; set; }
        public DateTime EndDateTo { get; set; }

        public int PeriodFrom { get; set; }
        public int PeriodTo { get; set; }

        public Room Room { get; set; }

        public Course Course { get; set; }

        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }

        public decimal TeacherCostFrom { get; set; }
        public decimal TeacherCostTo { get; set; }


        private List<Batch> _resultSet;
        public List<Batch> ResultSet
        {
            get { return _resultSet; }
            set
            {_resultSet = value; NotifyPropertyChanged(); }
        }

        public ICommand Search { get; set; }
        public ICommand NewSearch { get; set; }
        public ICommand New { get; set; }
        public ICommand Open { get; set; }

        public BatchsSearchViewModel()
        {
            Open = new DelegateCommand<Trainee>( trainee =>
                Navigate("/Pages/Batchs/BatchView.xaml", new IntegerId { Id = trainee.TraineeId }));

            New = new DelegateCommand(() => Navigate("/Pages/Batchs/BatchView.xaml"));

            Search = new DelegateCommand(() =>
            {
                var query = DatabaseContext.Batchs.AsQueryable();

                //if (!string.IsNullOrWhiteSpace(ArabicNameContains))
                //    query = query.Where(w =>
                //        (
                //            (w.ArabicFirstName + " " + w.ArabicSecondName + " " + w.ArabicThirdName + " " + w.ArabicLastName)
                //            .Contains(ArabicNameContains)
                //        ));
                
                //if (!string.IsNullOrWhiteSpace(EnglishNameContains))
                //    query = query.Where(w =>
                //        ((w.EnglishFirstName + " " + w.EnglishSecondName + " " + w.EnglishThirdName + " " + w.EnglishLastName)
                //        .Contains(EnglishNameContains)));

                //if (!string.IsNullOrWhiteSpace(IdentityNumber))
                //    query = query.Where(w =>
                //        ((w.Identity != null && w.Identity.IdentityNumber != null &&
                //          w.Identity.IdentityNumber.Contains(IdentityNumber))));

                //if (IdentityType != null)
                //    query = query.Where(w =>
                //        (w != null && w.Identity != null && w.Identity.IdentityType != null &&
                //            w.Identity.IdentityType.Id == IdentityType.Id
                //            ));

                //if (Nationality != null)
                //    query = query.Where( w =>
                //                w.Identity != null && w.Identity.Nationality != null &&
                //                w.Identity.Nationality.Id == (Nationality == null ? null : (int?) Nationality.Id));

                //if (Job != null)
                //    query = query.Where( w =>
                //                w.Job != null && w.Job.Id != Job.Id);

                //if (!string.IsNullOrWhiteSpace(TelephoneNumberContains))
                //    query = query.Where(w =>
                //                w.PhoneNumber != null && w.PhoneNumber.Contains(TelephoneNumberContains));

                //if (!string.IsNullOrWhiteSpace(EmailContains))
                //    query = query.Where(w =>
                //                w.EmailAddress != null && w.EmailAddress.Contains(EmailContains));

                //if (!string.IsNullOrWhiteSpace(NotesContains))
                //    query = query.Where(w =>
                //                w.Notes != null && w.Notes.Contains(NotesContains));

                ResultSet = query.ToList();
            });


            NewSearch = new DelegateCommand(() =>
            {
                
            });            
        }

    }
}