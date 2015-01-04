using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DbEntities;

namespace DataAccess.DataContext
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            #region Jobs
            IList<Job> jobs = new List<Job>();

            jobs.Add(new Job() {ArabicName="محاسب",EnglishName="Accountant",Notes="" });
            jobs.Add(new Job() {ArabicName="مطور نظم",EnglishName="Software Developer",Notes="" });
            jobs.Add(new Job() {ArabicName="مدير",EnglishName="Manager",Notes="" });

            foreach (var job in jobs)
                context.Jobs.Add(job);
            #endregion

            #region IdentityTypes
            IList<IdentityType> identityTypes = new List<IdentityType>();

            identityTypes.Add(new IdentityType() { ArabicName = "جواز سفر", EnglishName = "Passport", Notes = "" });
            identityTypes.Add(new IdentityType() { ArabicName = "جنسية", EnglishName = "Nationality Card", Notes = "" });
            identityTypes.Add(new IdentityType() { ArabicName = "رقم وطني", EnglishName = "National Number", Notes = "" });

            foreach (var identityType in identityTypes)
                context.IdentityTypes.Add(identityType);
            #endregion

            #region Nationalities
            IList<Nationality> nationalities = new List<Nationality>();

            nationalities.Add(new Nationality() { ArabicName = "سوداني", EnglishName = "Sudanies", Notes = "" });
            nationalities.Add(new Nationality() { ArabicName = "مصري", EnglishName = "Egyptian", Notes = "" });
            nationalities.Add(new Nationality() { ArabicName = "سعوديي", EnglishName = "Saudian", Notes = "" });

            foreach (var nationality in nationalities)
                context.Nationalities.Add(nationality);
            #endregion

            #region Divisions
            IList<Division> divisions = new List<Division>();

            divisions.Add(new Division { ArabicName = "الشؤون القانونية", EnglishName = "Legals", Notes = "" });
            divisions.Add(new Division { ArabicName = "المكتب التنفيذي", EnglishName = "General Manager Office", Notes = "" });
            divisions.Add(new Division { ArabicName = "تقنية المعلومات", EnglishName = "IT", Notes = "" });

            foreach (var division in divisions)
                context.Divisions.Add(division);
            #endregion

            #region OrganizationTypes
            var organizationTypes = new List<OrganizationType>();

            organizationTypes.Add(new OrganizationType { ArabicName = "افراد", EnglishName = "Legals", Notes = "" });
            organizationTypes.Add(new OrganizationType { ArabicName = "عاملين", EnglishName = "General Manager Office", Notes = "" });
            organizationTypes.Add(new OrganizationType { ArabicName = "وكلاء", EnglishName = "IT", Notes = "" });

            foreach (var organizationType in organizationTypes)
                context.OrganizationTypes.Add(organizationType);
            #endregion

            base.Seed(context);
        }
    }
}