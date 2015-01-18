using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DataAccess.DataContext;
using FirstFloor.ModernUI.App.Infrastructure;
using FirstFloor.ModernUI.App.Infrastructure.AttachedProperties;

namespace FirstFloor.ModernUI.App.Common
{
    //TODO: change this to the real object type rather that LookupTypes.Jobs -> DataAccess.DbEntities.Job rather than LookupTypes -> Type (typeof)
    public enum LookupTypes
    {
        None,
        Jobs,
        Nationalities,
        IdentityType,
        Division,
        OrganizationType,
        Organization,
        Cources,
        Rooms,
    }

    public class LookupService
    {
        public void SetLookup(ComboBox comboBox,LookupTypes lookupTypes)
        {
            switch (lookupTypes)
            {
                case LookupTypes.Jobs:
                {
                    comboBox.DisplayMemberPath = "ArabicName";
                    comboBox.SelectedValuePath = "Id";
                    comboBox.ItemsSource = ViewModelBase.Database.Jobs.ToList();
                }
                    break;
                case LookupTypes.Nationalities:
                {
                    comboBox.DisplayMemberPath = "ArabicName";
                    comboBox.SelectedValuePath = "Id";
                    comboBox.ItemsSource = ViewModelBase.Database.Nationalities.ToList();
                }
                    break;
                case LookupTypes.IdentityType:
                {
                    comboBox.DisplayMemberPath = "ArabicName";
                    comboBox.SelectedValuePath = "Id";
                    comboBox.ItemsSource = ViewModelBase.Database.IdentityTypes.ToList();
                }
                    break;
                case LookupTypes.Division:
                {
                    comboBox.DisplayMemberPath = "ArabicName";
                    comboBox.SelectedValuePath = "Id";
                    comboBox.ItemsSource = ViewModelBase.Database.Divisions.ToList();
                }
                    break;

                case LookupTypes.OrganizationType:
                {
                    comboBox.DisplayMemberPath = "ArabicName";
                    comboBox.SelectedValuePath = "Id";
                    comboBox.ItemsSource = ViewModelBase.Database.OrganizationTypes.ToList();
                }
                    break;
                case LookupTypes.Organization:
                {
                    comboBox.DisplayMemberPath = "ArabicName";
                    comboBox.SelectedValuePath = "Id";
                    comboBox.ItemsSource = ViewModelBase.Database.Organizations.ToList();
                }
                    break;
                case LookupTypes.Cources:
                {
                    comboBox.DisplayMemberPath = "ArabicName";
                    comboBox.SelectedValuePath = "CourseId";
                    comboBox.ItemsSource = ViewModelBase.Database.Courses.ToList();
                }
                    break;
                case LookupTypes.Rooms:
                {
                    comboBox.DisplayMemberPath = "ArabicName";
                    comboBox.SelectedValuePath = "Id";
                    comboBox.ItemsSource = ViewModelBase.Database.Rooms.ToList();
                }
                    break;
            }
        }
    }
}