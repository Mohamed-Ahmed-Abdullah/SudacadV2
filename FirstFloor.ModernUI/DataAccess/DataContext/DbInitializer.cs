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
            IList<Job> jobs = new List<Job>();

            jobs.Add(new Job() {ArabicName="محاسب",EnglishName="Accountant",Notes="" });
            jobs.Add(new Job() {ArabicName="مطور نظم",EnglishName="Software Developer",Notes="" });
            jobs.Add(new Job() {ArabicName="مدير",EnglishName="Manager",Notes="" });

            foreach (var job in jobs)
                context.Jobs.Add(job);

            base.Seed(context);
        }
    }
}
