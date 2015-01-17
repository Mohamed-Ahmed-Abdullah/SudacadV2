using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DataAccess.DbEntities;
using FirstFloor.ModernUI.App.Infrastructure;
using FirstFloor.ModernUI.App.ParametersDtos;

namespace FirstFloor.ModernUI.App.Pages.Teachers
{
    public partial class TeachersSearchView
    {
        public TeachersSearchView()
        {
            InitializeComponent();
            DataContext = new TeachersSearchViewModel();
        }

        private void DataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ViewModel<TeachersSearchViewModel>().OpenTeacher.Execute(DataGrid.SelectedItem);
        }
    }

    public class TeachersSearchViewModel : ViewModelBase
    {
        public string ArabicNameContains { get; set; }
        public string EnglishNameContains { get; set; }

        public string IdentityNumber { get; set; }
        public IdentityType IdentityType { get; set; }
        public Nationality Nationality { get; set; }
        public string TelephoneNumberContains { get; set; }
        public string EmailContains { get; set; }
        public string NotesContains { get; set; }

        private List<Teacher> _resultSet;
        public List<Teacher> ResultSet
        {
            get { return _resultSet; }
            set
            { _resultSet = value; NotifyPropertyChanged(); }
        }

        public ICommand Search { get; set; }
        public ICommand NewSearch { get; set; }
        public ICommand NewTeacher { get; set; }
        public ICommand OpenTeacher { get; set; }

        public TeachersSearchViewModel()
        {
            //TODO: create a method that you gave type TeacherView and it return the specific URI cuz this will be maintainable and robust, unlike the current string 
            OpenTeacher = new DelegateCommand<Teacher>(trainee =>
                Navigate("/Pages/Teachers/TeacherView.xaml", new IntegerId { Id = trainee.TeacherId }));

            NewTeacher = new DelegateCommand(() => Navigate("/Pages/Teachers/TeacherView.xaml"));

            Search = new DelegateCommand(() =>
            {
                var query = DatabaseContext.Teachers.Include("Identity").AsQueryable();

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

                #region Identity
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
                    query = query.Where(w =>
                                w.Identity != null && w.Identity.Nationality != null &&
                                w.Identity.Nationality.Id == (Nationality == null ? null : (int?)Nationality.Id));
                #endregion

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


        }
    }
}