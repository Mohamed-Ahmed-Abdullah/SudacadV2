using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DataAccess.DataContext;
using FirstFloor.ModernUI.App.Infrastructure.AttachedProperties;

namespace FirstFloor.ModernUI.App.Common
{
    public enum LookupTypes
    {
        None,
        Jobs,
        Nationalities,
        IdentityType,
        Division,
        OrganizationType,
        Organization,
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
                    comboBox.ItemsSource =  PublicDatabaseContext.PublicContext.Jobs.ToList();
                }
                    break;
                case LookupTypes.Nationalities:
                {
                    comboBox.DisplayMemberPath = "ArabicName";
                    comboBox.ItemsSource =  PublicDatabaseContext.PublicContext.Nationalities.ToList();
                }
                    break;
                case LookupTypes.IdentityType:
                {
                    comboBox.DisplayMemberPath = "ArabicName";
                    comboBox.ItemsSource =  PublicDatabaseContext.PublicContext.IdentityTypes.ToList();
                }
                    break;
                case LookupTypes.Division:
                {
                    comboBox.DisplayMemberPath = "ArabicName";
                    comboBox.ItemsSource =  PublicDatabaseContext.PublicContext.Divisions.ToList();
                }
                    break;

                case LookupTypes.OrganizationType:
                {
                    comboBox.DisplayMemberPath = "ArabicName";
                    comboBox.ItemsSource =  PublicDatabaseContext.PublicContext.OrganizationTypes.ToList();
                }
                    break;
                case LookupTypes.Organization:
                {
                    comboBox.DisplayMemberPath = "ArabicName";
                    comboBox.ItemsSource =  PublicDatabaseContext.PublicContext.Organizations.ToList();
                }
                    break;

            }
        }
    }
}