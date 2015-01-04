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

            }
        }
    }
}